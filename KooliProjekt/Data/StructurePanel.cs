namespace KooliProjekt.Data
{
    public class StructurePanel
    {
        public long Panel_Id { get; set; }
        public long Structure_Ref { get; set; }
        public decimal Amount { get; set; }

        public Structure Structure { get; set; }
        public ICollection<PanelComponent> PanelComponents { get; set; }
    }
}
 