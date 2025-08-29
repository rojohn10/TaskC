using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskC.Models;
using TaskC.Services;
using TaskC.Validation;

namespace TaskC.ViewModels
{
    public class IncidentFormViewModel : INotifyPropertyChanged
    {
        private readonly IIncidentService _service;
        private readonly IFormValidator _validator;
        public IncidentForm Model { get; } = new();


        public string[] Priorities { get; set; } = new[] { "Low", "Medium", "High" };


        private string _statusMessage = string.Empty;
        public string StatusMessage { get => _statusMessage; set { _statusMessage = value; OnPropertyChanged(); } }


        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(); ((Command)SubmitCommand).ChangeCanExecute(); } }


        public ICommand SubmitCommand { get; }


        public IncidentFormViewModel(IIncidentService service, IFormValidator validator)
        {
            _service = service; _validator = validator;
            SubmitCommand = new Command(async () => await SubmitAsync(), () => !IsBusy);
        }


        private async Task SubmitAsync()
        {
            var error = _validator.Validate(Model);
            if (error != null)
            {
                StatusMessage = error; return;
            }


            try
            {
                IsBusy = true;
                StatusMessage = "Submitting...";
                var (ok, msg) = await _service.CreateAsync(Model);
                StatusMessage = msg;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unexpected error: {ex.Message}";
            }
            finally { IsBusy = false; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
