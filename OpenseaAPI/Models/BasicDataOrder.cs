using System.Collections.Generic;

namespace OpenseaAPI.Models
{
    public class BasicDataOrder
    {
        /// <summary>
        /// 文章排序
        /// </summary>
        public List<int> ArticleList { get; set; }

        /// <summary>
        /// 图片排序
        /// </summary>
        public List<int> ImgList { get; set; }
    }
}
