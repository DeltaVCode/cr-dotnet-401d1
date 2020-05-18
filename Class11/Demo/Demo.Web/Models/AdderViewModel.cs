namespace Demo.Web.Models
{
    public class AdderViewModel
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public int Result => Value1 + Value2;
    }
}
