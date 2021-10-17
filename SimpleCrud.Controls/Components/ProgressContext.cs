using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.ValueBoxes;
using SimpleCrud.Infrastructure.Job;

namespace SimpleCrud.Controls.Components
{
    public class ProgressContext : DependencyObject
    {
        #region dependencyproperty declarations

        public static readonly DependencyProperty JobDataProperty = DependencyProperty.Register(
            nameof(JobData), typeof(JobData), typeof(ProgressContext),
            new FrameworkPropertyMetadata(null, OnJobAssigned));

        public static readonly DependencyProperty ProgressStreamProperty = DependencyProperty.Register(
            nameof(ProgressStream), typeof(IProgress<JobStage>), typeof(ProgressContext),
            new PropertyMetadata(default(IProgress<JobStage>)));

        public static readonly DependencyProperty CancellationTokenProperty = DependencyProperty.Register(
            nameof(CancellationToken), typeof(CancellationToken), typeof(ProgressContext),
            new PropertyMetadata(default(CancellationToken)));

        public static readonly DependencyProperty CanCancelProperty = DependencyProperty.Register(
            nameof(CanCancel), typeof(bool), typeof(ProgressContext),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty JobTitleProperty = DependencyProperty.Register(
            nameof(JobTitle), typeof(string), typeof(ProgressContext), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty JobStatusProperty = DependencyProperty.Register(
            nameof(JobStatus), typeof(JobCompletionStatus), typeof(ProgressContext),
            new PropertyMetadata(JobCompletionStatus.Default));

        #endregion

        #region callbacks

        private static async void OnJobAssigned(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressContext context = d as ProgressContext;
            JobData data = e.NewValue as JobData;
            if (data != null)
            {
                IProgress<JobStage> stream = (IProgress<JobStage>)context.GetValue(ProgressStreamProperty);
                CancellationToken token = (CancellationToken)context.GetValue(CancellationTokenProperty);

                Task job = data.Job.Invoke(stream, token);
                if (!job.IsCompleted)
                {
                    context.SetValue(CanCancelProperty, BooleanBoxes.Box(data.IsCancellable));
                    context.SetValue(JobTitleProperty, data.Title);
                    JobCompletionStatus status = JobCompletionStatus.InProgress;
                    context.SetValue(JobStatusProperty, status);
                    Exception error = null;
                    try
                    {
                        status = await context.Execute(job);
                    }
                    catch (Exception ex)
                    {
                        error = ex;
                        status = JobCompletionStatus.CompetedWithError;
                    }

                    context.SetValue(JobStatusProperty, status);

                    if (data.CompletedCallBack != null)
                    {
                        try
                        {
                            await data.CompletedCallBack(data.Title, status, error);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private async Task<JobCompletionStatus> Execute(Task task)
        {
            await task;
            if (task.IsCanceled)
                return JobCompletionStatus.Cancelled;
            return JobCompletionStatus.CompetedSuccessfully;
        }

        #endregion

        #region dependency properties accessors

        public CancellationToken CancellationToken
        {
            get { return (CancellationToken)GetValue(CancellationTokenProperty); }
            set { SetValue(CancellationTokenProperty, value); }
        }

        public JobData JobData
        {
            get { return (JobData)GetValue(JobDataProperty); }
            set { SetValue(JobDataProperty, value); }
        }

        public IProgress<JobStage> ProgressStream
        {
            get { return (IProgress<JobStage>)GetValue(ProgressStreamProperty); }
            set { SetValue(ProgressStreamProperty, value); }
        }

        public bool CanCancel
        {
            get { return (bool)GetValue(CanCancelProperty); }
            set { SetValue(CanCancelProperty, value); }
        }

        public string JobTitle
        {
            get { return (string)GetValue(JobTitleProperty); }
            set { SetValue(JobTitleProperty, value); }
        }

        public JobCompletionStatus JobStatus
        {
            get { return (JobCompletionStatus)GetValue(JobStatusProperty); }
            set { SetValue(JobStatusProperty, value); }
        }

        #endregion
    }
}