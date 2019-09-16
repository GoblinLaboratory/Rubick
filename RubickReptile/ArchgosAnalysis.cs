using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace RubickReptile
{
    public class ArchgosAnalysis : DataSourceAnalysisInterface
    {
        HtmlWeb web;
        List<Item> source;
        public ArchgosAnalysis()
        {
            //初始化网络请求客户端
            web = new HtmlWeb();
            source = new List<Item>();
        }
        public List<Item> Source { get { return source; } }
        public void Load(int Page)
        {
            int Page1 = Page - 1;
            int Page2 = Page1 * 20;
            string url = "http://archgo.com/index.php?limitstart=" + Page2.ToString();

            //初始化文档
            HtmlDocument doc = web.Load(url);
            //查找节点
            HtmlNodeCollection titleNodes = doc.DocumentNode.SelectNodes("//div[@class='article col-xs-12 col-md-6 ms-item']");
            if (titleNodes != null)
            {
                foreach (var item in titleNodes)
                {
                    Item items = new Item();
                    source.Add(items);
                    


                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(item.OuterHtml);

                    var titleNodes_Title = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='contentpagetitle']");
                    items.Title = titleNodes_Title.InnerText;

                    var titleNodes_img = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='article-content']");
                    foreach (var nNode in titleNodes_img.Descendants("p"))
                    {
                        if (nNode.NodeType == HtmlNodeType.Element)
                        {
                            foreach (var nNode1 in titleNodes_img.Descendants("a"))
                            {
                                if (nNode1.NodeType == HtmlNodeType.Element)
                                {
                                    foreach (var nNode2 in nNode1.Descendants("img"))
                                    {
                                        if (nNode2.NodeType == HtmlNodeType.Element)
                                        {
                                            items.ImageUrl = nNode2.Attributes["src"].Value;
                                        }

                                    }
                                }

                            }
                        }

                    }
                    var titleNodes_Link = item.Element("div"); ;// htmlDoc.DocumentNode.SelectSingleNode("//div");
                    items.Link = "http://archgo.com/index.php"+titleNodes_Link.Attributes["onclick"].Value.Substring(23, titleNodes_Link.Attributes["onclick"].Value.Length - 35);
                    //foreach (var nNode in item.Descendants("div"))
                    //{
                    //    if (nNode.NodeType == HtmlNodeType.Element)
                    //    {
                    //        items.Link = nNode.Attributes["onclick"].Value;
                    //    }

                    //}

                }
            }


        }

    }
}
