public class AuthorFilter: IBuchexemplarFilter
{
    public string Author { get; set; }


    public AuthorFilter(string author)
    {
        this.Author = author;
    }

    public bool Matches(Buchexemplar sample)
    {
        return sample.Authors.Contains(this.Author.ToUpper());
    }
}