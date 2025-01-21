using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Url
    {
        [Key]
        public string ShortUrl { get; set; }
        [Required]
        public string OriginalUrl { get; set; }
    }
}