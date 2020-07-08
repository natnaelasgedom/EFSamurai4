using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.Data
{
    public static class EfMethods
    {
        #region Create and Delete
        public static int AddOneSamurai(string name)
        {
            Random random = new Random();
            Array valuesHairStyle = Enum.GetValues(typeof(HairStyle));
            HairStyle randomHairStyle = (HairStyle)valuesHairStyle.GetValue(random.Next(valuesHairStyle.Length));

            var samurai = new Samurai { Name = name, HairStyle = randomHairStyle};

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }

            return samurai.ID;
        }

        public static ICollection<Samurai> AddSomeSamurais(ICollection<string> names)
        {
            Random random = new Random();
            Array valuesHairStyle = Enum.GetValues(typeof(HairStyle));

            ICollection<Samurai> addedSamurais = new List<Samurai>();
            foreach (var name in names)
            {
                addedSamurais.Add(new Samurai {Name = name, HairStyle = (HairStyle)valuesHairStyle.GetValue(random.Next(valuesHairStyle.Length))});
            }

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(addedSamurais);
                context.SaveChanges();
            }

            return addedSamurais;
        }

        public static void AddSomeBattles()
        {
            ICollection<Battle> addedBattles = new List<Battle>()
            {
                new Battle
                {
                    Name = "Battle of Sekigahara",
                    Description = "The Battle of Sekigahara was a decisive battle on October 21, 1600 " +
                                  "(Keichō 5, 15th day of the 9th month), that preceded the establishment of " +
                                  "the Tokugawa shogunate.",
                    IsBrutal = true,
                    StartDate = new DateTime(1600,10,21),
                    EndDate = new DateTime(1600,10,23),
                    BattleLog = new BattleLog
                    {
                        Name = "BattleLog for battle of sekigahara",
                        BattleEvent = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 1.1",
                                Summary = "Summary of battleEvent 1.1",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 1.2",
                                Summary = "Summary of battleEvent 1.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 1.3",
                                Summary = "Summary of battleEvent 1.3",
                                Order = 3
                            }
                        }
                    }
                },
                new Battle
                {
                    Name = "Battle of Kizugawa",
                    Description = "The 1614 battle of the Kizugawa was one of a number " +
                                  "of battles surrounding the siege of Osaka, in which the " +
                                  "Tokugawa shogunate destroyed the Toyotomi clan, the last " +
                                  "major opposition to its control of Japan.",
                    IsBrutal = false,
                    StartDate = new DateTime(1614,11,29),
                    EndDate = new DateTime(1614,11,30),
                    BattleLog = new BattleLog
                    {
                        Name = "BattleLog for Battle of Kizugawa",
                        BattleEvent = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 2.1",
                                Summary = "Summary of battleEvent 2.1",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 2.2",
                                Summary = "Summary of battleEvent 2.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 2.3",
                                Summary = "Summary of battleEvent 2.3",
                                Order = 3
                            }
                        }
                    }
                },
                new Battle
                {
                    Name = "Battle of Noryang",
                    Description = "The Battle of Noryang, the last major battle of the Japanese invasions of " +
                                  "Korea (1592–1598), was fought between the Japanese navy and the combined fleets " +
                                  "of the Joseon Kingdom and the Ming dynasty. It took place in the early morning of 16 " +
                                  "December (19 November in the Lunar calendar) 1598 and ended past dawn.",
                    IsBrutal = true,
                    StartDate = new DateTime(1598,12,16),
                    EndDate = new DateTime(1598,12,17),
                    BattleLog = new BattleLog
                    {
                        Name = "BattleLog for Battle of Noryang",
                        BattleEvent = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 3.1",
                                Summary = "Summary of battleEvent 3.1",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 3.2",
                                Summary = "Summary of battleEvent 3.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 3.3",
                                Summary = "Summary of battleEvent 3.3",
                                Order = 3
                            }
                        }
                    }
                },
                new Battle
                {
                    Name = "Siege of Ōtsu",
                    Description = "The siege of Ōtsu took place in 1600, concurrent with the battle of Sekigahara. " +
                                  "Kyōgoku Takatsugu held Ōtsu castle for the Tokugawa, and commanded the garrison.",
                    IsBrutal = true,
                    StartDate = new DateTime(1600,6,20),
                    EndDate = new DateTime(1600,10,15),
                    BattleLog = new BattleLog
                    {
                        Name = "BattleLog for siege of Ōtsu",
                        BattleEvent = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 4.1",
                                Summary = "Summary of battleEvent 4.1",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 4.2",
                                Summary = "Summary of battleEvent 4.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Description = "Description of battleEvent 4.3",
                                Summary = "Summary of battleEvent 4.3",
                                Order = 3
                            }
                        }
                    }
                }
            };

            using (var context = new SamuraiContext())
            {
                context.Battles.AddRange(addedBattles);
                context.SaveChanges();
            }
        }

        public static int AddSamuraiWithRelatedData()
        {
            Random random = new Random();
            Array valuesHairStyle = Enum.GetValues(typeof(HairStyle));
            Array valuesQuoteStyle = Enum.GetValues(typeof(QuoteStyle));

            using var context = new SamuraiContext();
            var endSamurai = new Samurai
            {
                Name = "Monkey D. Luffy",
                HairStyle = (HairStyle) valuesHairStyle.GetValue(random.Next(valuesHairStyle.Length)),
                QuotesCollection = new List<Quote>()
                {
                    new Quote
                    {
                        QuoteStyle = (QuoteStyle) valuesQuoteStyle.GetValue(random.Next(valuesQuoteStyle.Length)),
                        Text = "There is nothing outside yourself that can ever " +
                               "enable you to get better, stronger, richer, quicker or smarter." +
                               "Everything is within. Everything exists. Seek nothing outside of yourself."
                    },
                    new Quote
                    {
                        Text = "The perfect blossom is a rare thing. " +
                               "You could spend your life looking for one, " +
                               "and it would not be a wasted life.",
                        QuoteStyle = (QuoteStyle) valuesQuoteStyle.GetValue(random.Next(valuesQuoteStyle.Length))
                    }
                },
                SamuraiBattle = new List<SamuraiBattle>()
                {
                    new SamuraiBattle
                    {
                        BattleID = context.Battles.First().ID
                    }
                },
                SecretIdentity = new SecretIdentity
                {
                    RealName = "Rurouni Kenshin"
                }
            };

            context.Samurais.Add(endSamurai);
            context.SaveChanges();
            return endSamurai.ID;
        }

        public static void ClearDataBase()
        {
            using (var context = new SamuraiContext())
            {
                context.RemoveRange(context.Samurais);
                context.RemoveRange(context.Battles);

                var props = typeof(SamuraiContext).GetProperties(System.Reflection.BindingFlags.Public
                                                        | System.Reflection.BindingFlags.Instance
                                                        | System.Reflection.BindingFlags.DeclaredOnly);
                foreach (var prop in props)
                {
                    if (prop.Name != "SamuraiBattles")
                    {
                        context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('{prop.Name}', RESEED, 0)");
                    }
                }
                context.SaveChanges();
            }
        }
        #endregion Create and Delete

        #region Read
        public static ICollection<string> ListAllSamuraiNames()
        {
            using (var context = new SamuraiContext())
            {
                
                return context.Samurais.Select(s => s.Name).ToList();
            }

        }

        public static ICollection<string> ListAllSamuraiNames_OrderByName()
        {
            using (var context = new SamuraiContext())
            {
                return context.Samurais.OrderBy(s => s.Name).Select(s => s.Name).ToList();
            }
        }

        public static ICollection<string> ListAllSamuraiNames_OrderByIdDescending()
        {
            using (var context = new SamuraiContext())
            {
                return context.Samurais.OrderByDescending(s => s.ID).Select(s => s.Name).ToList();
            }
        }

        public static string FindSamuraiWithRealName(string name)
        {
            using (var context = new SamuraiContext())
            {
                if (context.Samurais.Include(s => s.SecretIdentity).Any(s => s.SecretIdentity.RealName == name))
                {
                    return
                        $"Real Name: {name}\nAlias: {context.Samurais.Include(s => s.SecretIdentity).Where(s => s.SecretIdentity.RealName == name).Select(s => s.Name).ToList()[0]}";
                }

                return $"No samurai with the name <{name}> was found";
            }
        }

        public static ICollection<string> ListAllQuotesOfType(QuoteStyle quoteStyle)
        {
            using (var context = new SamuraiContext())
            {
                return context.Quotes
                    .Where(q => q.QuoteStyle == quoteStyle)
                    .Select(q => q.Text).ToList();
            }
        }

        public static ICollection<string> ListAllQuotesOfType_WithSamurai(QuoteStyle quoteStyle)
        {
            ICollection<string> output = new List<string>();
            using (var context = new SamuraiContext())
            {
                var relevantQuotes = context.Quotes
                    .Where(q => q.QuoteStyle == quoteStyle)
                    .Include(q => q.Samurai);
                foreach (var quote in relevantQuotes)
                {
                    output.Add($"\"{quote.Text}\" is a {quote.QuoteStyle} quote by {quote.Samurai.Name}");
                }
            }

            return output;
        }

        public static ICollection<string> ListAllBattles(DateTime from, DateTime to, bool? isBrutal)
        {
            ICollection<string> output = new List<string>();
            using (var context = new SamuraiContext())
            {
                var relevantBattles = context.Battles.Where(b => b.StartDate > from && b.EndDate < to);
                foreach (var battle in relevantBattles)
                {
                    if (isBrutal == null || battle.IsBrutal == isBrutal)
                    {
                        output.Add($"<{battle.Name}> was{(battle.IsBrutal ? "" : " not")} a brutal battle within the period");
                    }
                }
            }

            return output;
        }

        #endregion Read

        #region Advanced Querys

        public static ICollection<string> AllSamuraiNamesWithAliases()
        {
            ICollection<string> output = new List<string>();
            using (var context = new SamuraiContext())
            {
                var samuraisWithAliases = context.Samurais
                    .Include(s => s.SecretIdentity);
                foreach (var samurai in samuraisWithAliases)
                {
                    string realName = samurai.SecretIdentity == null ? "Has no alias" : samurai.SecretIdentity.RealName;
                    output.Add($"<{samurai.Name}> alias <{realName}>");
                }
            }
            return output;
        }

        public static ICollection<string> ListAllBattles_WithLog(DateTime from, DateTime to, bool isBrutal)
        {
            ICollection<string> output = new List<string>();
            using (var context = new SamuraiContext())
            {
                output.Add($"----------------------------------------------");

                var battlesWithLogAndEvents = context.Battles
                    .Include(b => b.BattleLog)
                    .ThenInclude(bl => bl.BattleEvent)
                    .Where(b => b.StartDate > from && b.EndDate < to && b.IsBrutal == isBrutal);
                foreach (var battle in battlesWithLogAndEvents)
                {
                    string s = $"{"Name of battle", -15} {battle.Name, -15}\n" +
                               $"{"Log name",-15} {battle.BattleLog.Name,-15}\n";
                    foreach (var e in battle.BattleLog.BattleEvent)
                    {
                        s += $"{"Event",-15} {e.Summary,-15}( Order: {e.Order}, Battle: {battle.Name})\n";
                    }
                    output.Add(s);
                    output.Add($"----------------------------------------------");
                }

            }
            return output;
        }

        public static ICollection<SamuraiInfo> GetSamuraiInfo()
        {
            ICollection<SamuraiInfo> output = new List<SamuraiInfo>();

            using (var context = new SamuraiContext())
            {
                var allSamuraisWithExtraSauce = context.Samurais
                    .Include(s => s.SecretIdentity)
                    .Include(s => s.SamuraiBattle)
                    .ThenInclude(sb => sb.Battle);
                foreach (var samurai in allSamuraisWithExtraSauce)
                {
                    string name = samurai.Name;
                    string realName = samurai.SecretIdentity == null ? "No Alias" : samurai.SecretIdentity.RealName;
                    string battleNames = "";

                    foreach (var sb in samurai.SamuraiBattle)
                    {
                        battleNames += (samurai.SamuraiBattle.Count == 1) ? $"{sb.Battle.Name}" : $"{sb.Battle.Name},";
                    }

                    output.Add(new SamuraiInfo
                    {
                        Name = name,
                        RealName = realName,
                        BattleNames = battleNames
                    });
                }
            }
            return output;
        }

        public static ICollection<string> GetBattlesForSamurai(string samuraiName)
        {
            ICollection<string> output = new List<string>();
            using (var context = new SamuraiContext())
            {
                output.Add($"{"ID", -20} {"Name", -20}\n" +
                           $"-------------------------------------");
                var correctSamurai = context.Samurais
                    .Include(s => s.SamuraiBattle)
                    .ThenInclude(sb => sb.Battle)
                    .Single(s => s.Name == samuraiName);
                foreach (var sb in correctSamurai.SamuraiBattle)
                {
                    output.Add($"{sb.BattleID,-20} {sb.Battle.Name,-20}");
                }
            }

            return output;
        }

        #endregion Advanced Querys

        #region WriteOut-Methods
        public static void WriteOut(ICollection<string> inList)
        {
            foreach (string s in inList)
            {
                WriteOut(s);
            }
        }
        public static void WriteOut(ICollection<Samurai> inList)
        {
            foreach (var item in inList)
            {
                WriteOut(item.Name);
            }
        }

        public static void WriteOut(string s)
        {
            Console.WriteLine(s);
        }

        public static void WriteOut(ICollection<SamuraiInfo> inList)
        {
            WriteOut($"{"Name", -20} {"RealName", -20} {"BattleNames", -20}\n" +
                     $"----------------------------------------------------");
            foreach (var samuraiInfo in inList)
            {
                WriteOut($"{samuraiInfo.Name, -20} {samuraiInfo.RealName, -20} {samuraiInfo.BattleNames, -20}");
            }
        }

        #endregion WriteOut-Methods


    }
}