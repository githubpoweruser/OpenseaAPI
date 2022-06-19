using System;
using System.ComponentModel.DataAnnotations;

namespace OpenseaAPI.DataAccess.Models
{
    public class DetailsInfo
    {
        [Key]
        public int DetailsId { get; set; }

        public string DetailsTitle { get; set; }

        public string DetailsContent { get; set; }

        public string LinkType { get; set; }

        public string LinkAddr { get; set; }

        public string CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
