using System;

namespace CoraCorpCM.Common
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetTimeUtc()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
