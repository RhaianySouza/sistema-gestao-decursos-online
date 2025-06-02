public class ClimaInfo
{
    public Main main { get; set; }
    public string name { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public int humidity { get; set; }
}