namespace KooliProjekt.Data
{
    public class Component
    {
        public long Component_Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public ICollection<PanelComponent> PanelComponents { get; set; }
    }
}
 