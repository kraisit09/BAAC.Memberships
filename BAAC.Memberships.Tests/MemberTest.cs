using System;
using System.Collections.Generic;
using BAAC.Memberships.Models;
using Xunit;

namespace BAAC.Memberships.Tests {
  public class MemberTest {
    [Fact]
    public void NewMember() {
      // arrange เตรียมสถานการณ์
      var m = new Member();
      var dt1 = new DateTime(2020, 1, 1);

      // act

      // assert
      Assert.Equal(expected: MemberLevel.Free, actual: m.LevelAtDate(dt1));

    }

    public static IEnumerable<object[]> TestDataFor_SubscribeBasicPackage() {
      yield return new object[] { new DateTime(2020, 1, 8), MemberLevel.Basic };
      yield return new object[] { new DateTime(2020, 1, 15), MemberLevel.Free };
      yield return new object[] { new DateTime(2020, 2, 20), MemberLevel.Free };
    }

    [Theory]
    [MemberData(nameof(TestDataFor_SubscribeBasicPackage))]
    //[InlineData(1, 8, MemberLevel.Basic)]
    //[InlineData(1, 15, MemberLevel.Free)]
    public void SubscribeBasicPackage(DateTime checkDate,
   MemberLevel checkLevel) {
      // a
      var basicPackage = new Package {
        Code = "BASIC",
        Name = "Basic 10 days",
        Level = MemberLevel.Basic,
        Days = 10,
        Price = 100m,
      };

      var dt1 = new DateTime(2020, 1, 1);
      //var checkDate = new DateTime(2020, month, day);

      var m = new Member();
      m.Nickname = "Alice";

      // a 
      Subscription sub = m.Subscribe(
        package: basicPackage,
        date: dt1,
        paidAmount: 100m);

      var level = m.LevelAtDate(checkDate);

      // a
      Assert.NotNull(sub);
      Assert.Equal(dt1, sub.Date);
      Assert.Same(basicPackage, sub.Package);

      Assert.Equal(checkLevel, level);
    }


    [Fact]
    public void RenewSubscription() {
      // arrange
      var basicPackage = new Package {
        Code = "BASIC",
        Name = "Basic 10 day",
        Days = 10,
        Price = 100,
        Level = MemberLevel.Basic,
      };
      var jan1 = new DateTime(2020, 1, 1);
      var jan8 = new DateTime(2020, 1, 8);
      var jan11 = jan1.AddDays(10);
      var jan21 = jan11.AddDays(10);

      var m = new Member();
      m.Nickname = "Alice";

      Subscription sub = m.Subscribe(
         package: basicPackage,
         date: jan1,
         paidAmount: 100m
         );

      Assert.Equal(jan11, m.ExpiredDateAtDate(jan1));

      Subscription sub2 = m.Subscribe(
        package: basicPackage,
        date: jan8,
        paidAmount: 100m
        );

      Assert.Equal(jan21, m.ExpiredDateAtDate(jan8));
    }
  }
}
