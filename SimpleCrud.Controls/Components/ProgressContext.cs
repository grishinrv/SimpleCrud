using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.ValueBoxes;
using SimpleCrud.Infrastructure.Job;

namespace SimpleCrud.Controls.Components
{
    public class ProgressContext : FrameworkElement
    {
        #region dependencyproperty declarations

        public static readonly DependencyProperty JobDataProperty = DependencyProperty.Register(
            nameof(JobData), typeof(JobData), typeof(ProgressContext),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnJobAssigned));

        public static readonly DependencyProperty ProgressStreamProperty = DependencyProperty.Register(
            nameof(ProgressStream), typeof(IProgress<JobStage>), typeof(ProgressContext),
            new PropertyMetadata(default(IProgress<JobStage>)));

        public static readonly DependencyProperty CancellationTokenSourceProperty = DependencyProperty.Register(
            nameof(CancellationTokenSource), typeof(CancellationTokenSource), typeof(ProgressContext),
            new PropertyMetadata(default(CancellationTokenSource)));

        public static readonly DependencyProperty CanCancelProperty = DependencyProperty.Register(
            nameof(CanCancel), typeof(bool), typeof(ProgressContext),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty JobTitleProperty = DependencyProperty.Register(
            nameof(JobTitle), typeof(string), typeof(ProgressContext), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty JobStatusProperty = DependencyProperty.Register(
            nameof(JobStatus), typeof(JobCompletionStatus), typeof(ProgressContext),
            new FrameworkPropertyMetadata( JobCompletionStatusBoxes.DefaultBox, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnJobStatusChanged));

        public static readonly DependencyProperty FinishJobOnSuccessProperty = DependencyProperty.Register(
            nameof(FinishJobOnSuccess), typeof(bool), typeof(ProgressContext), new PropertyMetadata(BooleanBoxes.FalseBox));

        #endregion

        #region callbacks

        private static async void OnJobAssigned(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressContext context = d as ProgressContext;
            JobData data = e.NewValue as JobData;
            if (data != null)
            {
                IProgress<JobStage> stream = (IProgress<JobStage>)context.GetValue(ProgressStreamProperty);
                CancellationTokenSource tokenSource = (CancellationTokenSource)context.GetValue(CancellationTokenSourceProperty);
                
                Task job = data.Job.Invoke(stream, tokenSource.Token);
                if (!job.IsCompleted)
                {
                    context.SetValue(CanCancelProperty, BooleanBoxes.Box(data.IsCancellable));
                    context.SetValue(JobTitleProperty, data.Title);
                    JobCompletionStatus status = JobCompletionStatus.InProgress;
                    context.SetValue(JobStatusProperty, JobCompletionStatusBoxes.InProgressBox);
                    Exception error = null;
                    try
                    {
                        await job;
                        bool shouldFinish = (bool)context.GetValue(FinishJobOnSuccessProperty);
                        if (shouldFinish)
                            status = JobCompletionStatus.Default;
                        else
                            status = JobCompletionStatus.CompetedSuccessfully;
                    }
                    catch (TaskCanceledException)
                    {
                        status = JobCompletionStatus.Cancelled;
                    }
                    catch (Exception ex)
                    {
                        error = ex;
                        status = JobCompletionStatus.CompetedWithError;
                    }

                    context.SetValue(JobStatusProperty, JobCompletionStatusBoxes.Box(status));

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

        private static void OnJobStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            JobCompletionStatus newStatus = (JobCompletionStatus)e.NewValue;
            if (newStatus == JobCompletionStatus.Default || newStatus == JobCompletionStatus.Cancelled)
            {
                d.SetValue(JobDataProperty, null);
            }
        }

        #endregion

        #region dependency properties accessors

        public CancellationTokenSource CancellationTokenSource
        {
            get { return (CancellationTokenSource)GetValue(CancellationTokenSourceProperty); }
            set { SetValue(CancellationTokenSourceProperty, value); }
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
            set { SetValue(CanCancelProperty, BooleanBoxes.Box(value)); }
        }

        public string JobTitle
        {
            get { return (string)GetValue(JobTitleProperty); }
            set { SetValue(JobTitleProperty, value); }
        }

        public JobCompletionStatus JobStatus
        {
            get { return (JobCompletionStatus)GetValue(JobStatusProperty); }
            set { SetValue(JobStatusProperty, JobCompletionStatusBoxes.Box(value)); }
        }

        public bool FinishJobOnSuccess
        {
            get { return (bool)GetValue(FinishJobOnSuccessProperty); }
            set { SetValue(FinishJobOnSuccessProperty, BooleanBoxes.Box(value)); }
        }
        #endregion
    }
}