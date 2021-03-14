using HeroesGame.Constant;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
using NUnit.Framework;
using System;
using Moq;
using Moq.Protected;

namespace HeroesGame.Test
{
    public class HeroShould
    {
        private Mock<Mage> hero;

        [SetUp]
        public void Setup()
        {
            hero = new Mock<Mage>();
            hero.Protected().Setup("LevelUp").CallBase();
        }

        [Test]
        public void HaveCorrectInitialValues()
        {
            //Assert 
            Assert.That(hero.Object.Level, Is.EqualTo(HeroConstants.InitialLevel));
            Assert.That(hero.Object.Experience, Is.EqualTo(HeroConstants.InitialExperience));
            Assert.That(hero.Object.MaxHealth, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(hero.Object.Armor, Is.EqualTo(HeroConstants.InitialArmor));
            Assert.That(hero.Object.Weapon, Is.Not.Null);
        }

        [Test]
        public void TakeHitCorrectly_Range([Range(from: 70, to: 100, step: 10)] int damage)
        {
            //Act
            hero.Object.TakeHit(damage);

            //Assert
            Assert.That(hero.Object.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        }

        //[Test]
        //public void TakeHitCorrectly()
        //{
        //    hero = new Warrior();

        //    //Act
        //    int damage = 50;
        //    hero.TakeHit(50);

        //    //Assert
        //    Assert.That(hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        //}

        //[Test]
        //public void TakeHitCorrectly_Combinatorial([Values(40, 50, 60)] int damage)
        //{
        //    //Act
        //    hero.TakeHit(damage);

        //    //Assert
        //    Assert.That(hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        //}

        //[Test]
        //[TestCase(arg: -10)]
        //[TestCase(arg: -20)]
        //[TestCase(arg: -30)]
        //public void ThrowExceptionForNegativeTakeHitValue(int damage)
        //{
        //    //Assert
        //    Assert.Throws<ArgumentException>(() => hero.TakeHit(damage), "Damage value cannot be negative");
        //}

        //[Test]
        //[TestCase(arg: 10)]
        //[TestCase(arg: 20)]
        //[TestCase(arg: 30)]
        //public void TakeHitCorrectly_TestCase(int damage)
        //{
        //    //Act
        //    hero.TakeHit(damage);

        //    //Assert
        //    Assert.That(hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth - damage + HeroConstants.InitialArmor));
        //}

        //[Test]
        //public void ThrowExceptionForNegativeTakeHitValue()
        //{
        //    //Act 
        //    var damage = -50;

        //    //Assert
        //    Assert.Throws<ArgumentException>(() => hero.TakeHit(damage), "Damage value cannot be negative");
        //}

        //[Test]
        //public void GainExperienceCorrectly([Range(from: 25, to: 500, step: 25)] double xp)
        //{
        //    //Act
        //    hero.GainExperience(xp);

        //    //Assert
        //    if (xp >= HeroConstants.MaximumExperience)
        //    {
        //        double expectedXp = (HeroConstants.InitialExperience + xp) % HeroConstants.MaximumExperience;

        //        Assert.That(hero.Experience, Is.EqualTo(expectedXp));
        //        Assert.That(hero.Level, Is.EqualTo(HeroConstants.InitialLevel + 1));
        //    }
        //    else
        //    {
        //        Assert.That(hero.Experience, Is.EqualTo(HeroConstants.InitialExperience + xp));
        //    }
        //}

        //[Test]
        //public void HealCorrectly([Range(from: 5, to: 25, step: 1)] int level, [Range(from: 25, to: 500, step: 25)] int damage)
        //{
        //    //Act
        //    //level up our hero
        //    LevelUp(level);
        //    //then take a hit
        //    double totalDamage = HeroConstants.InitialMaxHealth + damage;
        //    totalDamage = hero.TakeHit(totalDamage);
        //    hero.Heal();

        //    //Assert
        //    int healValue = hero.Level * HeroConstants.HealPerLevel;
        //    double expectedHealth = (hero.MaxHealth - totalDamage) + healValue;

        //    if (expectedHealth > hero.MaxHealth)
        //    {
        //        expectedHealth = hero.MaxHealth;
        //    }

        //    Assert.That(hero.Health, Is.EqualTo(expectedHealth));
        //}

        //private void LevelUp(int levels)
        //{
        //    for (int i = 0; i < levels; i++)
        //    {
        //        hero.GainExperience(HeroConstants.MaximumExperience);
        //    }
        //}
        //[Test]
        //public void NotBeBornDead()
        //{
        //    //Act
        //    bool isDead = hero.IsDead();

        //    //Assert
        //    Assert.That(hero.IsDead, Is.False);
        //}

        //[Test]
        //public void BeDeadWhenCriticallyHit([Range(from: 50, to: 100, step: 25)] double damage)
        //{
        //    //Act
        //    damage = hero.TakeHit(damage);

        //    //Assert
        //    if (damage >= hero.MaxHealth)
        //    {
        //        Assert.That(hero.IsDead);
        //    }
        //    else
        //    {
        //        Assert.That(hero.IsDead, Is.False);
        //    }
        //}

    }
}
