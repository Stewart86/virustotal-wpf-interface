using System;
using System.Collections.Generic;

namespace CustodioUIApp
{
    public class GetReportResponse
    {
        public DateTime ScanDate { get; set; }

        public Dictionary<string, ScanEngine> Scans { get; set; }

        public string Md5 { get; set; }

        public string Permalink { get; set; }

        public string Positives { get; set; }

        public string ResponseCode { get; set; }

        public string ScanId { get; set; }

        public string Sha1 { get; set; }

        public string Sha256 { get; set; }

        public string Total { get; set; }

        public string VerboseMsg { get; set; }
    }
}