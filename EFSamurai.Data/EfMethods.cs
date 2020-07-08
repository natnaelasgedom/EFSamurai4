using System;
using System.Collections;
using System.Collections.Generic;
using EFSamurai.Domain;

namespace EFSamurai.Data
{
    public static class EfMethods
    {
        public static int AddOneSamurai(string name)
        {
            var samurai = new Samurai { Name = name };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }

            return samurai.ID;
        }

        public static ICollection<Samurai> AddSomeSamurais(ICollection<string> names)
        {
            ICollection<Samurai> addedSamurais = new List<Samurai>();
            foreach (var name in names)
            {
                addedSamurais.Add(new Samurai {Name = name});
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
    }
}