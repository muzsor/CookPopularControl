﻿using System.Windows;



/*
 * Copyright (c) 2021 All Rights Reserved.
 * Description：UIElementExtension
 * Author： Chance_写代码的厨子
 * Create Time：2021-05-24 11:06:23
 */
namespace CookPopularCSharpToolkit.Windows
{
    public static class UIElementExtension
    {
        /// <summary>
        /// 显示元素
        /// </summary>
        /// <param name="element"></param>
        public static void ToVisible(this UIElement element) => element.Visibility = Visibility.Visible;

        /// <summary>
        /// 不显示元素，但保留空间
        /// </summary>
        /// <param name="element"></param>
        public static void ToHide(this UIElement element) => element.Visibility = Visibility.Hidden;

        /// <summary>
        /// 不显示元素，且不保留空间
        /// </summary>
        /// <param name="element"></param>
        public static void ToCollapse(this UIElement element) => element.Visibility = Visibility.Collapsed;
    }
}
