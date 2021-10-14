using System;
using System.Threading;
using System.Windows.Input;

namespace SimpleCrud.MVVM.Commands
{
    public class CancelJobCommand : ICommand
    {
        public bool CanExecute(object parameter) => Interlocked.Read(ref _cancelledFlag) == 0;

        private readonly CancellationTokenSource _source;
        private long _cancelledFlag;

        public CancelJobCommand(CancellationTokenSource source)
        {
            _source = source;
        }
        
        public void Execute(object parameter)
        {
            if (Interlocked.Increment(ref _cancelledFlag) == 1)
            {
                using (_source)
                {
                    _source.Cancel();
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}