//BadCircle erbt von System.Object
//Dies geschieht automatisch und muss nicht explicit angegeben werden.

public class BadCircle
{
    //Ein Inztanzattribute 
    public double Radius;
    //Ein Default-Konstruktor wird nuir dann automatisch generiert,
    //wenn kein expliziter Kontruktor in der Klasse definiert wird
    public BadCircle()
    {

    }

    //Instanzmethode (Objektkontext vorhanden)
    public void Describe()
    {
        string format = "Radius = {0:0.00} Diameter = {1:0.00} Area = {2:0.00} Circumference = {3:0.00}";
        Console.WriteLine(format,this.Radius,this.GetArea(),this.GetDiameter(),this.GetPerimeter()); //Aktuelle Objekt
    }
    public double GetArea()
    {
        //A=pi x r x r 
        //Math.Pow(this.Radius, 2) * Math.PI; 
        return this.Radius*this.Radius*Math.PI;
    }

    public double GetPerimeter()
    {
        //circumference
        return 2 * Math.PI * this.Radius;
    }

    public double GetDiameter()
    {
        return 2 * this.Radius;
    }


    //Klassenmethode (kein Objektkontext vorhanden)
    public static void PrintMetadata()
    {
        Console.WriteLine(" This is a very very very bad circle.");
    }
}