namespace KooliProjekt.Data
{
    public class PanelData
    {
        public long Id { get; set; }
        public long Dimensions { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<PanelComponent> PanelComponents { get; set; }
    }
}
 