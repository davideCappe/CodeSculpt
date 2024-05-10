using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeSculpt.Wpf.Sample.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        TextBoxCommand = new RelayCommand(() =>
        {
            // Command logic
            a = true;

        });
    }

    public RelayCommand TextBoxCommand { get; }

    [ObservableProperty]
    private bool a;
}
