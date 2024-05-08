using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuartetScoreManager.Models
{
    public class QuartetScore
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must specifiy a name for the quartet.")]
        [StringLength(50,ErrorMessage = "The quartet name must be 50 characters or less.")]
        public string QuartetName { get; set; }

        [Required(ErrorMessage = "You must specify the music score")]
        [Range(0, 100, ErrorMessage = "The music score must be between 0.0 and 100.0")]
        [Column(TypeName = "decimal(4,1)")]
        public decimal MusScore { get; set; }

        [Required(ErrorMessage = "You must specify the performance score")]
        [Range(0, 100, ErrorMessage = "The performance score must be between 0.0 and 100.0")]
        [Column(TypeName = "decimal(4,1)")]
        public decimal PerScore { get; set; }

        [Required(ErrorMessage = "You must specify the singing score")]
        [Range(0, 100, ErrorMessage = "The singing score must be between 0.0 and 100.0")]
        [Column(TypeName = "decimal(4,1)")]
        public decimal SngScore { get; set; }
    }
}
