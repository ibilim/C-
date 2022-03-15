//BadCircle erbt von System.Object
//Dies geschieht automatisch und muss nicht explicit angegeben werden.

public class BetterCircle:ISchape
{
    //Ein Inztanzattribute 
    private double _Radius;  // jetzt ist _Radius classwide veröffentlicht. Andere Klassen haben keinen Zugriff jetzt
                             //mit diesem Method vermeiden wir Dateninkonsistenz
    public string Name { get; } = "Circle";
    //Ein Default-Konstruktor wird nuir dann automatisch generiert,
    //wenn kein expliziter Kontruktor in der Klasse definiert wird
    //initialisiert das objekt, wenn es erstmal aufgeruft ist
    public BetterCircle() //das können wir weglassen, da C# den Konstruktor automatisch erzeugt.
    {

    }

    public double GetRadius()
    {
        return this._Radius;
    }

    public void SetRadius(double value)
    {
        if (value >0)
        {
            this._Radius = value;
        }
        else
        {
            throw new ArgumentException("Radius Must be greater then zero");
        }
    }
    //Instanzmethode (Objektkontext vorhanden)
    public void Describe()
    {
        string format = "Radius = {0:0.00} Diameter = {1:0.00} Area = {2:0.00} Circumference = {3:0.00}";
        Console.WriteLine(format,this._Radius,this.GetArea(),this.GetDiameter(),this.GetPerimeter()); //Aktuelle Objekt
    }
    public double GetArea()
    {
        //A=pi x r x r 
        //Math.Pow(this.Radius, 2) * Math.PI; 
        return this._Radius*this._Radius*Math.PI;
    }

    public double GetPerimeter()
    {
        //circumference
        return 2 * Math.PI * this._Radius;
    }

    public double GetDiameter()
    {
        //2 x radius
        return 2 * this._Radius;
    }


    //Klassenmethode (kein Objektkontext vorhanden)
    //Hier gibt es kein 'this', da die Methode als static festgelegt 
    public static void PrintMetadata()
    {
        Console.WriteLine(" This is a better implementation of a  circle.");
    }
}