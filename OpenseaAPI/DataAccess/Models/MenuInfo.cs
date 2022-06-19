using System;
using System.ComponentModel.DataAnnotations;

namespace OpenseaAPI.DataAccess.Models
{
    public class MenuInfo
    {
        [Key]
        public int MenuId { get; set; }

        public string ArticleOrder { get; set; }

        public string ImgOrder { get; set; }

        public string DisplayOrder { get; set; }

        public string CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
