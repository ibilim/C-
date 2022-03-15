public class Address
{
    //private string _Strasse;
    //private int _Hausnummer;
    //private string _Wohnort;
    private const string Unknown="Unbekannt";
    public string? Strasse{ get; set; }
    public string? Hausnummer { get; set; }
    public string? Wohnort { get; set; }
    public string? Land { get; set; }

    //public Address() : this(Unknown, Unknown, Unknown, Unknown)  // when man das benutzt, soll man folgendes weglassen. 
    //{
    //}
    public Address() // oder : this("","","","")
    {
        this.Strasse = Unknown;
        this.Hausnummer = Unknown;
        this.Wohnort = Unknown;
        this.Land = Unknown;
    }
    public Address(string strasse, string hausnummer, string wohnort, string land)
    {
        this.Strasse = strasse;
        this.Hausnummer= hausnummer;
        this.Wohnort= wohnort;
        this.Land = land;
    }

    
    public string Describe()
    {
        string format = String.Format(" Strasse    = {0} \n" +
                                      " Hausnummer = {1} \n" +
                                      " Wohnort    = {2} \n" +
                                      " Land       = {3}", this.Strasse, this.Hausnummer, this.Wohnort, this.Land);
        //Console.WriteLine(format);
        return format;
    }

}