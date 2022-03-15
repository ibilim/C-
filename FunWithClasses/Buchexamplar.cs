public class Buchexemplar
{
    public const string Unknown = "Unbekannt";
    public string ID { get; private set; }
    public string Title { get; }
    public string Authors { get; private set; }
    public string Sachgebiet { get;}
    public string Pagenumber { get; }
    public Medium Medidum { get; set;}
    public BookLibrary Library { get; set;}

    public string ISBN { get; private set; }

    public string CreateISBN()
    {
        string isbn = ""; // 13 stellige nummer
        Random random = new Random();
        for (int i = 0; i < 13; i = i + 1)
        {
            isbn += random.Next(0, 9).ToString();
        }
        return isbn;
    }


    public string AppdAuthors(string[] auths)
    {
        string appauthors = "";
        for (int i = 0; i < auths.Length; i = i + 1)
        {
            if (i == auths.Length - 1)
            {
                appauthors += auths[i];
            }
            else
            {
                appauthors += auths[i] + ", ";
            }

        }
        return appauthors;
    }

   
    public Buchexemplar()
    {
        this.ID = Guid.NewGuid().ToString();
        this.Title = Unknown;
        this.Authors = Unknown;
        this.Sachgebiet = Unknown;
        this.Pagenumber = Unknown;
        this.Medidum = Medium.Unknown;
        this.ISBN = CreateISBN();
    }
    public Buchexemplar(string title, string sachgebiet, string[] authors, string page_number)
    {
        this.ID = Guid.NewGuid().ToString();
        this.Title = title.ToUpper();
        this.Authors = this.AppdAuthors(authors).ToUpper();
        this.Sachgebiet = sachgebiet;
        this.Pagenumber = page_number;
        this.Medidum = Medium.Unknown;
        this.ISBN = this.CreateISBN();
    }

    //Obwohl hier nur eine flache Kopie erzeugt wird, reich dies aus,
    //da String-Objekte nicht nachträglich modifiziert werden können. Das Array wird im Konstruktor kopiert.
    public Buchexemplar? Copy() 
    {
        Buchexemplar copy = new Buchexemplar(this.Title, this.Sachgebiet, this.Authors.Split(','), this.Pagenumber);
        copy.ID = Guid.NewGuid().ToString();
        copy.Medidum = Medium.Unknown;
        copy.ISBN = this.CreateISBN();
        copy.Authors = this.Authors;

        return copy;
    }

    public void Describe()
    {
        string format = "Title ={0} \n Book_ID = {1}\n Authors = {2} \n Typ = {3} \n Page Number = {4} \n Medium = {5} \n ISBN = {6} ";
        Console.WriteLine(format, Title, ID, Authors, Sachgebiet, Pagenumber, Medidum, ISBN);
    }
}