using System;
using System.Globalization;

namespace CustodioUIApp
{
    public class ScanEngine
    {
        private string _update;

        public bool Detected { get; set; }
        public string Result { get; set; }

        public string Update
        {
            get
            {
                DateTime result;
                if (DateTime.TryParseExact(_update, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    return DateTime.ParseExact(_update, "yyyyMMdd",
                            CultureInfo.InvariantCulture).ToString();
                }
                else
                    return result.ToString();
            }
            set => _update = value;
        }

        public string Version { get; set; }
    }
}