﻿using CookPopularControl.Communal.Data;
using CookPopularControl.Controls;
using CookPopularCSharpToolkit.Communal;
using CookPopularCSharpToolkit.Windows;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


/*
 * Copyright (c) 2021 All Rights Reserved.
 * Description：ControlBorderBehavior 
 * Author： Chance_写代码的厨子
 * Create Time：2021-02-20 17:49:53
 */
namespace CookPopularControl.Communal
{
    /// <summary>
    /// 提供控件边框的行为动画
    /// </summary>
    public class ControlBorderBehavior : Behavior<Control>
    {
        private const double totalAnimationTimes = 1000D; //ms
        private Brush originBrush;
        private Thickness originThickness;

        public double BorderThickness { get; set; } = 1D;
        public Brush BorderBrush { get; set; } = ResourceHelper.GetResource<SolidColorBrush>("BorderBrush");
        public Duration Duration { get; set; } = new Duration(TimeSpan.FromSeconds(1));
        public bool IsRetainBehavior { get; set; }
        public ControlBorderAnimationType AnimationType { get; set; }


        protected override void OnAttached()
        {
            base.OnAttached();

            originBrush = AssociatedObject.BorderBrush;
            originThickness = AssociatedObject.BorderThickness;

            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp += AssociatedObject_PreviewMouseLeftButtonUp;
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObject_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp -= AssociatedObject_PreviewMouseLeftButtonUp;
            AssociatedObject.LostFocus -= AssociatedObject_LostFocus;
        }

        private void AssociatedObject_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (AnimationType)
            {
                case ControlBorderAnimationType.Thickness:
                    StarThicknessAnimation();
                    break;
                case ControlBorderAnimationType.OrderThickness:
                    StarOrderThicknessAnimation();
                    break;
                case ControlBorderAnimationType.Path:
                    StartPathAnimation();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void AssociatedObject_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            RestoreBorderStyle();
        }

        private void StarOrderThicknessAnimation()
        {
            AssociatedObject.BorderBrush = BorderBrush;

            ThicknessAnimationUsingKeyFrames frames = new ThicknessAnimationUsingKeyFrames
            {
                RepeatBehavior = new RepeatBehavior(1),
                FillBehavior = FillBehavior.Stop,
                Duration = Duration,
            };

            var frame0 = new LinearThicknessKeyFrame
            {
                KeyTime = TimeSpan.Zero,
                Value = new Thickness(0),
            };
            var frame1 = new LinearThicknessKeyFrame
            {
                KeyTime = TimeSpan.FromMilliseconds(0.25 * totalAnimationTimes),
                Value = new Thickness(0, 0, 0, BorderThickness),
            };
            var frame2 = new LinearThicknessKeyFrame
            {
                KeyTime = TimeSpan.FromMilliseconds(0.5 * totalAnimationTimes),
                Value = new Thickness(0, 0, BorderThickness, BorderThickness),
            };
            var frame3 = new LinearThicknessKeyFrame
            {
                KeyTime = TimeSpan.FromMilliseconds(0.75 * totalAnimationTimes),
                Value = new Thickness(0, BorderThickness, BorderThickness, BorderThickness),
            };
            var frame4 = new LinearThicknessKeyFrame
            {
                KeyTime = TimeSpan.FromMilliseconds(1.1 * totalAnimationTimes),
                Value = new Thickness(BorderThickness),
            };
            frames.KeyFrames.Add(frame0);
            frames.KeyFrames.Add(frame1);
            frames.KeyFrames.Add(frame2);
            frames.KeyFrames.Add(frame3);
            frames.KeyFrames.Add(frame4);

            var clock = frames.CreateClock();
            clock.Completed += AnimationCompleted;

            AssociatedObject.ApplyAnimationClock(Control.BorderThicknessProperty, clock, HandoffBehavior.Compose);
        }

        private void StarThicknessAnimation()
        {
            AssociatedObject.BorderBrush = BorderBrush;

            ThicknessAnimation thicknessAnimation = new ThicknessAnimation()
            {
                RepeatBehavior = new RepeatBehavior(1),
                FillBehavior = FillBehavior.Stop,
            };
            thicknessAnimation.From = originThickness;
            thicknessAnimation.To = new Thickness(BorderThickness);
            thicknessAnimation.Duration = Duration;
            thicknessAnimation.Completed += AnimationCompleted;

            AssociatedObject.BeginAnimation(Control.BorderThicknessProperty, thicknessAnimation);
        }

        private void AnimationCompleted(object sender, EventArgs e)
        {
            if (IsRetainBehavior)
            {
                AssociatedObject.BorderBrush = BorderBrush;
                AssociatedObject.BorderThickness = new Thickness(BorderThickness);
            }
            else
                RestoreBorderStyle();
        }

        private void RestoreBorderStyle()
        {
            AssociatedObject.BorderBrush = originBrush;
            AssociatedObject.BorderThickness = originThickness;
            AssociatedObject.OpacityMask = null;
        }

