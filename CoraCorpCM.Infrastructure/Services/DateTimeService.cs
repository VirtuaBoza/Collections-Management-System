using System;
using CoraCorpCM.Application.Interfaces.Infrastructure;

namespace CoraCorpCM.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetTimeUtc()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
