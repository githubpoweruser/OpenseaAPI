using System.ComponentModel.DataAnnotations;

namespace OpenseaAPI.DataAccess.Models
{
    public class Test
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Addr { get; set; }
    }
}
