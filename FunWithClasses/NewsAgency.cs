public class NewsAgency
{
    //Das Schlüsselwort event schützt das Delegate Newnews vor unberechtigtem Zugriff von außen
    public event NewsEventHandler? NewNews;
    public event NewsEventHandler? FakeNews;

    public void GetInformedByWhistleblower(string name,string report)
    {

        //string? name = null;
        //string upperName=(name ?? "").ToUpperInvariant();

        string news = $"Informant: {name} \nNews: {report}";
        NewNews?.Invoke(news); //informiere Abonnenten (Inform Subscriber)

        


        //NewNews? bedeutet folgendes

        //if (NewNews!=null)
        //{
        //    NewNews.Invoke(news);
        //}
    }
    public NewsAgency()
    {

    }
}