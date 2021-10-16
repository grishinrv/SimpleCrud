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
            FailedResultParam = CreateJob(GetErrorAsync, "Generating exception..." );
            SuccessResultParam = CreateJob(GetResultAsync, "Calculating result...", true );
            AutoCloseProgressDialogOnSuccess = true; //todo get from config
        }

        public ObservableCollection<Company> Rows { get; }

        private int _result;
        public int Result { get => _result; set => OnSet(ref _result, value); }

        public JobData FailedResultParam { get; }
        public JobData SuccessResultParam { get; }

        private async Task GetErrorAsync(IProgress<JobStage> progress, CancellationToken token)
        {
            await Task.Delay(2000);
            throw new Exception("We've fucked up for some reason...");
            Result = new Random().Next(1, 999);
        }
        private async Task GetResultAsync(IProgress<JobStage> progress, CancellationToken token)
        {
            await Task.Delay(7000);
            Result = new Random().Next(1, 999);
        }
    }
}
