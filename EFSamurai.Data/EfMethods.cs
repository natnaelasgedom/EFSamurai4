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
    }
}