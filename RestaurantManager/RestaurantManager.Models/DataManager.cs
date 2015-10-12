using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models {
	public class DataManager {

		public DataManager() {
			this.OrderItems = new ObservableCollection<string>(
				new List<string>
				{
					"Steak, Chicken, Peas",
					"Rice, Chicken",
					"Hummus, Pita"
				}
			);

			this.MenuItems = new List<string>
			{
				"Steak",
				"Chicken",
				"Peas",
				"Rice",
				"Hummus",
				"Pita"
			};

			//this.CurrentlySelectedMenuItems = new List<string>
			this.CurrentlySelectedMenuItems = new ObservableCollection<string>();
			//{
			//	"Rice",
			//	"Pita"
			//};

		}

		public void SelectMenuItem(string menuItem) {
			var regex = new System.Text.RegularExpressions.Regex($@"((\d)+x)?{menuItem}");
			var existingItem = CurrentlySelectedMenuItems.FirstOrDefault(s => regex.IsMatch(s));
			if (existingItem != null) {
				var index = CurrentlySelectedMenuItems.IndexOf(existingItem);
				int currentCount;
				var match = regex.Match(existingItem);
				if (match.Groups[1].Success) {
					currentCount = Int32.Parse(regex.Match(existingItem).Groups[2].Value);
				}
				else {
					currentCount = 1;
				}
				CurrentlySelectedMenuItems[index] = $"{++currentCount}x{menuItem}"; existingItem = $"{++currentCount}x{menuItem}";
            }
			else {
				CurrentlySelectedMenuItems.Add(menuItem);
			}
		}

		public void AddNewOrder() {
			OrderItems.Add(String.Join(", ", CurrentlySelectedMenuItems));
			CurrentlySelectedMenuItems.Clear();
		}

		public ObservableCollection<string> OrderItems { get; set; }
		public List<string> MenuItems { get; set; }
		//public List<string> CurrentlySelectedMenuItems { get; set; }
		public ObservableCollection<string> CurrentlySelectedMenuItems { get; set; }
	}

}
