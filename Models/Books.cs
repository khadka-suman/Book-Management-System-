using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    public class Books
    {
        //[key]
        public int BookId { get; set; }

        [Required]
        [Display(Name ="Book Name")]
        [StringLength(20, MinimumLength =2)]
        public string Bookname { get; set; }


        [Required]
        [StringLength(20, MinimumLength =4)]
        [Display(Name = "Book Details")]
        public string Bookdetails { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Book Genre")]
        public string Bookgenre;


       // public int UId { get; set; }
       // [FoerignKey("UId")]
       // public virtual Books Books { get; set; }


    }
}
