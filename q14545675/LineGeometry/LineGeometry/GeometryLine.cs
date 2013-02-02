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
        Geometry m_cachedGeometry;
        Pen m_cachedPen;

        void Invalidate()
        {
            InvalidateVisual();
        }

        void InvalidateStroke()
        {
            m_cachedPen = null;
            InvalidateVisual();
        }

        void InvalidateGeometry()
        {
            m_cachedGeometry = null;
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

        Geometry CachedGeometry
        {
            get
            {
                if (m_cachedGeometry == null)
                {
                    var geometry = ComputeGeometry(Part, PartBoundsScale, PartsPerLine, X1, Y1, X2, Y2);

                    m_cachedGeometry = geometry.FreezeObject();
                }

                return m_cachedGeometry ?? Geometry.Empty;
            }
        }

        static Geometry ComputeGeometry(Geometry partGeometry, double partBoundsScale, int partsPerLine, double x1, double y1, double x2, double y2)
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
            var partRotation = Math.Atan2(diff.X, diff.Y)*180/Math.PI;

            var matrix = Matrix.Identity;
            matrix.Translate(-centreOf.X, -centreOf.Y);
            matrix.Rotate(partRotation);
            matrix.Scale(partScaling, partScaling);

            var geometryGroup = new GeometryGroup();

            var current = start;

            for (var iter = 0; iter < partsPerLine; ++iter)
            {
                var clone = part.Clone();

                var cloneMatrix = matrix;
                cloneMatrix.Translate(current.X, current.Y);
                clone.Transform = new MatrixTransform(cloneMatrix);

                geometryGroup.Children.Add(clone);

                current = current + step;
            }
            return geometryGroup;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return CachedGeometry.Bounds.Size;
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
            InvalidateStroke();
        }

        partial void Coerce_StrokeThickness(double value, ref double coercedValue)
        {
            coercedValue = Math.Max(0, value);
        }

        partial void Changed_StrokeThickness(double oldValue, double newValue)
        {
            InvalidateStroke();
        }

        partial void Changed_Part(Geometry oldValue, Geometry newValue)
        {
            InvalidateGeometry();
        }

        partial void Coerce_PartsPerLine(int value, ref int coercedValue)
        {
            coercedValue = Math.Max(2, value);
        }

        partial void Changed_PartsPerLine(int oldValue, int newValue)
        {
            InvalidateGeometry();
        }

        partial void Changed_PartBoundsScale(double oldValue, double newValue)
        {
            InvalidateGeometry();
        }

        partial void Changed_X1(double oldValue, double newValue)
        {
            InvalidateGeometry();
        }

        partial void Changed_Y1(double oldValue, double newValue)
        {
            InvalidateGeometry();
        }

        partial void Changed_X2(double oldValue, double newValue)
        {
            InvalidateGeometry();
        }

        partial void Changed_Y2(double oldValue, double newValue)
        {
            InvalidateGeometry();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawGeometry(Fill, CachedPen, CachedGeometry);
        }

    }
}
