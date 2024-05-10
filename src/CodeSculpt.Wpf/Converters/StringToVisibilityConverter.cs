using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodeSculpt.Wpf.Converters;

/// <summary>
/// Converts a string value into a System.Windows.Visibility value
/// </summary>
[ValueConversion(typeof(string), typeof(Visibility))]
public class StringToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Converts a boolean value into a System.Windows.Visibility value dependant on the value of the FalseVisibilityState and IsInverted properties.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A System.Windows.Visibility value dependant on the value of the FalseVisibilityState and IsInverted properties.</returns>
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null || value.GetType() != typeof(string))
        {
            return null;
        }

        var stringValue = value as string;

        return string.IsNullOrEmpty(stringValue) ? Visibility.Collapsed : Visibility.Visible;
    }
    /// <summary>
    /// Converts a System.Windows.Visibility value into an boolean value dependant on the Visibility input value and the IsInverted property.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A boolean value dependant on the Visibility input value and the IsInverted property.</returns>
    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || value.GetType() != typeof(Visibility))
        {
            return null;
        }

        return (Visibility)value == Visibility.Visible;
    }
}
