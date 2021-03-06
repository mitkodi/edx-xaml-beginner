﻿using RestaurantManager.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows {
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class OrderPage : Page {
		public DataManager DataManager => DataContext as DataManager;

		public OrderPage() {
			this.InitializeComponent();
		}

		private void Home_Handle(object sender, RoutedEventArgs e) {
			Frame.Navigate(typeof(MainPage));
			Frame.BackStack.Clear();
		}

		private void SubmitOrder_Handle(object sender, RoutedEventArgs e) {
			DataManager.AddNewOrder();
			Frame.Navigate(typeof(ExpeditePage));
		}

		private void AddToOrder_Handle(object sender, RoutedEventArgs e) {
			DataManager.SelectMenuItem((string)MenuItemsList.SelectedItem);
		}
	}
}
