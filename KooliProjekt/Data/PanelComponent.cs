namespace KooliProjekt.Data
{
    public class PanelComponent
    {
        public long Id { get; set; }
        public long Panel_Ref { get; set; }
        public decimal Amount { get; set; }

        public PanelData PanelData { get; set; }
        public Component Component { get; set; }
    }
}
  