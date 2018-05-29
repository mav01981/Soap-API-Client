using System.IO;
using System.Net;
using System;

namespace WebClient
{
    public static class SoapWebClient
    {
        public static string Post(string url, string xmlRequest)
        {
            Uri Uri = new Uri(url);

            string responseXML = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(xmlRequest);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                responseXML = new StreamReader(responseStream).ReadToEnd();

            }
            return responseXML;
        }
        public static string Post(string url, string xmlRequest, string username, string password)
        {
            Uri Uri = new Uri(url);

            string responseXML = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(xmlRequest);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";

            NetworkCredential myNetworkCredential = new NetworkCredential(username, password);

            CredentialCache myCredentialCache = new CredentialCache();
            myCredentialCache.Add(Uri, "Basic", myNetworkCredential);
            request.PreAuthenticate = true;
            request.Credentials = myCredentialCache;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                responseXML = new StreamReader(responseStream).ReadToEnd();
            }
            return responseXML;
        }
    }
}
