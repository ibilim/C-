using System;
using Utilities;

public class FunWithClasses
{
    public static void Main()
    {
        
    }

    public static void FunWithDelegates()
    {

        BookSampleFilterDelegate? filter = DoSomeFiltering; // delegate Objekt zeigt hier auf die Methode FunWithClassess.FilterByAudioBook

        filter += FilterByAudioBook; //zuerst wird DoSomeFiltering ausgeführt, dann wird FilterByAudioBook ausgeführt.

        Buchexemplar book= new Buchexemplar("Freedom", "West", new string[] { "dostoyesvki", "karl" }, "254");
        book.Medidum = Medium.SoftCover;

        bool result = filter(book); //

        BetterBookLibrary betterlibrary = new BetterBookLibrary();
        Buchexemplar book2 = new Buchexemplar("Sentenced", "Ost", new string[] { "Trki", "arabi" }, "400");
        book2.Medidum = Medium.Hardcover;
        Console.WriteLine("Number of Books in Library: {0}", betterlibrary.GetBookNumber());
        betterlibrary.AddBook(book);
        betterlibrary.AddBook(book2);
        Buchexemplar? founbook=betterlibrary.FindBook(DoSomeFiltering); 
        founbook = betterlibrary.FindBook(FilterByAudioBook);
        founbook = betterlibrary.FindBook(sample => sample.Sachgebiet == "West");// Lambda Funktion Syntax =>Rumpf



    }


    



    public static bool FilterByAudioBook(Buchexemplar sample)
    {
        return sample.Medidum == Medium.AudioBook;
    }
    
    public static bool DoSomeFiltering(Buchexemplar sample)
    {
        return sample.Sachgebiet == "West";
    }

    public static void InterfaceWithGeometricshapes()
    {
        Triangle tria = new Triangle(3, 4, 5);
        BetterCircle circle = new BetterCircle();
        circle.SetRadius(10);
        BetterRectangle rectangle = new BetterRectangle(10, 20);
        List<ISchape> shapes = new List<ISchape>();
        shapes.Add(tria);
        shapes.Add(circle);
        shapes.Add(rectangle);
        //GeometricshapeInterface(shapes);

        ISchape tria2 = new Triangle(10); // Das geht auch. Das ist Polimorphy- Das Property Name ist Polymorphy,
                                          // da es das Attribut Name von Rectangle Triangle oder aucg Circle sein kann.
                                          // (genauer gesagt kann es das Name-Attribut einer bliebigen Klassen sein, die IShape implementirert. )
        Console.WriteLine("{0} , {1}", tria2.Name, tria2.GetArea());
    }

    public static void GeometricshapeInterface(ICollection<ISchape> shapes)
    {
        foreach(ISchape shape in shapes)
        {
            Console.WriteLine(" Name = {0} \n Area = {1:0.00} \n Perimeter = {2:0.00}", shape.Name, shape.GetArea(), shape.GetPerimeter());
        }
        

    }
    public static void WriteCollections(ICollection<string>[] collections)
    {

        BookAndLibrary();
        //doSomething(ref p1);
        //p1.Describe();
        List<string> names = new() { "max", "ulli" };
        HashSet<string> animals = new() { "tiger", "cat", "fox", "vogel" };
        SortedSet<string> subjects = new() { "math", "englisch", "sport" };

        WriteCollections(new ICollection<string>[] { names, animals, subjects });
        foreach (ICollection<string> aCollection in collections)
        {
            Console.WriteLine(aCollection.Count);
            aCollection.Add("Ein neues Element");
            foreach (string element in aCollection)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }
    }
    public static void BookAndLibrary()
    {
        Buchexemplar book = new Buchexemplar("Freedom", "West", new string[] { "dostoyesvki", "karl" }, "254");
        book.Medidum = Medium.SoftCover;
        //book.Describe();
        Buchexemplar book_copy = book.Copy();
        //book_copy.Describe();
        //BookLibrary library = new BookLibrary(10);
        //Console.WriteLine("Number of Books in Library: {0}", library.BookNumber());
        //library.AddBook(book);
        //library.AddBook(book_copy);
        //library.AddBook(book_copy);
        //library.AddBook(book_copy);
        //Console.WriteLine("Library Capacity: {0} ", library.Capacity);
        //Console.WriteLine("Number of Books in Library: {0}", library.BookNumber());
        //library.Remove(book.ID);
        //Console.WriteLine("Number of Books in Library: {0}", library.BookNumber());

        BetterBookLibrary betterlibrary = new BetterBookLibrary();
        Buchexemplar book2= new Buchexemplar("Sentenced", "Ost", new string[] { "Trki", "arabi" }, "400");
        book2.Medidum = Medium.Hardcover;
        Console.WriteLine("Number of Books in Library: {0}", betterlibrary.GetBookNumber());
        betterlibrary.AddBook(book);
        betterlibrary.AddBook(book2);
        //betterlibrary.PrintCopies();
        //betterlibrary.Remove(book.ID);
        Console.WriteLine("Number of Books in Library: {0}", betterlibrary.GetBookNumber());
        //betterlibrary.PrintCopies();
        //betterlibrary.Remove(book.ID);

        

    }

