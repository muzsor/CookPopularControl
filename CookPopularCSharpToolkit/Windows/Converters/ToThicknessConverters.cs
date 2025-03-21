﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;



/*
 * Copyright (c) 2021 All Rights Reserved.
 * Description：ToThicknessConverters
 * Author： Chance_写代码的厨子
 * Create Time：2021-11-06 21:08:43
 */
namespace CookPopularCSharpToolkit.Windows
{
    /// <summary>
    /// Double To Thickness
    /// </summary>
    [MarkupExtensionReturnType(typeof(Thickness))]
    [Localizability(LocalizationCategory.NeverLocalize)]
    [ValueConversion(typeof(double), typeof(Thickness))]
    public class DoubleToThicknessConverter : MarkupExtensionBase, IValueConverter
    {
        public static Thickness FixedThickness = new Thickness(1);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            parameter = parameter ?? 1;
            var isDouble = double.TryParse(parameter.ToString(), out double p);
            if (value is double v && isDouble)
            {
                return new Thickness(v * p);
            }

            return FixedThickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
                return thickness.Left;
            else
                return double.NaN;
        }
    }


    /// <summary>
    /// Double To Thickness
    /// </summary>
    [MarkupExtensionReturnType(typeof(Thickness))]
    [Localizability(LocalizationCategory.NeverLocalize)]
    [ValueConversion(typeof(double), typeof(Thickness))]
    public class DoubleToLeftRightThicknessConverter : MarkupExtensionBase, IValueConverter
    {
        public static Thickness FixedThickness = new Thickness(1);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            parameter = parameter ?? 1;
            var isDouble = double.TryParse(parameter.ToString(), out double p);
            if (value is double v && isDouble)
            {
                return new Thickness(v * p,0, v * p, 0);
            }

            return FixedThickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
                return thickness.Left;
            else
                return double.NaN;
        }
    }


    /// <summary>
    /// Double To Thickness
    /// </summary>
    [MarkupExtensionReturnType(typeof(Thickness))]
    [Localizability(LocalizationCategory.NeverLocalize)]
    [ValueConversion(typeof(double), typeof(Thickness))]
    public class DoubleToTopBottomThicknessConverter : MarkupExtensionBase, IValueConverter
    {
        public static Thickness FixedThickness = new Thickness(1);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            parameter = parameter ?? 1;
            var isDouble = double.TryParse(parameter.ToString(), out double p);
            if (value is double v && isDouble)
            {
                return new Thickness(0, v * p, 0, v * p);
            }

            return FixedThickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
                return thickness.Left;
            else
                return double.NaN;
        }
    }


    [MarkupExtensionReturnType(typeof(Thickness))]
    [Localizability(LocalizationCategory.NeverLocalize)]
    [ValueConversion(typeof(Thickness), typeof(Thickness))]
    public class ThicknessToThicknessConverter : MarkupExtensionBase, IValueConverter
    {
        public static Thickness FixedThickness = new Thickness(1);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness && parameter is double param)
            {
                return new Thickness(thickness.Left * param, thickness.Top * param, thickness.Right * param, thickness.Bottom * param);
            }

            return FixedThickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
