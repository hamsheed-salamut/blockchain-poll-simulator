using Polly;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Resilience.Polly
{
    public class PollyRetryRegistry
    {
        public static AsyncPolicy GetPolicyAsync(int retryCount, int incrementalCount, string policyKey, ILogger logger)
        {
            return Policy
                   .Handle<Exception>()
                   .WaitAndRetryAsync(retryCount,
                       retryAttempt => TimeSpan.FromSeconds(retryAttempt * incrementalCount),
                       onRetry: (exception, pollyretryCount, context) =>
                       {
                           logger.Error(exception, $@"An error has occured at {exception.Source} with message {exception.Message}
                                for context {context.PolicyKey}. Waiting {pollyretryCount.TotalSeconds.ToString()} seconds for next retry.");
                       }
                   )
                   .WithPolicyKey(policyKey);
        }

        public static Policy GetPolicy(int retryCount, int incrementalCount, string policyKey, ILogger logger)
        {
            return Policy
                .Handle<Exception>()
                .WaitAndRetry(retryCount,
                        retryAttempt => TimeSpan.FromSeconds(retryAttempt * incrementalCount),
                        onRetry: (exception, pollyretryCount, context) =>
                        {
                            logger.Error(exception, $@"An error has occured at {exception.Source} with message {exception.Message}
                                for context {context.PolicyKey}. Waiting {pollyretryCount.TotalSeconds.ToString()} seconds for next retry.");
                        }
                    )
                    .WithPolicyKey(policyKey);
        }
    }
}
