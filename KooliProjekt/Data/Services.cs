namespace KooliProjekt.Data
{
    public class Services
    {
        public long Id { get; set; }
        public long Structure_Ref { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }

        public Structure Structure { get; set; }
    }
}
 