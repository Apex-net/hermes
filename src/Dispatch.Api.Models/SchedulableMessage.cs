namespace Apexnet.Dispatch.Api.Models
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobSchedule;

    public class SchedulableMessage : ISchedulable
    {
        private SchedulableMessage()
        {
        }

        public DateTimeOffset Schedule { get; set; }

        public Expression<Action> Job { get; set; }

        public static SchedulableMessage FromMessage(Message message)
        {
            return new SchedulableMessage { Schedule = message.Schedule ?? DateTime.Now, Job = () => Queue(message), };
        }

        public static void Queue(Message message)
        {
            Console.WriteLine(message.Emails);
        }
    }
}