namespace TicTacToe.Client.Common
{
    using System.IO;
    using System.Net;

    public class HttpWebRequester
    {
        public static WebResponse Create(string userAccessToken, string servicePath, string postData)
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
    }
}