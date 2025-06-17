
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QuizApp.Converters
{
    public class EqualityToBrushMultiConverter : IMultiValueConverter
    {
        public Brush TrueBrush { get; set; } = Brushes.Green;
        public Brush FalseBrush { get; set; } = Brushes.Gray;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return FalseBrush;

            var selected = values[0];
            var current = values[1];

            if (selected == null || current == null)
                return FalseBrush;

            return selected.Equals(current) ? TrueBrush : FalseBrush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
