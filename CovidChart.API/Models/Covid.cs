namespace CovidChart.API.Models
{
    public class Covid
    {
        public int Id { get; set; }
        public City City { get; set; }
        public int Count { get; set; }
        public DateTime CovidDate { get; set; }
    }
    public enum City
    {
        Istanbul = 0,
        Ankara = 1,
        Izmir = 2,
        Konya = 3,
        Antalya = 4
    }
}
