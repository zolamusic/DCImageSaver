using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DCUtils
{
    public class Connection
    {
        private const string useragentMobile = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_3_3 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13G34 Safari/601.1";
        private const string useragentDesktop = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
        
        private Uri url;
        private Uri referer;
        private string useragent;
        private static CookieCollection loginCookies = new CookieCollection();
        
        public Connection(string url, string referer, bool isMobile)
        {
            this.url = new Uri(url);
            this.referer = new Uri(referer);
            if (isMobile)
            {
                this.useragent = useragentMobile;
            }
            else
            {
                this.useragent = useragentDesktop;
            }
        }

        public async Task<IHtmlDocument> ConnectHtml()
        {
            HtmlParser parser = new HtmlParser();
            CookieContainer cookieContainer = new CookieContainer();
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {
                cookieContainer.Add(loginCookies);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(this.useragent);
                client.DefaultRequestHeaders.Referrer = this.referer;

                using (HttpResponseMessage response = await client.GetAsync(this.url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string getString = await content.ReadAsStringAsync();
                        return parser.Parse(getString);
                    }
                }
            }
        }

        public async Task<IHtmlDocument> ConnectHtml(List<KeyValuePair<string, string>> pairs)
        {
            HtmlParser parser = new HtmlParser();
            HttpContent query = new FormUrlEncodedContent(pairs);
            CookieContainer cookieContainer = new CookieContainer();
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {
                cookieContainer.Add(loginCookies);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(this.useragent);
                client.DefaultRequestHeaders.Referrer = this.referer;
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                using (HttpResponseMessage response = await client.PostAsync(this.url, query))
                {
                    using (HttpContent content = response.Content)
                    {
                        string getString = await content.ReadAsStringAsync();
                        return parser.Parse(getString);
                    }
                }
            }
        }

        public async Task<IHtmlDocument> ConnectString()
        {
            HtmlParser parser = new HtmlParser();
            CookieContainer cookieContainer = new CookieContainer();
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {
                cookieContainer.Add(loginCookies);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(this.useragent);
                client.DefaultRequestHeaders.Referrer = this.referer;

                using (HttpResponseMessage response = await client.GetAsync(this.url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string getString = await content.ReadAsStringAsync();
                        return parser.Parse(getString);
                    }
                }
            }
        }

        public async Task<string> ConnectString(List<KeyValuePair<string, string>> pairs)
        {
            HtmlParser parser = new HtmlParser();
            HttpContent query = new FormUrlEncodedContent(pairs);
            CookieContainer cookieContainer = new CookieContainer();
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {
                cookieContainer.Add(loginCookies);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(this.useragent);
                client.DefaultRequestHeaders.Referrer = this.referer;
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                using (HttpResponseMessage response = await client.PostAsync(this.url, query))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public async Task<CookieCollection> GetLoginCookie(List<KeyValuePair<string, string>> pairs)
        {
            HttpContent query = new FormUrlEncodedContent(pairs);

            CookieContainer cookieContainer = new CookieContainer();
            using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(this.useragent);
                client.DefaultRequestHeaders.Referrer = this.referer;
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                using (HttpResponseMessage response = await client.PostAsync(this.url, query))
                {
                    using (HttpContent content = response.Content)
                    {
                        Task<string> getStringTask = content.ReadAsStringAsync();
                        string result = await getStringTask;
                    }
                    loginCookies = cookieContainer.GetCookies(new Uri("http://" + this.url.Host));
                    return cookieContainer.GetCookies(this.url);
                }
            }
        }
    }
}
