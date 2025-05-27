using System.ComponentModel.DataAnnotations;

namespace KiemTraMVC.Models
{
    public class buikhanhtoan
    {
        [Key]
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        
    }
}