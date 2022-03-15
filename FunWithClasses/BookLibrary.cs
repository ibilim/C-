public class BookLibrary
{
    private Buchexemplar?[] bookCopies;

    //private int capacity = -1;
    public int Capacity
    {
        get => bookCopies.Length;
    }
    public void AddBook(Buchexemplar bookCopy)
    {
        if (this.FindBook(bookCopy.ID) is not null)
        {
            return ;
        }
        for (int i = 0; i < bookCopies.Length; i++)
        {
            if (bookCopies[i] is null)
            {
                bookCopies[i] = bookCopy;
                //Console.WriteLine("{0} was saved to database",bookCopy.Title);
                return;
            }
        }

    }
    public Buchexemplar? FindBook(Guid bookId)
    {
        foreach (Buchexemplar book in this.bookCopies)
        {
            if ((book.ID == bookId.ToString())) //).Equals(bookId,StringComparison.OrdinalIgnoreCase))
            {
                return book;
            } 
        }
        return null;
    }
    public Buchexemplar? FindBook(string title)
    {
        foreach (Buchexemplar? copy in this.bookCopies)
        {
            if (copy is null) { continue; }

            if ((copy.Title == title.ToUpper())) 
            {
                return copy;
            } 
        }
        return null;
    }
    public void Remove(string id)
    {
        if (bookCopies.Length==0) { return; }
        for(int i = 0;i<bookCopies.Length;i=i+1)
        {
            if (bookCopies[i].ID==id)
            {
                bookCopies[i]=null;
                return;
            }
        }
    }
    public BookLibrary(int capacity)
    {
        bookCopies = new Buchexemplar[capacity];
    }
    public int BookNumber()
    {
        int count = 0;
        for (int i=0;i<bookCopies.Length; i=i+1)
        {
            if (bookCopies[i] is not null)
            {
                count =count+1  ;
            }
        }
        return count;
    }
    
}