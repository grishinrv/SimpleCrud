using System;
using SimpleCrud.MVVM.Commands.Parameters;

namespace SimpleCrud.MVVM.Services
{
    public static class OperationTrackerService
    {
        internal static void OperationFinished(OperationData operationData)
        {
            OnOperationFinished.Invoke(operationData);
        }

        public static event Action<OperationData> OnOperationFinished = _ => {  };
    }
}