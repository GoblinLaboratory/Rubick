using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace RubickReptile
{
    public  class ikukuAnalysis: DataSourceAnalysisInterface
    {
        HtmlWeb web;
        List<Item> source;
        public ikukuAnalysis()
        {
            //初始化网络请求客户端
            web = new HtmlWeb();
            source = new List<Item>();
        }
        public List<Item> Source { get { return source; } }
        public void Load(int Page)
        {
            string url = "http://www.ikuku.cn/wp-admin/admin-ajax.php?action=infinite_scroll&pagina=" + Page.ToString()+ "&loop=loop&postType=project%2Cproject_report%2Carticle%2Cactivity%2Cphotography%2Cperson%2Cvideo%2Caudio%2Cbook%2Cbidding%2Cjob%2Cconcept%2Cmagazine%2Cpost&postid=&term_id=&query_value=0&is_index=1";
            //初始化文档
            HtmlDocument doc = web.Load(url);
            //查找节点
            HtmlNodeCollection titleNodes = doc.DocumentNode.SelectNodes("//div[@class='post_item']");
            if (titleNodes != null)
            {
                foreach (var item in titleNodes)
                {
                    Item items = new Item();
                    source.Add(items);

                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(item.OuterHtml);

                    ////图片
                    var titleNodes_Img = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='post_image']");

                    foreach (var nNode1 in titleNodes_Img.Descendants("a"))
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

                    ///标题
                    var titleNodes_Title = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='post_title']");
                    items.Title = titleNodes_Title.InnerText.Trim();
                    foreach (var nNode1 in titleNodes_Title.Descendants("div"))
                    {
                        if (nNode1.NodeType == HtmlNodeType.Element)
                        {
                            foreach (var nNode2 in nNode1.Descendants("a"))
                            {
                                if (nNode2.NodeType == HtmlNodeType.Element)
                                {
                                    items.Link = nNode2.Attributes["href"].Value;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
