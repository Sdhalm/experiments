﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;
using SimpleApp.ViewModels;
using Splat;

namespace SimpleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // This is the "magic" that automatically registers each view against the IViewFor<> 
            //  interface it implements. This is specific to Splat, and could be replaced by the
            //  specific capabilities of another IoC library
            //
            var assembly = Assembly.GetExecutingAssembly();
            Locator.CurrentMutable.RegisterViewsForViewModels(assembly);

            var view = (Views.MainWindow)Locator.CurrentMutable.GetService(typeof(IViewFor<MainWindowViewModel>));
            view.Show();
        }
    }
}
