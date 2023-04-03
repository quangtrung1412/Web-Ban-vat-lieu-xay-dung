using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace App.Shared.RetryPolicy;

public class RetryPolicyFactory : IRetryPolicyFactory
{
 private readonly ILogger<RetryPolicyFactory> _logger;

    public RetryPolicyFactory(ILogger<RetryPolicyFactory> logger)
    {
        _logger = logger;
    }
    public AsyncRetryPolicy CreateAsyncRetryPolicy<TException>(int retries, string prefix = nameof(CreateAsyncRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().RetryAsync(retries, (ex, retry)
        => LogWarning(ex, retry, retries, prefix));
    }

    public IRetryPolicy CreateRetryPolicy<TException>(int retries, string prefix = nameof(CreateRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().Retry(retries, (ex, retry)
        => LogWarning(ex, retry, retries, prefix));
    }

    public AsyncRetryPolicy CreateWaitAsyncRetryPolicy<TException>(int retries, int milliseconds, string prefix = nameof(CreateWaitAsyncRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().WaitAndRetryAsync(retries, attempt => TimeSpan.FromMilliseconds(milliseconds),
        (ex, timeSpan, retry, ctx) => LogWarning(ex, retry, retries, prefix));
    }

    public IRetryPolicy CreateWaitRetryPolicy<TException>(int retries, int milliseconds, string prefix = nameof(CreateWaitRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().WaitAndRetry(retries, attempt => TimeSpan.FromMilliseconds(milliseconds),
        (ex, timeSpan, retry, ctx) => LogWarning(ex, retry, retries, prefix));
    }

    public AsyncRetryPolicy CreateWaitForeverAsyncRetryPolicy<TException>(int milliseconds, string prefix = nameof(CreateWaitForeverAsyncRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().WaitAndRetryForeverAsync((retry, context) => TimeSpan.FromMilliseconds(milliseconds),
        (ex, retry, timeSpan, context) => LogWarning(ex, retry, int.MaxValue, prefix));
    }

    public IRetryPolicy CreateWaitForeverRetryPolicy<TException>(int milliseconds, string prefix = nameof(CreateWaitForeverRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().WaitAndRetryForever((retry, context) => TimeSpan.FromMilliseconds(milliseconds),
        (ex, retry, timeSpan, context) => LogWarning(ex, retry, int.MaxValue, prefix));
    }

    public AsyncRetryPolicy CreateForeverAsyncRetryPolicy<TException>(string prefix = nameof(CreateForeverAsyncRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().RetryForeverAsync((ex, retry, ctx) => LogWarning(ex, retry, int.MaxValue, prefix));
    }

    public IRetryPolicy CreateForeverRetryPolicy<TException>(string prefix = nameof(CreateForeverRetryPolicy))
    where TException : Exception
    {
        return Policy.Handle<TException>().RetryForever((ex, retry, ctx) => LogWarning(ex, retry, int.MaxValue, prefix));
    }

    private void LogWarning(Exception ex, int retry, int retries, string prefix)
    {
        _logger.LogWarning(ex, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}",
                        prefix, ex.GetType().Name, ex.Message, retry, retries);
    }
}