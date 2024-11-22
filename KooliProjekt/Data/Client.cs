namespace KooliProjekt.Data
{
    public class Client
    {
        public long Id { get; set; }

        public string Name { get; internal set; }

        public string Location { get; set; }

        public ICollection<Structure> Structure { get; set; }
    }
}
 