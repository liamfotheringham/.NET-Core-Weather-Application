namespace Weather_Application.Models
{

    public class WeatherModel
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string TzId { get; set; }
        public int LocaltimeEpoch { get; set; }
        public string Localtime { get; set; }
    }

    public class Current
    {
        public int LastUpdatedEpoch { get; set; }
        public string LastUpdated { get; set; }
        public float TempC { get; set; }
        public float TempF { get; set; }
        public int IsDay { get; set; }
        public Condition Condition { get; set; }
        public float WindMph { get; set; }
        public float WindKph { get; set; }
        public int WindDegree { get; set; }
        public string WindDir { get; set; }
        public float PressureMb { get; set; }
        public float PressureIn { get; set; }
        public float PrecipMm { get; set; }
        public float PrecipIn { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public float FeelslikeC { get; set; }
        public float GeelslikeF { get; set; }
        public float VisKm { get; set; }
        public float VisMiles { get; set; }
        public float Uv { get; set; }
        public float GustMph { get; set; }
        public float GustKph { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }

}
