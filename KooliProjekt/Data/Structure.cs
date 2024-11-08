namespace KooliProjekt.Data
{
    public class Structure
    {
        public long Id { get; set; }
        public long Client_Ref { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Client Client { get; set; }

        public ICollection<StructurePanel> StructurePanel { get; set; }
        public ICollection<Services> Services { get; set; }

    }
}
 