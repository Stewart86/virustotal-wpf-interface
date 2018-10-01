public static class Constants
{
    public static class MainWindow
    {
        // Output statement for calculated numbers
        public const string NEW_TEXT_MSG_1 = " ways to climb this ";

        public const string NEW_TEXT_MSG_2 = " steps ladder with 1 or 2 steps combinations";

        // OnPropertyChange arguments
        public const string OPC_SCANNER_MSG = "ScannerMessage";

        public const string OPC_TEXT_MSG = "TextMessage";

        // Placeholder for output statement
        public const string TEXT_MSG = "Number of ways to climb the ladder..";
    }

    public static class ApiCalls
    {
        // VirusTotal Api root
        public const string API_ROOT = "https://www.virustotal.com/vtapi/v2/";

        // API key (do not expose to anyone)
        public static readonly string API_KEY = "YOUR VIRUSTOTAL API KEY HERE";

        // Placeholders, not much use strings
        public const string MESSAGE = "Get report requested";

        public const string RESPONSE_CODE = "not fetched";

        public const string SHA_256 = "No Sha256";

        // VirusTotal APIs endpoints
        public const string API_REPORT_ENDPOINT = "file/report";

        public const string API_RESCAN_ENDPOINT = "file/rescan";

        public const string API_SCAN_ENDPOINT = "file/scan";

        // REST Parameters
        public const string API_KEY_PARAM = "apikey";

        public const string FILE_PARAM = "file";

        public const string RESOURCE_PARAM = "resource";

        // File extensions for saving of files
        public const string FILE_EXTENSIONS = "JSON file (*.json)|*.json|C# file (*.cs)|*.cs| Text file(*.txt)|*.txt";

        // MessageBoxes messages
        public const string MSG_FROM_SERVER = "Message from server: ";

        public const string POST_RESCAN_MSG = "Posted for re-scanning, please check back in 3 - 5 minutes by opening the same file again.\n\nScan ID: ";

        public const string POST_SCAN_MSG_2 = "\n\nPosted for scanning, please check back in 3 - 5 minutes by opening the same file again.\n\nScan ID: ";

        public const string SAVE_OR_RESCAN = "\n\nWould you like to save report?\n\n Yes to save file, No to re-scan and Cancel to terminate request.";

        public const string SERVER_BUSY_MSG = "Server is busy, tring again later..";

        public const string STILL_SCANNING = "\n\nStill scanning..";

        // Headers for MessageBoxes
        public const string RETRIEVE_OR_RESCAN_HEADER = "Retrieve or re-scan";

        public const string SCANNING_HEADER = "Scanning";
    }

    public static class Errors
    {
        // Exceptions error messages
        public const string EXCEPT_DIVIDE_BY_ZERO = "Seriously? 0 step stair? Try better.";

        public const string EXCEPT_ARG_OUT_OF_RANGE = "Explain how negative steps stairs work please.\nInput number must be greater than zero(0)\n\n";

        public const string EXCEPT_ARG_OUT_OF_RANGE_PARAM = "Enter number of steps";

        public const string EXCEPT_OVERFLOW = "I might be a computer but the number you've given is beyond my capability, Try number lesser than 75676";

        // Error message for TryParse
        public const string INT_PARSE_ERROR_MSG = "Unable to parse. Please use only interger number";
    }
}
