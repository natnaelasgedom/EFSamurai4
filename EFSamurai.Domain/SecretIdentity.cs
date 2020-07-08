namespace EFSamurai.Domain
{
    public class SecretIdentity
    {
        public int ID { get; set; }
        public string RealName { get; set; }
        public int SamuraiID { get; set; }
        public Samurai Samurai { get; set; }
    }
}