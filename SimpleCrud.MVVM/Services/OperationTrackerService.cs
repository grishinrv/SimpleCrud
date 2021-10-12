using System;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.Services
{
    public static class OperationTrackerService
    {
        internal static void OperationFinished(Operation operation)
        {
            OnOperationFinished.Invoke(operation);
        }

        public static event Action<Operation> OnOperationFinished = _ => {  };
    }
}