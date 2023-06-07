using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_learning
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Timestamp]
        public DateTime Date { get; set; }
        [Required]
        
        public int orderId { get; set; }
        [ForeignKey("orderId")]
        public virtual Order Order { get; set; }
        public Article() { }
    }
}
