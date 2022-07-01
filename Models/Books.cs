using Book.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    public class Books
    {
       // [ScaffoldColumn(false)]
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int BooksId { get; set; }


        [Required]
        [Display(Name ="Book Name")]
        
        public string? Bookname { get; set; }


        [Required]
        [Display(Name = "Book Details")]
        public string? Bookdetails { get; set; }

        [Required]
        
        [Display(Name = "BookGenre")]
        public string? Bookgenre { get; set; }


        [ForeignKey("Category")]
        public int Id { get; set; }
        public string Name { get; set; }    
       // public virtual Category Category { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
        public virtual Category Category { get; set; }



        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