    public static void Interfaces()
    {
        Buchexemplar book = new Buchexemplar("Freedom", "West", new string[] { "dostoyesvki", "karl" }, "254");
        book.Medidum = Medium.SoftCover;
        BetterBookLibrary betterlibrary = new BetterBookLibrary();
        Buchexemplar book2 = new Buchexemplar("Sentenced", "Ost", new string[] { "Trki", "arabi" }, "400");
        book2.Medidum = Medium.Hardcover;
        Console.WriteLine("Number of Books in Library: {0}", betterlibrary.GetBookNumber());
        betterlibrary.AddBook(book);
        betterlibrary.AddBook(book2);
        TitleFilter titleflt = new("Freedom");

        Buchexemplar? found = betterlibrary.FindBook(titleflt);
        if (found is not null)
        {
            found.Describe();
        }
        titleflt = new("Sentenced");
        found = betterlibrary.FindBook(titleflt);
        if (found is not null)
        {
            found.Describe();
        }

        AuthorFilter? authorflt = new("karl");
        found = betterlibrary.FindBook(authorflt);
        if (found is not null)  //oder found?.Describe()
        {
            found.Describe();
        }
        //found?.Describe();
    }
    public static void doSomething(ref Person p) //hier passiert echte Call by reference //Ohne ref ist das call by value
    {
        p.Address.Land = "Moon"; 
        p = new Person("Reference",(DateTime.Now).ToString(),"Ref");
    }


    public static void PersonAndAdress()
    {
        Person p1 = new Person("Rainer Zufall", "10-08-1999", "Deutsch");
        Person p2 = new Person(name: "Cevat Kelle", nationality: "Turki", birthdate: "01.02.1958"); //Das geht auch.
        Console.WriteLine(p1.Name);
        //p1.Name = "Claire Grube";
        Console.WriteLine(p1.Name);
        Console.WriteLine(p1.Birthdate);
        //p1.Natiolality= "tr" funktioniert nicht, da nationality als read-only festgelegt
        p1.Gender = Gender.Female;
        p2.Gender = Gender.Diverse;
        p1.Address.Strasse = "max-well strasse";
        p1.Address.Hausnummer = "21";
        p1.Address.Wohnort = "Erfurt";
        p1.Address.Land = "TH";
        p1.Describe();
        Address addr1 = new Address();
        Address addr2 = new Address("Hagebutenweg", "7", "Erfurt", "TH");
        p2.Address.Land = addr2.Land;
        p2.Address.Hausnummer = addr2.Hausnummer;
        p2.Address.Strasse = addr2.Strasse;
        p2.Address.Wohnort = addr2.Wohnort;
        p2.Describe();
        Person p3 = new Person("Kaka KaKali", "10-05-1984", "Polisch");
        p3.Address.Strasse = "poliska strasse";
        //p3.Gender = Gender.;
        p3.Describe();
        Person p4 = new Person("Kaka KaKali2", "10-05-1985", "Polisch");
        p4.Address.Strasse = "poliska strasse";
        p4.Describe();
    }

    public static void OldMain()
    {
        //int? zahl = null;HINWEIS
        //string? name = null; HINWEIS
        BadCircle? circle = null; // mit ? legen wir fest, dass unsere variable Null eingesetz werden kann.
        circle = new BadCircle();
        BadCircle othercircle = new BadCircle();
        BadCircle thirdCircle = othercircle; // circle3 und othercircle zeigen auf desselbe Objekt im HEAP


        //Console.WriteLine(othercircle.Equals(thirdCircle)); //ergibt true, da die beide objekte zeigen auf desselben Objekt 
        //Console.WriteLine(Object.Equals(thirdCircle,othercircle));
        //Console.WriteLine(Object.ReferenceEquals(thirdCircle,othercircle)); //vergleicht die referenzen

        //BadCircle.PrintMetadata();
        //thirdCircle.PrintDetails(); //Fehler: PrintDetails ist static deswegen bekommen wir eine Fehlermeldung

        circle.Radius = 10;
        othercircle.Radius = 5.25;
        //thirdCircle.Radius = 7; //ACTUNG  Ein semantische Fehler aber keine syntaxische fehler
        //circle.Describe();
        //othercircle.Describe();
        //thirdCircle.Describe();

        //BadCircle newCircle = new BadCircle();
        //newCircle.Describe();
        //newCircle.Radius = -50; // Ooops! NegativerRadius? 
        //newCircle.Describe();
        
        //BetterCircle betterCircle = new BetterCircle();
        //betterCircle.SetRadius(10);
        //betterCircle.Describe();
        //Console.WriteLine(betterCircle.GetRadius());
        //BadRectangle rectangle1 =new BadRectangle();
        //rectangle1.Width = 10;
        //rectangle1.Height = 30;  
        //rectangle1.Describe();
        //Console.WriteLine(rectangle1.IsSquare());                               
        //Triangle triangle1= new Triangle(10,20,13);
        //triangle1.Describe();
        //triangle1.SetLenghts(10, 20, 15);
        //triangle1.Describe();
        Triangle t2= Triangle.CreateRightAngled(10,20);
        t2.Describe();
        Console.WriteLine(t2.IsrightAngled());
         

    }

    

}