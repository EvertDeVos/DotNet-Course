using System;
using System.Collections.Generic;
using System.Text;

namespace Rmdb.Domain.Model.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime birthDate, DateTime? deceased = null)
        {
            deceased ??= DateTime.Now;
            return (int)((deceased.Value - birthDate).Days / 365.25m);
        }
    }
}
