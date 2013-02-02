// ----------------------------------------------------------------------------------------------
// Copyright (c) Mårten Rånge.
// ----------------------------------------------------------------------------------------------
// This source code is subject to terms and conditions of the Microsoft Public License. A 
// copy of the license can be found in the License.html file at the root of this distribution. 
// If you cannot locate the  Microsoft Public License, please send an email to 
// dlr@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
//  by the terms of the Microsoft Public License.
// ----------------------------------------------------------------------------------------------
// You must not remove this notice, or any other, from this software.
// ----------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local

using System;
using System.Windows;
using System.Windows.Media;
using LineGeometry.Source.Extensions;

namespace LineGeometry
{
    public partial class GeometryLine : FrameworkElement
    {
        static readonly Geometry s_defaultPart = Geometry.Parse("F0 M10,100 L100,100 100,50Z").FreezeObject();
        Drawing m_cachedDrawing;
        Pen m_cachedPen;

        void Invalidate()
        {
            m_cachedDrawing = null;
            InvalidateVisual();
        }

        Pen CachedPen
        {
            get
            {
                var stroke = Stroke;
                if (m_cachedPen == null && stroke != null)
                {
                    m_cachedPen = new Pen(stroke, StrokeThickness).FreezeObject();
                }
                return m_cachedPen;
            }
        }

        Drawing CachedDrawing
        {
            get
            {
                if (m_cachedDrawing == null)
                {
                    var drawing = ComputeDrawing(
                        Fill,
                        CachedPen,
                        Part, 
                        PartBoundsScale, 
                        PartsPerLine, 
                        X1, 
                        Y1, 
                        X2, 
                        Y2
                        );

                    m_cachedDrawing = drawing.FreezeObject();
                }

                return m_cachedDrawing;
            }
        }

        static Drawing ComputeDrawing(
            Brush brush,
            Pen pen,
            Geometry partGeometry, 
            double partBoundsScale, 
            int partsPerLine, 
            double x1, 
            double y1, 
            double x2, 
            double y2
            )
        {
            partsPerLine = Math.Max(2, partsPerLine);

            var part = partGeometry ?? s_defaultPart;
            var partBounds = part.Bounds;
            var adjustedPartBounds = partBounds;
            adjustedPartBounds.Scale(partBoundsScale, partBoundsScale);

            var centreOf = adjustedPartBounds.CentreOf();

            var start = new Vector(x1, y1);
            var end = new Vector(x2, y2);                       

            var diff = end - start;
            var distance = diff.Length;

            var step = new Vector(diff.X/(partsPerLine - 1), diff.Y/(partsPerLine - 1));

            var partScaling = distance/(adjustedPartBounds.Width*partsPerLine);
            var partRotation = Math.Atan2(diff.Y, diff.X)*180/Math.PI;

            var matrix = Matrix.Identity;
            matrix.Translate(-centreOf.X, -centreOf.Y);
            matrix.Rotate(partRotation);
            matrix.Scale(partScaling, partScaling);

            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                var current = start;

                for (var iter = 0; iter < partsPerLine; ++iter)
                {
                    var innerMatrix = matrix;
                    innerMatrix.Translate(current.X, current.Y);
                    var innerTransform = new MatrixTransform(innerMatrix);

                    dc.PushTransform(innerTransform);
                    dc.DrawGeometry(brush, pen, part);
                    dc.Pop();

                    current = current + step;
                }

            }

            return dv.Drawing;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return CachedDrawing.Bounds.Size;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }

        partial void Changed_Fill(Brush oldValue, Brush newValue)
        {
            Invalidate();
        }

        partial void Changed_Stroke(Brush oldValue, Brush newValue)
        {
            Invalidate();
        }

        partial void Coerce_StrokeThickness(double value, ref double coercedValue)
        {
            coercedValue = Math.Max(0, value);
        }

        partial void Changed_StrokeThickness(double oldValue, double newValue)
        {
            Invalidate();
        }

        partial void Changed_Part(Geometry oldValue, Geometry newValue)
        {
            Invalidate();
        }

        partial void Coerce_PartsPerLine(int value, ref int coercedValue)
        {
            coercedValue = Math.Max(2, value);
        }

        partial void Changed_PartsPerLine(int oldValue, int newValue)
        {
            Invalidate();
        }

        partial void Changed_PartBoundsScale(double oldValue, double newValue)
        {
            Invalidate();
        }

        partial void Changed_X1(double oldValue, double newValue)
        {
            Invalidate();
        }

        partial void Changed_Y1(double oldValue, double newValue)
        {
            Invalidate();
        }

        partial void Changed_X2(double oldValue, double newValue)
        {
            Invalidate();
        }

        partial void Changed_Y2(double oldValue, double newValue)
        {
            Invalidate();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawDrawing (CachedDrawing);
        }

    }
}
