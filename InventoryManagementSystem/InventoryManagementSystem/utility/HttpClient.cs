using System;
using System.Net;
using System.Net.Http.Headers;

namespace InventoryManagementSystem.utility
{
    public class HttpClient
    {
        private WebClient m_HttpClient;
        public HttpClient()
        {
            //m_HttpClient = new WebClient();
            //m_HttpClient.BaseAddress = new Uri("http://localhost:56418/");
            //m_HttpClient.DefaultRequestHeaders.Accept.Clear();
            //m_HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}