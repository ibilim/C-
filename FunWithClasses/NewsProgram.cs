public class NewsProgram
{
    
    public static void Main()
    {
        Console.WriteLine("Test NewsProgram ");

        NewsAgency agency = new NewsAgency();
        agency.NewNews += SubscriberOne;
        agency.NewNews += SubscriberTwo;
        agency.NewNews += SubscriberOne;
        for(int i = 0; i < 10; i++)
        {
            agency.NewNews += SubscriberOne;
        }
        
        agency.GetInformedByWhistleblower("Edward Snowden", "Turkey wants to be a North Korea");



        //if (agency.NewNews is null)
        //{
        //    agency.NewNews = SubscriberOne;
        //}
        //agency.NewNews+= SubscriberTwo;
        //agency.NewNews("Corona Pandemy finally ends");
        //agency.NewNews("Java is dead .Long Live C#");


    }


    public static void SubscriberOne(string news)
    {
        Console.WriteLine("One: Thanks for the News");
        Console.WriteLine(news);
    }

    public static void SubscriberTwo(string news)
    {
        Console.WriteLine("Two: Holy shit. What happened?");
        Console.WriteLine(news);
    }
}