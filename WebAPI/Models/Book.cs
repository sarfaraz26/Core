using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName ="decimal(4,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime PublishedDate { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool isPublished { get; set; }

        [Required]
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }



        // Navigation Property
        public Author Author { get; set;  }

    }
}
