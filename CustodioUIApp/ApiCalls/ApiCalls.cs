using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.IO;
using System.Windows;

namespace CustodioUIApp
{
    public class ApiCalls
    {
        private static RestClient client = new RestClient(Constants.ApiCalls.API_ROOT);

        private static string message = Constants.ApiCalls.MESSAGE;
        private static string responseCode = Constants.ApiCalls.RESPONSE_CODE;
        private static string sha256 = Constants.ApiCalls.SHA_256;

        // Conditional statements to check if file already been checked before. if exist prompt to
        // rescan or retrieve, else post scan request
        public static void ApiCheckIfFileExist(string sha256HashSting, string fileName)
        {
            var request = new RestRequest(Constants.ApiCalls.API_REPORT_ENDPOINT, Method.GET);

            request.AddParameter(Constants.ApiCalls.API_KEY_PARAM, Constants.ApiCalls.API_KEY);
            request.AddParameter(Constants.ApiCalls.RESOURCE_PARAM, sha256HashSting);

            IRestResponse<GetReportResponse> response = client.Execute<GetReportResponse>(request);

            try
            {                                                               // When sending request to rapidly, Null reference always thrown.
                responseCode = response.Data.ResponseCode;
                message = response.Data.VerboseMsg;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Constants.ApiCalls.SERVER_BUSY_MSG);
            }

            if (responseCode == "1")                                        // present and it could be retrieved or re-scanned it will be 1
            {
                AskRetrieveOrRescan(sha256HashSting, response);
            }
            else if (responseCode == "-2")                                  // requested item is still queued for analysis it will be -2
            {
                MessageBox.Show(
                    Constants.ApiCalls.MSG_FROM_SERVER +
                    message +
                    Constants.ApiCalls.STILL_SCANNING,
                    Constants.ApiCalls.SCANNING_HEADER,
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }
            else if (responseCode == "0")                                   // not present in VirusTotal's dataset this result will be 0
            {
                PostScanRequest(fileName);
            }
        }

        private static void AskRetrieveOrRescan(string sha256HashSting, IRestResponse<GetReportResponse> response)
        {
            MessageBoxResult result = MessageBox.Show(Constants.ApiCalls.MSG_FROM_SERVER + message + Constants.ApiCalls.SAVE_OR_RESCAN,
              Constants.ApiCalls.RETRIEVE_OR_RESCAN_HEADER, MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);

            switch (result)
            {
                case MessageBoxResult.Cancel:
                    break;

                case MessageBoxResult.Yes:
                    SaveToFile(response.Content);
                    break;

                case MessageBoxResult.No:
                    PostRescanRequest(sha256HashSting);
                    break;

                default:
                    break;
            }
        }

        private static void PostRescanRequest(string resource)
        {
            var request = new RestRequest(Constants.ApiCalls.API_RESCAN_ENDPOINT, Method.POST);

            request.AddParameter(Constants.ApiCalls.API_KEY_PARAM, Constants.ApiCalls.API_KEY);
            request.AddParameter(Constants.ApiCalls.RESOURCE_PARAM, resource);

            IRestResponse<ScanResponse> response = client.Execute<ScanResponse>(request);

            try
            {
                sha256 = response.Data.Sha256;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Constants.ApiCalls.SERVER_BUSY_MSG);
            }

            MessageBox.Show(Constants.ApiCalls.POST_RESCAN_MSG + sha256,
                Constants.ApiCalls.SCANNING_HEADER, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static void PostScanRequest(string fileName)
        {
            var request = new RestRequest(Constants.ApiCalls.API_SCAN_ENDPOINT, Method.POST);

            request.AddParameter(Constants.ApiCalls.API_KEY_PARAM, Constants.ApiCalls.API_KEY);
            request.AddFile(Constants.ApiCalls.FILE_PARAM, fileName);

            IRestResponse<ScanResponse> response = client.Execute<ScanResponse>(request);

            try
            {
                message = response.Data.VerboseMsg;
                sha256 = response.Data.Sha256;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Constants.ApiCalls.SERVER_BUSY_MSG);
            }

            MessageBox.Show(Constants.ApiCalls.MSG_FROM_SERVER + message + Constants.ApiCalls.POST_SCAN_MSG_2 + sha256,
                Constants.ApiCalls.SCANNING_HEADER, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static void SaveToFile(string content)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = Constants.ApiCalls.FILE_EXTENSIONS
            };

            JToken parsingJson = JToken.Parse(content);

            string formattedJson = parsingJson.ToString(Formatting.Indented);

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, formattedJson);
        }
    }
}