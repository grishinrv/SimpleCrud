using System;

namespace SimpleCrud.MVVM.Services
{
    public static class ApplicationStatusMessagesProvider
    {
        public static void OperationFinished(string message)
        {
            OnStatusMessage.Invoke(message);
        }

        public static event Action<string> OnStatusMessage = _ => {  };
    }
}