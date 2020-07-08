using System.Collections.Generic;
using NUnit.Framework;
using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.NUnitTest
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            using (var context = new SamuraiContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_AddOneSamuraiTwice()
        {
            EfMethods.AddOneSamurai("Zelda");
            EfMethods.AddOneSamurai("Link");
            string[] result = EfMethods.GetAllSamuraiNames();
            CollectionAssert.AreEqual(new[] { "Zelda", "Link" }, result);
        }

        [Test]
        public void Test_AddOneSamuraiWithSecretIdentity()
        {
            var samurai = new Samurai()
            {
                Name = "Ganondorf Dragmire",
                HairStyle = HairStyle.Western,
            };
            int samuraiId = EfMethods.AddOneSamurai(samurai);
            EfMethods.UpdateSamuraiSetSecretIdentity(samuraiId, "Ganon");
            Samurai actualSamurai = EfMethods.GetSamurai(samuraiId);
            Assert.AreEqual("Ganondorf Dragmire", actualSamurai.Name);
            Assert.AreEqual(HairStyle.Western, actualSamurai.HairStyle);
            Assert.AreEqual("Ganon", actualSamurai.SecretIdentity.RealName);
        }

        [Test]
        public void Test_AddThreeSamuraisListNamesOfThoseWithWesternHairstyles()
        {
            EfMethods.AddOneSamurai(new Samurai() { Name = "Williams Adams", HairStyle = HairStyle.Western });
            EfMethods.AddOneSamurai(new Samurai() { Name = "Tokugawa Leyasu", HairStyle = HairStyle.Oicho });
            EfMethods.AddOneSamurai(new Samurai() { Name = "Jan Joosten", HairStyle = HairStyle.Western });
            // NOTE to students: The following static method, EfTddMethods, is NOT the same as the one above!
            List<string> result = EfTddMethods.ReadAlphabeticallyAllSamuraiNamesWithSpecificHairstyle(HairStyle.Western);
            CollectionAssert.AreEqual(new[] { "Jan Joosten", "Williams Adams" }, result.ToArray());
        }

        [Test]
        public void Test_AddThreeSamuraisWithQuotesReadCheesyQuotes()
        {
            EfMethods.AddOneSamurai(new Samurai() { Name = "Himura Kenshin", QuotesCollection = new List<Quote>() { new Quote() { Text = "You can always die. It's living that takes real courage.", QuoteStyle =  QuoteStyle.Awesome } } });
            EfMethods.AddOneSamurai(new Samurai() { Name = "Watsuki Nobuhiro", QuotesCollection = new List<Quote>() { new Quote() { Text = "New eras don't come about because of swords, they're created by the people who wield them.", QuoteStyle = QuoteStyle.Cheesy } } });
            EfMethods.AddOneSamurai(new Samurai() { Name = "Laini Taylor", QuotesCollection = new List<Quote>() { new Quote() { Text = "Be a Samurai. Because you just never know what's behind the freaking sky.", QuoteStyle = QuoteStyle.Lame } } });
            // NOTE to students: The following static method, EfTddMethods, is NOT the same as the one above!
            List<Quote> result = EfTddMethods.ReadAllQuotesWithSpecificQuoteStyle(QuoteStyle.Cheesy);
            Assert.AreEqual("New eras don't come about because of swords, they're created by the people who wield them.", result[0].Text);
            Assert.AreEqual("Watsuki Nobuhiro", result[0].Samurai.Name);
        }

        [Test]
        public void Test_AddSecretIdentity()
        {
            int samuraiId = EfMethods.AddOneSamurai("Papa Smurf");
            EfMethods.UpdateSamuraiSetSecretIdentity(samuraiId, "Tomas");
            // NOTE to students: The following static method, EfTddMethods, is NOT the same as the one above!
            SecretIdentity result = EfTddMethods.ReadSecretIdentityOfSpecificSamurai(samuraiId);
            Assert.AreEqual("Papa Smurf", result.Samurai.Name);
            Assert.AreEqual("Tomas", result.RealName);
        }

    }
}