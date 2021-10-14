using System;
using SimpleCrud.Storage.Models;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using SimpleCrud.MVVM;
using SimpleCrud.MVVM.Commands.Parameters;
using SimpleCrud.MVVM.ViewModels;

namespace SimpleCrud.Desktop.ViewModels
{
    public class CompaniesViewModel : TaskExecutionViewModel
    {
        public override string ActivityName { get; } = "Companies view";
        public CompaniesViewModel() : base()
        {
            Rows = new ObservableCollection<Company>();
            ResultParam = CreateJob(GetResultAsync, "Calculating result" );
        }

        public ObservableCollection<Company> Rows { get; }

        private int _result;
        public int Result { get => _result; set => OnSet(ref _result, value); }

        public AsyncFunctionContainer ResultParam { get; }

        private async Task GetResultAsync(IProgress<JobStage> progress, CancellationToken token)
        {
            await Task.Delay(15000);
            //throw new Exception("We've fucked up for some reason...");
            Result = new Random().Next(1, 999);
        }
    }
}
