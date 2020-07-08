using System;
using System.Collections.Generic;
using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //EfMethods.ClearDataBase();
            //ICollection<string> samuraiNames = new List<string>()
            //{
            //    "Yakushi Kabuto",
            //    "Uchiha Sasuke",
            //    "Haruno Sakura",
            //    "Hatake Kakashi",
            //};
            //EfMethods.AddSomeSamurais(samuraiNames);
            //EfMethods.AddOneSamurai("Uzumaki Naruto");
            //EfMethods.AddSomeBattles();
            //EfMethods.AddSamuraiWithRelatedData();
            //EfMethods.WriteOut(EfMethods.ListAllSamuraiNames());
            //EfMethods.WriteOut(EfMethods.FindSamuraiWithRealName("Rurouni Kenshin"));
            //EfMethods.WriteOut(EfMethods.FindSamuraiWithRealName("Uchiha Madara"));
            //EfMethods.WriteOut(EfMethods.ListAllQuotesOfType(QuoteStyle.Cheesy));
            //EfMethods.WriteOut(EfMethods.ListAllQuotesOfType_WithSamurai(QuoteStyle.Lame));
            //EfMethods.WriteOut(EfMethods.ListAllBattles(new DateTime(1589,1,1), new DateTime(1620,1,1), null));
            //EfMethods.WriteOut(EfMethods.AllSamuraiNamesWithAliases());
            EfMethods.WriteOut(EfMethods.ListAllBattles_WithLog(new DateTime(1589, 1, 1), new DateTime(1620, 1, 1), false));

        }
    }
}