        private void StartPathAnimation()
        {
            Rect rec = new Rect(0, 0, AssociatedObject.Width, AssociatedObject.Height);
            double cornerRadius = FrameworkElementBaseAttached.GetCornerRadius(AssociatedObject).TopLeft;
            RectangleGeometry rectangleGeometry = new RectangleGeometry(rec, cornerRadius, cornerRadius);

            BorderAnimationPath animationPath = new BorderAnimationPath()
            {
                Data = rectangleGeometry,
                Flag = 1,
                Duration = Duration,
                Fill = AssociatedObject.Background,
                Stroke = BorderBrush,
                StrokeThickness = BorderThickness,
            };
            animationPath.Completed += AnimationPath_Completed;

            BorderAnimationPath animationPath2 = new BorderAnimationPath()
            {
                Data = rectangleGeometry,
                Flag = -1,
                Duration = Duration,
                Fill = AssociatedObject.Background,
                Stroke = BorderBrush,
                StrokeThickness = BorderThickness,
            };
            animationPath2.Completed += AnimationPath_Completed;

            SimpleGrid panel = new SimpleGrid();
            panel.Children.Add(animationPath);
            panel.Children.Add(animationPath2);

            Rectangle rectangle = new Rectangle();
            VisualBrush visualBrush = new VisualBrush();
            visualBrush.Visual = panel;
            AssociatedObject.OpacityMask = visualBrush;
        }

        private void AnimationPath_Completed(object sender, EventArgs e)
        {
            if (!IsRetainBehavior)
                AssociatedObject.OpacityMask = null;
        }

        [DefaultEvent("Completed")]
        private class BorderAnimationPath : Shape
        {
            private Storyboard storyboard;

            public Geometry Data
            {
                get { return (Geometry)GetValue(DataProperty); }
                set { SetValue(DataProperty, value); }
            }
            public static readonly DependencyProperty DataProperty =
                DependencyProperty.Register("Data", typeof(Geometry), typeof(BorderAnimationPath),
                    new PropertyMetadata(Geometry.Empty, new PropertyChangedCallback(OnPropertiesValueChanged)));

            public int Flag
            {
                get { return (int)GetValue(FlagProperty); }
                set { SetValue(FlagProperty, value); }
            }
            public static readonly DependencyProperty FlagProperty =
                DependencyProperty.Register("Flag", typeof(int), typeof(BorderAnimationPath),
                   new FrameworkPropertyMetadata(1, OnPropertiesValueChanged));

            public Duration Duration
            {
                get { return (Duration)GetValue(DurationProperty); }
                set { SetValue(DurationProperty, value); }
            }
            public static readonly DependencyProperty DurationProperty =
                DependencyProperty.Register("Duration", typeof(Duration), typeof(BorderAnimationPath),
                    new FrameworkPropertyMetadata(new Duration(TimeSpan.FromSeconds(1)), OnPropertiesValueChanged));

            private static void OnPropertiesValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                //(d as BorderAnimationPath)?.UpdateAnimationPath();
            }


            [Description("动画完成时发生")]
            public event EventHandler Completed
            {
                add { this.AddHandler(CompletedEvent, value); }
                remove { this.RemoveHandler(CompletedEvent, value); }
            }
            public static readonly RoutedEvent CompletedEvent =
                EventManager.RegisterRoutedEvent("Completed", RoutingStrategy.Bubble, typeof(EventHandler), typeof(BorderAnimationPath));

            protected override Geometry DefiningGeometry => Data ?? Geometry.Empty;

            static BorderAnimationPath()
            {
                StretchProperty.AddOwner(typeof(BorderAnimationPath), new FrameworkPropertyMetadata(Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsRender, OnPropertiesValueChanged));
                StrokeProperty.AddOwner(typeof(BorderAnimationPath), new FrameworkPropertyMetadata(Brushes.DodgerBlue, FrameworkPropertyMetadataOptions.AffectsRender, OnPropertiesValueChanged));
                StrokeThicknessProperty.AddOwner(typeof(BorderAnimationPath), new FrameworkPropertyMetadata(ValueBoxes.Double5Box, FrameworkPropertyMetadataOptions.AffectsRender, OnPropertiesValueChanged));
            }

            public BorderAnimationPath()
            {
                this.Loaded += (s, e) => UpdateAnimationPath();
            }

            private void UpdateAnimationPath()
            {
                if (!Duration.HasTimeSpan) return;

                RotateTransform rt = new RotateTransform() { Angle = 180 };
                this.RenderTransformOrigin = new Point(0.5, 0.5);
                this.RenderTransform = rt;
                var pathLength = Data.GetTotalLength(new Size(ActualWidth, ActualHeight), StrokeThickness);

                if (MathHelper.IsVerySmall(pathLength)) return;

                StrokeDashOffset = pathLength;
                StrokeDashArray = new DoubleCollection(new List<double> { pathLength, pathLength });

                if (storyboard != null)
                {
                    storyboard.Stop();
                    storyboard.Completed -= Storyboard_Completed;
                }
                storyboard = new Storyboard
                {
                    RepeatBehavior = new RepeatBehavior(1),
                    FillBehavior = FillBehavior.HoldEnd,
                };

                storyboard.Completed += Storyboard_Completed;
                var frames = new DoubleAnimationUsingKeyFrames();
                var frame1 = new LinearDoubleKeyFrame()
                {
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero),
                    Value = pathLength * Flag,
                };
                var frame2 = new LinearDoubleKeyFrame()
                {
                    KeyTime = KeyTime.FromTimeSpan(Duration.TimeSpan),
                    Value = pathLength / 2D * Flag
                };
                frames.KeyFrames.Add(frame1);
                frames.KeyFrames.Add(frame2);

                Storyboard.SetTarget(frames, this);
                Storyboard.SetTargetProperty(frames, new PropertyPath(Shape.StrokeDashOffsetProperty));
                storyboard.Children.Add(frames);

                storyboard.Begin();
                storyboard.Freeze();
            }

            private void Storyboard_Completed(object sender, EventArgs e) => RaiseEvent(new RoutedEventArgs(CompletedEvent));
        }
    }
}
