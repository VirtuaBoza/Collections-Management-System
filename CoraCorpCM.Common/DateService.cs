using System;

namespace CoraCorpCM.Common
{
    public class DateService : IDateService
    {
        public DateTime GetCurrentServerTime()
        {
            return DateTime.Now;
        }
    }
}
