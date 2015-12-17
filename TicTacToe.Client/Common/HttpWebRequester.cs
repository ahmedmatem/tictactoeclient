namespace TicTacToe.Client.Common
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    public class HttpWebRequester
    {
        public static WebResponse CreatePOST(string userAccessToken, string servicePath, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GlobalConstants.ServerUri + servicePath);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData == null ? 0 : postData.Length;
            request.Headers.Add("Authorization", "Bearer " + userAccessToken);

            var streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(postData);
            streamWriter.Close();

            return request.GetResponse();
        }

        public static WebResponse CreateGET(string requestUriString, Dictionary<string, string> headers)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            
            try
            {
                return request.GetResponse();
            }
            catch(WebException exc)
            {
                return exc.Response;
            }
        }
    }
}