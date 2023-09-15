namespace JobService.Components;

using System;
using MassTransit;


public class ConvertVideoJobConsumerDefinition :
    ConsumerDefinition<ConvertVideoJobConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<ConvertVideoJobConsumer> consumerConfigurator, IRegistrationContext context)
    {
        consumerConfigurator.ConcurrentMessageLimit = 1;

        consumerConfigurator.Options<JobOptions<ConvertVideo>>(options => options
            .SetRetry(r => r.Interval(3, TimeSpan.FromSeconds(30)))
            .SetJobTimeout(TimeSpan.FromMinutes(10)));

        consumerConfigurator.Options<JobOptions<ConvertVideo2>>(options => options
            .SetRetry(r => r.Interval(3, TimeSpan.FromSeconds(30)))
            .SetJobTimeout(TimeSpan.FromMinutes(10)));
    }
}