namespace KooliProjekt.Data
{
    public class Client
    {
        public long Id { get; set; }

        public ICollection<Structure> Structure { get; set; }
    }
}
 