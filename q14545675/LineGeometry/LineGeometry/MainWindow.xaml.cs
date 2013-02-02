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

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using LineGeometry.Source.Extensions;

namespace LineGeometry
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;

        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            var geom = Geometry.Parse("M 10,100 L 100,100 100,50 Z M 10,10 100,10 100,40 Z").FreezeObject();

            const int rot = 12;

            var width = ActualWidth;
            var height = ActualHeight;

            var cx = width/2;
            var cy = height/2;

            const double innerRadius = 20;
            const double outerRadius = 200;

            for (var iter = 0; iter < rot; ++iter)
            {
                var angle = (iter*Math.PI*2)/rot;
                var sin = Math.Sin(angle);
                var cos = Math.Cos(angle);
                var x1 = innerRadius*cos + cx;
                var y1 = innerRadius*sin + cy;
                var x2 = outerRadius*cos + cx;
                var y2 = outerRadius*sin + cy;
                Content.Children.Add(
                    new GeometryLine
                        {
                            Part            = geom          ,
                            Fill            = Brushes.Black ,
                            Stroke          = Brushes.Black ,
                            PartsPerLine    = 10            ,
                            X1              = x1            ,
                            Y1              = y1            ,
                            X2              = x2            ,
                            Y2              = y2            ,
                        });
                Content.Children.Add(
                    new Line
                        {
                            Fill            = Brushes.Red   ,
                            Stroke          = Brushes.Red   ,
                            X1              = x1            ,
                            Y1              = y1            ,
                            X2              = x2            ,
                            Y2              = y2            ,
                        });
            }

        }
    }
}
