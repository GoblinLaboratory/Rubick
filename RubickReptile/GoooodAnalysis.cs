using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RubickReptile
{
    public class GoooodAnalysis : DataSourceAnalysisInterface
    {
        WebClient client;
        //HtmlWeb web;
        List<Item> source;
        public GoooodAnalysis()
        {
            //初始化网络请求客户端
            //web = new HtmlWeb();
            client = new WebClient();
            source = new List<Item>();
        }
        public List<Item> Source { get { return source; } }

        public void Load(int Page)
        {
            string url = "https://dashboard.gooood.cn/api/wp/v2/fetch-posts?page=" + Page.ToString() + "&per_page=18&post_type%5B0%5D=post&post_type%5B1%5D=jobs";

            

            var doc = client.DownloadString(url);
            JArray a = JArray.Parse(doc);
            foreach (var name in a)
            {
                Item items = new Item();
                source.Add(items);
                items.Title = (string)name["title"]["rendered"];
                items.ImageUrl = (string)name["featured_image"]["source_url"];
                items.Link = "https://www.gooood.cn/" + (string)name["slug"] + ".htm";
            }
        }
    }
}
