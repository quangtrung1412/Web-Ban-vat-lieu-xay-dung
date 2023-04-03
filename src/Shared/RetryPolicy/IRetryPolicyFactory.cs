using Polly.Retry;

namespace App.Shared.RetryPolicy;
public interface IRetryPolicyFactory
{
    AsyncRetryPolicy CreateAsyncRetryPolicy<TException>(int retries, string prefix = nameof(CreateAsyncRetryPolicy))
        where TException : Exception;
    IRetryPolicy CreateRetryPolicy<TException>(int retries, string prefix = nameof(CreateRetryPolicy))
    where TException : Exception;
    AsyncRetryPolicy CreateWaitAsyncRetryPolicy<TException>(int retries, int milliseconds, string prefix = nameof(CreateWaitAsyncRetryPolicy))
    where TException : Exception;
    IRetryPolicy CreateWaitRetryPolicy<TException>(int retries, int milliseconds, string prefix = nameof(CreateWaitRetryPolicy))
    where TException : Exception;
    AsyncRetryPolicy CreateWaitForeverAsyncRetryPolicy<TException>(int milliseconds, string prefix = nameof(CreateWaitForeverAsyncRetryPolicy))
    where TException : Exception;
    IRetryPolicy CreateWaitForeverRetryPolicy<TException>(int milliseconds, string prefix = nameof(CreateWaitForeverRetryPolicy))
    where TException : Exception;
    AsyncRetryPolicy CreateForeverAsyncRetryPolicy<TException>(string prefix = nameof(CreateForeverAsyncRetryPolicy))
    where TException : Exception;
    IRetryPolicy CreateForeverRetryPolicy<TException>(string prefix = nameof(CreateForeverRetryPolicy))
    where TException : Exception;
}