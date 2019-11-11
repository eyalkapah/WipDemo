using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using WipDemo.Enums;
using WipDemo.Models.UI;

namespace WipDemo.Converters
{
    public class MessageTypeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return new SolidColorBrush(Colors.Black);

            if (string.IsNullOrEmpty(value.ToString()))
                return new SolidColorBrush(Colors.Black);

            var uiMessage = value as UIMessage;

            if (uiMessage == null)
                return new SolidColorBrush(Colors.Black);

            switch (uiMessage.MessageType)
            {
                case MessageType.Error:
                    return new SolidColorBrush(Colors.Red);

                case MessageType.Success:
                    return new SolidColorBrush(Colors.Green);

                default:
                    return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}