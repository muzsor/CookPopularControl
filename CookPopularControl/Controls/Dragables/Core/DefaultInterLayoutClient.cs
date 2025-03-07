﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;



/*
 * Copyright (c) 2021 All Rights Reserved.
 * Description：DefaultInterLayoutClient
 * Author： Chance_写代码的厨子
 * Create Time：2021-08-12 08:57:34
 */
namespace CookPopularControl.Controls.Dragables
{
    /// <summary>
    /// Provides a simple implementation of <see cref="IInterLayoutClient"/>, but only really useful if 
    /// <see cref="TabItem"/> instances are specified in XAML.  If you are binding via ItemsSource then
    /// you most likely want to create your own implementation of <see cref="IInterLayoutClient"/>.
    /// </summary>
    public class DefaultInterLayoutClient : IInterLayoutClient
    {
        public INewTabHost<UIElement> GetNewHost(object partition, DragableTabControl source)
        {
            var tabablzControl = new DragableTabControl { DataContext = source.DataContext };

            Clone(source, tabablzControl);

            if (source.InterTabController == null)
                throw new InvalidOperationException("Source tab does not have an InterTabCOntroller set.  Ensure this is set on initial, and subsequently generated tab controls.");

            var newInterTabController = new InterTabController
            {
                Partition = source.InterTabController.Partition
            };
            Clone(source.InterTabController, newInterTabController);
            tabablzControl.SetCurrentValue(DragableTabControl.InterTabControllerProperty, newInterTabController);

            return new NewTabHost<UIElement>(tabablzControl, tabablzControl);
        }

        private static void Clone(DependencyObject from, DependencyObject to)
        {
            var localValueEnumerator = from.GetLocalValueEnumerator();
            while (localValueEnumerator.MoveNext())
            {
                if (localValueEnumerator.Current.Property.ReadOnly ||
                    localValueEnumerator.Current.Value is FrameworkElement) continue;

                if (!(localValueEnumerator.Current.Value is BindingExpressionBase))
                    to.SetCurrentValue(localValueEnumerator.Current.Property, localValueEnumerator.Current.Value);
            }
        }
    }
}
