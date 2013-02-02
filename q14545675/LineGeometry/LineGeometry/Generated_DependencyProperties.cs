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


// ############################################################################
// #                                                                          #
// #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
// #                                                                          #
// # This means that any edits to the .cs file will be lost when its          #
// # regenerated. Changes should instead be applied to the corresponding      #
// # template file (.tt)                                                      #
// ############################################################################





// ReSharper disable InconsistentNaming
// ReSharper disable InvocationIsSkipped
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantUsingDirective

namespace LineGeometry
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using System.Windows;
    using System.Windows.Media;

    // ------------------------------------------------------------------------
    // GeometryLine
    // ------------------------------------------------------------------------
    partial class GeometryLine
    {
        #region Uninteresting generated code
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register (
            "Fill",
            typeof (Brush),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (Brush),
                FrameworkPropertyMetadataOptions.None,
                Changed_Fill,
                Coerce_Fill          
            ));

        static void Changed_Fill (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (Brush)eventArgs.OldValue;
                var newValue = (Brush)eventArgs.NewValue;

                instance.Changed_Fill (oldValue, newValue);
            }
        }


        static object Coerce_Fill (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Brush)basevalue;
            var newValue = oldValue;

            instance.Coerce_Fill (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register (
            "Stroke",
            typeof (Brush),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (Brush),
                FrameworkPropertyMetadataOptions.None,
                Changed_Stroke,
                Coerce_Stroke          
            ));

        static void Changed_Stroke (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (Brush)eventArgs.OldValue;
                var newValue = (Brush)eventArgs.NewValue;

                instance.Changed_Stroke (oldValue, newValue);
            }
        }


        static object Coerce_Stroke (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Brush)basevalue;
            var newValue = oldValue;

            instance.Coerce_Stroke (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register (
            "StrokeThickness",
            typeof (double),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                1.0,
                FrameworkPropertyMetadataOptions.None,
                Changed_StrokeThickness,
                Coerce_StrokeThickness          
            ));

        static void Changed_StrokeThickness (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_StrokeThickness (oldValue, newValue);
            }
        }


        static object Coerce_StrokeThickness (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_StrokeThickness (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty PartsPerLineProperty = DependencyProperty.Register (
            "PartsPerLine",
            typeof (int),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                5,
                FrameworkPropertyMetadataOptions.None,
                Changed_PartsPerLine,
                Coerce_PartsPerLine          
            ));

        static void Changed_PartsPerLine (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (int)eventArgs.OldValue;
                var newValue = (int)eventArgs.NewValue;

                instance.Changed_PartsPerLine (oldValue, newValue);
            }
        }


        static object Coerce_PartsPerLine (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (int)basevalue;
            var newValue = oldValue;

            instance.Coerce_PartsPerLine (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty PartBoundsScaleProperty = DependencyProperty.Register (
            "PartBoundsScale",
            typeof (double),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                1.1,
                FrameworkPropertyMetadataOptions.None,
                Changed_PartBoundsScale,
                Coerce_PartBoundsScale          
            ));

        static void Changed_PartBoundsScale (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_PartBoundsScale (oldValue, newValue);
            }
        }


        static object Coerce_PartBoundsScale (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_PartBoundsScale (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty PartProperty = DependencyProperty.Register (
            "Part",
            typeof (Geometry),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (Geometry),
                FrameworkPropertyMetadataOptions.None,
                Changed_Part,
                Coerce_Part          
            ));

        static void Changed_Part (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (Geometry)eventArgs.OldValue;
                var newValue = (Geometry)eventArgs.NewValue;

                instance.Changed_Part (oldValue, newValue);
            }
        }


        static object Coerce_Part (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (Geometry)basevalue;
            var newValue = oldValue;

            instance.Coerce_Part (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty X1Property = DependencyProperty.Register (
            "X1",
            typeof (double),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_X1,
                Coerce_X1          
            ));

        static void Changed_X1 (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_X1 (oldValue, newValue);
            }
        }


        static object Coerce_X1 (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_X1 (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty Y1Property = DependencyProperty.Register (
            "Y1",
            typeof (double),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_Y1,
                Coerce_Y1          
            ));

        static void Changed_Y1 (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_Y1 (oldValue, newValue);
            }
        }


        static object Coerce_Y1 (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_Y1 (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty X2Property = DependencyProperty.Register (
            "X2",
            typeof (double),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_X2,
                Coerce_X2          
            ));

        static void Changed_X2 (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_X2 (oldValue, newValue);
            }
        }


        static object Coerce_X2 (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_X2 (oldValue, ref newValue);


            return newValue;
        }

        public static readonly DependencyProperty Y2Property = DependencyProperty.Register (
            "Y2",
            typeof (double),
            typeof (GeometryLine),
            new FrameworkPropertyMetadata (
                default (double),
                FrameworkPropertyMetadataOptions.None,
                Changed_Y2,
                Coerce_Y2          
            ));

        static void Changed_Y2 (DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance != null)
            {
                var oldValue = (double)eventArgs.OldValue;
                var newValue = (double)eventArgs.NewValue;

                instance.Changed_Y2 (oldValue, newValue);
            }
        }


        static object Coerce_Y2 (DependencyObject dependencyObject, object basevalue)
        {
            var instance = dependencyObject as GeometryLine;
            if (instance == null)
            {
                return basevalue;
            }
            var oldValue = (double)basevalue;
            var newValue = oldValue;

            instance.Coerce_Y2 (oldValue, ref newValue);


            return newValue;
        }

        #endregion

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public GeometryLine ()
        {
            CoerceAllProperties ();
            Constructed__GeometryLine ();
        }
        // --------------------------------------------------------------------
        partial void Constructed__GeometryLine ();
        // --------------------------------------------------------------------
        void CoerceAllProperties ()
        {
            CoerceValue (FillProperty);
            CoerceValue (StrokeProperty);
            CoerceValue (StrokeThicknessProperty);
            CoerceValue (PartsPerLineProperty);
            CoerceValue (PartBoundsScaleProperty);
            CoerceValue (PartProperty);
            CoerceValue (X1Property);
            CoerceValue (Y1Property);
            CoerceValue (X2Property);
            CoerceValue (Y2Property);
        }


        // --------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------

           
        // --------------------------------------------------------------------
        public Brush Fill
        {
            get
            {
                return (Brush)GetValue (FillProperty);
            }
            set
            {
                if (Fill != value)
                {
                    SetValue (FillProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Fill (Brush value, ref Brush coercedValue);
        partial void Changed_Fill (Brush oldValue, Brush newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public Brush Stroke
        {
            get
            {
                return (Brush)GetValue (StrokeProperty);
            }
            set
            {
                if (Stroke != value)
                {
                    SetValue (StrokeProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Stroke (Brush value, ref Brush coercedValue);
        partial void Changed_Stroke (Brush oldValue, Brush newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double StrokeThickness
        {
            get
            {
                return (double)GetValue (StrokeThicknessProperty);
            }
            set
            {
                if (StrokeThickness != value)
                {
                    SetValue (StrokeThicknessProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_StrokeThickness (double value, ref double coercedValue);
        partial void Changed_StrokeThickness (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public int PartsPerLine
        {
            get
            {
                return (int)GetValue (PartsPerLineProperty);
            }
            set
            {
                if (PartsPerLine != value)
                {
                    SetValue (PartsPerLineProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_PartsPerLine (int value, ref int coercedValue);
        partial void Changed_PartsPerLine (int oldValue, int newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double PartBoundsScale
        {
            get
            {
                return (double)GetValue (PartBoundsScaleProperty);
            }
            set
            {
                if (PartBoundsScale != value)
                {
                    SetValue (PartBoundsScaleProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_PartBoundsScale (double value, ref double coercedValue);
        partial void Changed_PartBoundsScale (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public Geometry Part
        {
            get
            {
                return (Geometry)GetValue (PartProperty);
            }
            set
            {
                if (Part != value)
                {
                    SetValue (PartProperty, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Part (Geometry value, ref Geometry coercedValue);
        partial void Changed_Part (Geometry oldValue, Geometry newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double X1
        {
            get
            {
                return (double)GetValue (X1Property);
            }
            set
            {
                if (X1 != value)
                {
                    SetValue (X1Property, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_X1 (double value, ref double coercedValue);
        partial void Changed_X1 (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double Y1
        {
            get
            {
                return (double)GetValue (Y1Property);
            }
            set
            {
                if (Y1 != value)
                {
                    SetValue (Y1Property, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Y1 (double value, ref double coercedValue);
        partial void Changed_Y1 (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double X2
        {
            get
            {
                return (double)GetValue (X2Property);
            }
            set
            {
                if (X2 != value)
                {
                    SetValue (X2Property, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_X2 (double value, ref double coercedValue);
        partial void Changed_X2 (double oldValue, double newValue);
        // --------------------------------------------------------------------


           
        // --------------------------------------------------------------------
        public double Y2
        {
            get
            {
                return (double)GetValue (Y2Property);
            }
            set
            {
                if (Y2 != value)
                {
                    SetValue (Y2Property, value);
                }
            }
        }
        // --------------------------------------------------------------------
        partial void Coerce_Y2 (double value, ref double coercedValue);
        partial void Changed_Y2 (double oldValue, double newValue);
        // --------------------------------------------------------------------


    }
    // ------------------------------------------------------------------------

}



