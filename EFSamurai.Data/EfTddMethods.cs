using System.Collections.Generic;
using System.Linq;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.Data
{
    public static class EfTddMethods
    {
        public static List<string> ReadAlphabeticallyAllSamuraiNamesWithSpecificHairstyle(HairStyle hairStyle)
        {
            using (var context = new SamuraiContext())
            {
                return context.Samurais
                    .Where(s => s.HairStyle == hairStyle)
                    .OrderBy(s => s.Name)
                    .Select(s => s.Name)
                    .ToList();
            }
        }

        public static List<Quote> ReadAllQuotesWithSpecificQuoteStyle(QuoteStyle quoteStyle)
        {
            using (var context = new SamuraiContext())
            {
                return context.Quotes
                    .Where(q => q.QuoteStyle == quoteStyle)
                    .Include(q => q.Samurai)
                    .ToList(); ;
            }
        }

        public static SecretIdentity ReadSecretIdentityOfSpecificSamurai(int samuraiId)
        {
            using (var context = new SamuraiContext())
            {
                return context.SecretIdentities
                    .Include(si => si.Samurai)
                    .Single(si => si.SamuraiID == samuraiId);
            }
        }
    }
}