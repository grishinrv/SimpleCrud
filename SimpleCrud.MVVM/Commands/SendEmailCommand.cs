using System;
using System.Diagnostics;
using System.Windows.Input;

namespace SimpleCrud.MVVM.Commands
{
    public class SendEmailCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        private readonly string _emailAddress;
        private readonly string _subject;
        
        public SendEmailCommand(string emailAddress, string subject)
        {
            _emailAddress = emailAddress;
            _subject = subject;
        }
        
        public void Execute(object parameter)
        {
            if (parameter!= null)
                SendSupportEmail(_emailAddress, _subject, parameter.ToString());
        }
        
        private void SendSupportEmail(string emailAddress, string subject, string body)
        {
            string mailto = $"mailto:{emailAddress}?Subject={subject}&Body={body}";
            // mailto = Uri.EscapeUriString(mailto);
            using (Process process = new Process())
            {
                ProcessStartInfo si = new ProcessStartInfo(mailto) {UseShellExecute = true };
                process.StartInfo = si;
                process.Start();
            }
            // Process.Start(mailto);
        }

        public event EventHandler? CanExecuteChanged;
    }
}