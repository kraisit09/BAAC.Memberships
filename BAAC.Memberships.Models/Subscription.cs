using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAAC.Memberships.Models {
  public class Subscription {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public virtual Member Owner { get; set; }

    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }

    [Required]
    public virtual Package Package { get; set; }

    [ForeignKey(nameof(Package))]
    public string PackageCode { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PaidAmount { get; set; }
  }
}
