public class BadRectangle
{
    public double Width;
    public double Height;

    public BadRectangle() //das können wir weglassen
    {

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
        string format = "Height= {0} Widht = {1} Area = {2:0.00} Perimeter = {3:0.00}";
        Console.WriteLine(format,this.Height,this.Width, this.GetArea(), this.GetPerimeter()); //Aktuelle Objekt
    }
}