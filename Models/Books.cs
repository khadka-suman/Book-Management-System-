using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    public class Books
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int? BooksId { get; set; }


        [Required]
        [Display(Name ="Book Name")]
        
        public string? Bookname { get; set; }


        [Required]
        [Display(Name = "Book Details")]
        public string? Bookdetails { get; set; }

        [Required]
        
        [Display(Name = "BookGenre")]
        public string? Bookgenre { get; set; }

    



       
    }
}
