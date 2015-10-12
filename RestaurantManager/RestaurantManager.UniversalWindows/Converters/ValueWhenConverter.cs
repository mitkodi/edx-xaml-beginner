using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.UniversalWindows.Converters {
	class ValueWhenConverter : IValueConverter {
		public object Value { get; set; }
		public object Otherwise { get; set; }
		public object When { get; set; }

		public object Convert(object value, Type targetType, object parameter, string language) {
			return object.Equals(this.Value, value) ? this.When : this.Otherwise;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language) {
			throw new NotImplementedException();
		}
	}
}
