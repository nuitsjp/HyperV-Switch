using Nuits.HyperV.Switch.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Nuits.HyperV.Switch.View.Converter
{
    public class HyperVisorLaunchTypeConverter : IValueConverter
    {
        /// <summary>
        /// ViewModelで利用する型からViewで利用する型へ変換する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HyperVisorLaunchType)value == HyperVisorLaunchType.Auto;
        }
        /// <summary>
        /// Viewで利用する型からViewModelで利用する型へ変換する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? HyperVisorLaunchType.Auto : HyperVisorLaunchType.Off;
        }
    }
}
