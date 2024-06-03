using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Xaml.Behaviors;

namespace CodeSculpt.Wpf.Behaviors;
public class ScrollIntoViewBehavior : Behavior<ListBox>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
    }

    private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not ListBox control)
        {
            return;
        }

        if (control.SelectedItem is not null)
        {
            control.Dispatcher.BeginInvoke(DispatcherPriority.Render, () =>
            {
                control.UpdateLayout();
                control.ScrollIntoView(control.SelectedItem);
            });
        }
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
    }
}