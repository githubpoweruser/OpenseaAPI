using OpenseaAPI.DataAccess.Models;
using OpenseaAPI.Models;
using System.Collections.Generic;

namespace OpenseaAPI.Business.Interface
{
    public interface IBasicInfoLogic
    {
        List<CarouselImg> GetCarouselImg();
        List<DetailsInfo> GetDetailsInfo();
        ArticleAndImgInfo GetArticleAndImgInfo(int id);
    }
}
