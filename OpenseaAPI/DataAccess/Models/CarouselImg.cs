using System;
using System.ComponentModel.DataAnnotations;

namespace OpenseaAPI.DataAccess.Models
{
    public class CarouselImg
    {
        [Key]
        public int CarouselId { get; set; }

        public string CarouselName { get; set; }

        public string ImgAddr { get; set; }

        public string CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
