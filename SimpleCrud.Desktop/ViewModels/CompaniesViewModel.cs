using System;
using SimpleCrud.Storage.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SimpleCrud.MVVM.Commands.Parameters;
using SimpleCrud.MVVM.ViewModels;

namespace SimpleCrud.Desktop.ViewModels
{

    public class CompaniesViewModel : TaskExecutionViewModel
    {
        public CompaniesViewModel() : base()
        {
            Rows = new ObservableCollection<Company>();
            ResultParam = new AsyncFunctionContainer { Job = GetResultAsync, Operation = "Calculating result" };
        }

        public ObservableCollection<Company> Rows { get; }

        private int _result;
        public int Result { get => _result; set => OnSet(ref _result, value); }

        public AsyncFunctionContainer ResultParam { get; }

        private async Task GetResultAsync()
        {
            await Task.Delay(4000);
            throw new Exception("We've fucked up for some reason...");
            Result = new Random().Next(1, 999);
        }
    }
}
