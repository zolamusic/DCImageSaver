using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DCUtils
{
    internal class Connection
    {
        private const string UseragentMobile = "Mozilla/5.0 (Linux; Android 4.3; Nexus 7 Build/JSS15Q) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2307.2 Safari/537.36";
        private const string UseragentDesktop = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";

        private readonly Uri _url;
        private readonly Uri _referer;
        private readonly string _useragent;
        private static CookieCollection _loginCookies = new CookieCollection();

        public Connection(string url, string referer, bool isMobile)
        {
            _url = new Uri(url);
            _referer = new Uri(referer);
            _useragent = isMobile ? UseragentMobile : UseragentDesktop;
        }

        public async Task<Response> Get()
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler))
            {
                cookieContainer.Add(_loginCookies);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(_useragent);
                client.DefaultRequestHeaders.Referrer = _referer;

                using (var httpResponse = await client.GetAsync(_url))
                {
                    var responsedHeader = httpResponse.Headers;
                    using (var content = httpResponse.Content)
                    {
                        var responsedBody = await content.ReadAsStringAsync();
                        var response = new Response(responsedHeader, responsedBody);
                        return response;
                    }
                }
            }
        }
        
        public async Task<Response> Post(List<KeyValuePair<string, string>> pairs)
        {
            HttpContent query = new FormUrlEncodedContent(pairs);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler))
            {
                cookieContainer.Add(_loginCookies);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(_useragent);
                client.DefaultRequestHeaders.Referrer = _referer;
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                using (var httpResponse = await client.PostAsync(_url, query))
                {
                    var responsedHeader = httpResponse.Headers;
                    using (var content = httpResponse.Content)
                    {
                        var responsedBody = await content.ReadAsStringAsync();
                        var response = new Response(responsedHeader, responsedBody);
                        return response;
                    }
                }
            }
        }

        public async Task<Response> Post(List<KeyValuePair<string, string>> pairs, Cookie cookie)
        {
            HttpContent query = new FormUrlEncodedContent(pairs);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler))
            {
                cookieContainer.Add(_loginCookies);
                cookieContainer.Add(new Uri($"http://{_url.Host}"), cookie);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(_useragent);
                client.DefaultRequestHeaders.Referrer = _referer;
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                using (var httpResponse = await client.PostAsync(_url, query))
                {
                    var responsedHeader = httpResponse.Headers;
                    using (var content = httpResponse.Content)
                    {
                        var responsedBody = await content.ReadAsStringAsync();
                        var response = new Response(responsedHeader, responsedBody);
                        return response;
                    }
                }
            }
        }
        
        public async Task<CookieContainer> SetCookie(List<KeyValuePair<string, string>> pairs)
        {
            HttpContent query = new FormUrlEncodedContent(pairs);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(_useragent);
                client.DefaultRequestHeaders.Referrer = _referer;
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                using (var httpResponse = await client.PostAsync(_url, query))
                {
                    using (var content = httpResponse.Content)
                    {
                        await content.ReadAsStringAsync();
                        if (cookieContainer.Count == 4)
                            _loginCookies = cookieContainer.GetCookies(new Uri($"http://{_url.Host}"));
                        return cookieContainer;
                    }
                }
            }
        }
    }
}
