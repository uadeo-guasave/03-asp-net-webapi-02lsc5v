using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapi.Entities
{
  [Table("categories")]
  public class Category
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [MaxLength(20)]
    [Required]
    public string Name { get; set; }
  }
}