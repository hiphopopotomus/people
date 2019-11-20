using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Util
{
    public class IdGenerator
    {
        private static int _maxsequence = 9999;
        private static int _increment = 409;

        private Random _random = new Random();
        private int sequence = 0;

        public string GetMonotonicId(string prefix)
        {
            sequence = (sequence % (_maxsequence - _increment)) + _random.Next(0, _increment);

            return string.Format(CultureInfo.InvariantCulture, "{0}-{1}-{2}",
                    prefix,
                    DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmssffffK", CultureInfo.InvariantCulture),
                    sequence.ToString("D4", CultureInfo.InvariantCulture)
                );
        }
    }
}
