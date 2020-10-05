using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAAC.Memberships.Models {
  public class Member {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Nickname { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string Note { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new HashSet<Subscription>();

  }
}
