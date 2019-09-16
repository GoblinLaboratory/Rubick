using System;
using System.Collections.Generic;
using System.Text;

namespace RubickReptile
{
    public class Item
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 大标题
        /// </summary>
        public string Head { get; set; }
        /// <summary>
        /// 小标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        public string Location { get; set; }
    }
}
