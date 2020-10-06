using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

    public MemberLevel LevelAtDate(DateTime dt) {

      var (currentExp, current) = LastLevelAndExpiredDate(Subscriptions);
      if (dt > currentExp) {

        return MemberLevel.Free;
      }

      return current;
    }

    public DateTime ExpiredDateAtDate(DateTime dt) {
      var items = Subscriptions
                  .Where(x => x.Date <= dt);

      var (currentExp, _) = LastLevelAndExpiredDate(items);
      return currentExp;
    }

    public Subscription Subscribe(Package package, DateTime date, decimal paidAmount) {
      var sub = new Subscription();

      sub.Owner = this;
      sub.Package = package;
      sub.Date = date;
      sub.PaidAmount = paidAmount;

      Subscriptions.Add(sub);

      return sub;
    }

    private (DateTime ExpireDate, MemberLevel Level) LastLevelAndExpiredDate(IEnumerable<Subscription> items) {
      var currentLevel = MemberLevel.Free;
      var currentExp = DateTime.MaxValue;

      foreach (var sub in items) {
        if (currentExp == DateTime.MaxValue) {
          currentExp = sub.Date.AddDays(sub.Package.Days);
        } else {
          currentExp = currentExp.AddDays(sub.Package.Days);
        }
        currentLevel = sub.Package.Level;
      }
      return (currentExp, currentLevel);
    }
  }
}
