namespace Apexnet.Dispatch.Api.Models
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobSchedule;

    public class SchedulableMessage : ISchedulable
    {
        private readonly Message message;

        private SchedulableMessage(Message message)
        {
            this.message = message;
        }

        Expression<Action> IQueueable.Job
        {
            get
            {
                return () => Console.WriteLine("Hello");
            }
        }

        public DateTimeOffset Schedule
        {
            get
            {
                return this.message.Schedule ?? DateTime.Now;
            }
        }

        public static SchedulableMessage FromMessage(Message message)
        {
            return new SchedulableMessage(message);
        }
    }
}