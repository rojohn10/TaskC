using TaskC.ViewModels;

namespace TaskC.Views;

public partial class IncidentFormPage : ContentPage
{
    public IncidentFormPage(IncidentFormViewModel vm)
    {
        InitializeComponent();
        
        vm.GetType().GetProperty("Priorities")?.SetValue(vm, new[] { "Low", "Medium", "High" });
        BindingContext = vm;
    }
}