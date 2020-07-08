using System.Reflection.Metadata;

namespace EFSamurai.Domain
{
    public class Quote
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public QuoteStyle? QuoteStyle { get; set; }
        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
        
        
    }
}