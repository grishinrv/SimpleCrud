using System;
using System.Threading.Tasks;

namespace SimpleCrud.Infrastructure.Job
{
    public delegate Task JobCompletionDelegate(string jobName, JobCompletionStatus completionStatus, 
        Exception exception = null);
}