﻿using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace OnBoardUWP.Views
{

    public sealed partial class Homepage : Page
    {
        // Using the, in app.cs initialized, viewmodel for databinding
        public HomepageViewModel ViewModel => App.HomepageModel;

        public Homepage()
        {
            this.InitializeComponent();
        }
    }
}
