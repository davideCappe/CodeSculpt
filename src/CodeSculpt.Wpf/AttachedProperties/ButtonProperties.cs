﻿using System.Windows;
using System.Windows.Controls;

namespace CodeSculpt.Wpf.AttachedProperties;
public class ButtonProperties : DependencyObject
{
    #region DisableToolTip

    private static readonly DependencyPropertyKey originalToolTipPropertyKey = DependencyProperty.RegisterAttachedReadOnly("OriginalToolTip", typeof(string), typeof(ButtonProperties), new FrameworkPropertyMetadata(default(string)));

    /// <summary>
    /// Contains the original Button.ToolTip value to display when the Button.IsEnabled property value is set to true.
    /// </summary>
    public static readonly DependencyProperty OriginalToolTipProperty = originalToolTipPropertyKey.DependencyProperty;

    /// <summary>
    /// Gets the value of the OriginalToolTip property.
    /// </summary>
    /// <param name="dependencyObject">The DependencyObject to return the OriginalToolTip property value from.</param>
    /// <returns>The value of the OriginalToolTip property.</returns>
    public static string GetOriginalToolTip(DependencyObject dependencyObject) => (string)dependencyObject.GetValue(OriginalToolTipProperty);

    /// <summary>
    /// Provides Button controls with an additional tool tip property that only displays when the Button.IsEnabled property value is set to false.
    /// </summary>
    public static readonly DependencyProperty DisabledToolTipProperty = DependencyProperty.RegisterAttached("DisabledToolTip", typeof(string), typeof(ButtonProperties), new UIPropertyMetadata(string.Empty, OnDisabledToolTipChanged));

    /// <summary>
    /// Gets the value of the DisabledToolTip property.
    /// </summary>
    /// <param name="dependencyObject">The DependencyObject to return the DisabledToolTip property value from.</param>
    /// <returns>The value of the DisabledToolTip property.</returns>
    public static string GetDisabledToolTip(DependencyObject dependencyObject) => (string)dependencyObject.GetValue(DisabledToolTipProperty);

    /// <summary>
    /// Sets the value of the DisabledToolTip property.
    /// </summary>
    /// <param name="dependencyObject">The DependencyObject to set the DisabledToolTip property value of.</param>
    /// <param name="value">The value to be assigned to the DisabledToolTip property.</param>
    public static void SetDisabledToolTip(DependencyObject dependencyObject, string value) => dependencyObject.SetValue(DisabledToolTipProperty, value);

    private static void OnDisabledToolTipChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        var button = dependencyObject as Button;
        ToolTipService.SetShowOnDisabled(button, true);
        var oldValue = e.OldValue as string;
        var newValue = e.NewValue as string;

        if (oldValue!.Length == 0 && newValue!.Length > 0)
        {
            button!.IsEnabledChanged += Button_IsEnabledChanged;
        }
        else if (oldValue.Length > 0 && newValue!.Length == 0)
        {
            button!.IsEnabledChanged -= Button_IsEnabledChanged;
        }
    }

    private static void Button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var button = sender as Button;

        if (GetOriginalToolTip(button!) == null)
        {
            button!.SetValue(originalToolTipPropertyKey, button.ToolTip.ToString());
        }

        button!.ToolTip = (bool)e.NewValue ? GetOriginalToolTip(button!) : GetDisabledToolTip(button!);
    }

    #endregion
}
