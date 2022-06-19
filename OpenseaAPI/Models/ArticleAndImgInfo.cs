using OpenseaAPI.DataAccess.Models;
using System.Collections.Generic;

namespace OpenseaAPI.Models
{
    public class ArticleAndImgInfo
    {
        public List<ArticleInfo> ArticleInfos { get; set; }

        public List<ImgInfo> ImgInfos { get; set; }

        public MenuInfo MenuInfo { get; set; }
    }
}
