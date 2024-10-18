namespace KooliProjekt.Data
{
    public class Client
    {
        public long Client_Id { get; set; }

        public ICollection<Structure> Structure { get; set; }
    }
}
 