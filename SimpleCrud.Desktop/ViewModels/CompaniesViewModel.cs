using System;
using SimpleCrud.Storage.Models;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using SimpleCrud.Infrastructure.Job;
using SimpleCrud.MVVM.ViewModels;

namespace SimpleCrud.Desktop.ViewModels
{
    public class CompaniesViewModel : JobViewModel
    {
        public override string JobSourceName { get; } = "Companies view";
        public CompaniesViewModel() : base()
        {
            Rows = new ObservableCollection<Company>();
            FailedResultParam = CreateJob(GetErrorAsync, "Generating exception..." ); // todo completion callback
            SuccessResultParam = CreateJob(GetResultAsync, "Calculating result...", null, true ); // todo completion callback
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
        }
        private async Task GetResultAsync(IProgress<JobStage> progress, CancellationToken token)
        {
            await Task.Delay(7000);
            Result = new Random().Next(1, 999);
        }
    }
}
