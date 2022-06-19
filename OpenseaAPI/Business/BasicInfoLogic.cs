using OpenseaAPI.Business.Interface;
using OpenseaAPI.DataAccess.Models;
using OpenseaAPI.DataAccess.MyDbContext;
using OpenseaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenseaAPI.Business
{
    public class BasicInfoLogic : IBasicInfoLogic
    {
        private readonly OracleDbContext _dbConn;

        public BasicInfoLogic(OracleDbContext oracleDbContext)
        {
            _dbConn = oracleDbContext;
        }

        public List<CarouselImg> GetCarouselImg() => _dbConn.CarouselImg.ToList();

        public List<DetailsInfo> GetDetailsInfo() => _dbConn.DetailsInfo.ToList();

        public ArticleAndImgInfo GetArticleAndImgInfo(int id)
        {
            try
            {
                var articleAndImgInfos = new ArticleAndImgInfo()
                {
                    ArticleInfos = new List<ArticleInfo>(),
                    ImgInfos = new List<ImgInfo>(),
                    MenuInfo = new MenuInfo()
                };

                articleAndImgInfos.MenuInfo = _dbConn.MenuInfo.FirstOrDefault(x => x.MenuId == id);

                var list = GetDataList(articleAndImgInfos.MenuInfo);

                if (list.ArticleList != null)
                {
                    articleAndImgInfos.ArticleInfos = _dbConn.ArticleInfo.Where(x => list.ArticleList.Contains(x.ArticleId)).ToList();
                }

                if (list.ImgList != null)
                {
                    articleAndImgInfos.ImgInfos = _dbConn.ImgInfo.Where(x => list.ImgList.Contains(x.ImgId)).ToList();
                }

                return articleAndImgInfos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BasicDataOrder GetDataList(MenuInfo menuInfo)
        {
            var basicDataOrder = new BasicDataOrder();
            if (!string.IsNullOrEmpty(menuInfo.ArticleOrder))
            {
                basicDataOrder.ArticleList = new List<int>();
                foreach (var temp in menuInfo.ArticleOrder.Split(','))
                {
                    basicDataOrder.ArticleList.Add(int.Parse(temp));
                }
            }

            if (!string.IsNullOrEmpty(menuInfo.ImgOrder))
            {
                basicDataOrder.ImgList = new List<int>();
                foreach (var temp in menuInfo.ImgOrder.Split(','))
                {
                    basicDataOrder.ImgList.Add(int.Parse(temp));
                }
            }

            return basicDataOrder;
        }
    }
}
