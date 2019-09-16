using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
namespace RubickReptile
{
    public class ArchdailyAnalysis : DataSourceAnalysisInterface
    {
        HtmlWeb web;
        List<Item> source;
        public ArchdailyAnalysis()
        {
            //初始化网络请求客户端
            web = new HtmlWeb();
            source = new List<Item>();
        }
        public List<Item> Source { get { return source; }  }
        public void Load(int Page)
        {
            string url;
            if (Page ==1)
            {
                url = "https://www.archdaily.cn/cn";
            }else
            {
                url = "https://www.archdaily.cn/cn/page/" + Page.ToString();
            }
            //初始化文档
            HtmlDocument doc = web.Load(url);
            //查找节点
            //HtmlNode aNode = doc.DocumentNode.SelectSingleNode("//div[@class='afd-post-stream clearfix ']");
            HtmlNodeCollection titleNodes = doc.DocumentNode.SelectNodes("//div[@class='afd-post-stream clearfix ']");
            if (titleNodes != null)
            {
                foreach (var item in titleNodes)
                {
                    //Console.WriteLine(item.InnerText);
                    Item items = new Item();
                    source.Add(items);
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(item.OuterHtml);
                    var titleNodes_Title = htmlDoc.DocumentNode.SelectSingleNode("//h3");
                    if (titleNodes_Title != null)
                    {
                        items.Title = titleNodes_Title.InnerText;
                    }
                    var titleNodes_img = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='afd-post-content ']");
                    foreach (var nNode in titleNodes_img.Descendants("figure"))
                    {
                        if (nNode.NodeType == HtmlNodeType.Element)
                        {
                            foreach (var nNode1 in nNode.Descendants("a"))
                            {
                                if (nNode1.NodeType == HtmlNodeType.Element)
                                {
                                    items.Link = "https://www.archdaily.cn" + nNode1.Attributes["href"].Value;

                                    foreach (var nNode2 in nNode1.Descendants("img"))
                                    {
                                        if (nNode2.NodeType == HtmlNodeType.Element)
                                        {
                                            items.ImageUrl = nNode2.Attributes["data-src"].Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }
    }
}
