﻿using CookPopularControl.Controls;
using PropertyChanged;
using System.Windows;
using System.Windows.Controls;

namespace MvvmTestDemo.DemoViews
{
    /// <summary>
    /// PasswordBoxDemo.xaml 的交互逻辑
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class PasswordBoxDemo : UserControl
    {
        public PasswordBoxDemo()
        {
            InitializeComponent();
        }

        public string PasswordContent1 { get; set; }
        public string PasswordContent2 { get; set; }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var pwdAttached1 = PasswordBoxAssistant.GetPassword(Pwd1);
            var pwd1 = Pwd1.Password;
            var bol1 = pwdAttached1.Equals(pwd1);

            var pwdAttached2 = PasswordBoxAssistant.GetPassword(Pwd2);
            var pwd2 = Pwd2.Password;
            var bol2 = pwdAttached2.Equals(pwd2);

            var pwdAttached3 = PasswordBoxAssistant.GetPassword(Pwd3);
            var pwd3 = Pwd3.Password;
            var bol3 = pwdAttached3.Equals(pwd3);
        }

        private void Pwd1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pwd = (sender as PasswordBox).Password;
        }

        private void Pwd2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pwd = (sender as PasswordBox).Password;
        }


        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            //InputScopeNameValue
        }
    }
}
