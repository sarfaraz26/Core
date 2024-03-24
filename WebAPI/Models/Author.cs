using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string AuthorName { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Address { get; set; }



        // Navigation Property
        //public List<Book> Books { get; set; }

    }
}
