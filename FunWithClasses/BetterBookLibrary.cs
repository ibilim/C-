public class BetterBookLibrary
{
    private readonly List<Buchexemplar> bookCopies;

    public void AddBook(Buchexemplar bookCopy)
    {
        if (this.FindBook_id(bookCopy.ID) is not null)
        {
            //Console.WriteLine("The Book already exists.");
            return;
        }

        bookCopies.Add(bookCopy);
        //Console.WriteLine("{0} was added to the Library", bookCopy.Title);
        //Console.WriteLine("The Number of Books in Library; {0} ", this.GetBookNumber());
    }

    public Buchexemplar? FindBook(BookSampleFilterDelegate filter)
    {
        foreach(Buchexemplar book in bookCopies)
        {
            //Hier rufen wir das Delegate mit dem Aktuell betrachten Buchexamplar auf.
            if (filter(book)) //vom filter(book) bekommen wir einen Boolean Wert.
            {
                return book;
            }
        }
        return null;
    }

    public Buchexemplar? FindBook(IBuchexemplarFilter filter)
    {
        foreach(Buchexemplar  sample in bookCopies)
        {
            if (filter.Matches(sample))
            {
                return sample;
            }
        }
        return null;
    }
    public Buchexemplar? FindBook_id(string bookId)
    {
        foreach (Buchexemplar book in this.bookCopies)
        {
            if ((book.ID == bookId)) //).Equals(bookId,StringComparison.OrdinalIgnoreCase))
            {
                return book;
            } 
        }
        return null;
    }
    public Buchexemplar? FindBook(string title)
    {
        foreach (Buchexemplar copy in this.bookCopies)
        {

            if ((copy.Title == title.ToUpper())) 
            {
                return copy;
            } 
        }
        return null;
    }
    public void Remove(string id)
    {
        if (bookCopies.Count==0) { return; }
        Buchexemplar? book_to_remove=null;
        foreach (Buchexemplar book in bookCopies)
        {
            if (book.ID==id)
            {
                book_to_remove = book;
                break;
            }
        }
        bookCopies.Remove(book_to_remove);
    }
    public  BetterBookLibrary()
    {
        this.bookCopies = new List<Buchexemplar>();
    }

    public int GetBookNumber()
    {
        return bookCopies.Count;
    }
    
    public void PrintCopies()
    {
        foreach (Buchexemplar book in bookCopies)
        {
            book.Describe();
        }
    }
}