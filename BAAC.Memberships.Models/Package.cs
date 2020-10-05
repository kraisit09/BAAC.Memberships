using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAAC.Memberships.Models {
  public class Package {
    [Key]
    public string Code { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Range(1, 9_999)]
    public int Days { get; set; }

    [Range(0, 999_999)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public string Note { get; set; }
  }
}
