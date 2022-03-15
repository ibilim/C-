public class BetterRectangle:ISchape
{
    private double Width;
    private double Height;
    public string Name { get; } = "Rectangle";

    public BetterRectangle(double widht, double height) //das können wir weglassen
    {
        this.Width = widht;
        this.Height = height;
    }


    public double GetWidht()
    {
        return this.Width;
    }

    public double SetWidht()
    {
        return this.Width;
    }
    public double GetHeight()
    {
        return this.Height;
    }


    public double GetArea()
    {
        return this.Width * this.Height;
    }
     

    public double GetPerimeter()
    {
        return 2*(this.Width + this.Height);
    }


    public bool IsSquare()
    {
        if (this.Width == this.Height)
        {
            return true;
        }
        return false;
    }
    public void Describe()
    {
        string format = "Area = {0:0.00} Perimeter = {1:0.00}";
        Console.WriteLine(format, this.GetArea(), this.GetPerimeter()); //Aktuelle Objekt
    }
}