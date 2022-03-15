public class FilterProgramm
{

    public static void Main()
    {

        string[] lines = File.ReadAllLines(@"data\wortliste.txt");

        var query_21 = from l in lines
                       group l by l.ToLower().Last() into linegroups
                       orderby linegroups.Key ascending
                       select new
                       {
                           Letter = linegroups.Key,
                           lineCount = linegroups.Count(),
                           lineAverage = linegroups.Average(l => l.Length),
                           line=linegroups,
                       };

        foreach (var element in query_21)
        {
            Console.WriteLine("{0} {1} {2}", element.Letter, element.lineCount, element.lineAverage);
            foreach(var value in element.line)
            {
                Console.Write(" {0}",value);
            }
            Console.WriteLine();
            
        }






    }

    public static void FilterExercises()

    {
        //Die Folgende Queries kann man Mit LINQ auch ausführen
        string[] lines = File.ReadAllLines(@"data\wortliste.txt");

        //query_1  
        lines.Where(s => s.ToLower().StartsWith("b")).ToList().ForEach(s => Console.WriteLine(s));

        var query_1=from l in lines 
                    where l.ToLower().StartsWith("b") 
                    select l;

        query_1.ToList().ForEach(l => Console.WriteLine(l));
        
        //query_2
        lines.Where(s => s.Length >= 10).ToList().ForEach(s => Console.WriteLine(s));

        //query_3
        lines.TakeLast(5).ToList().ForEach(s => Console.WriteLine(s.ToLower()));

        //query_4
        lines.Take(20).Skip(10).ToList().ForEach(s => Console.WriteLine(s));

        //query_5
        lines.Where(s => s.ToLower().Contains("a") || s.ToLower().Contains("e") || s.ToLower().Contains("i")
         || s.ToLower().Contains("o") || s.ToLower().Contains("u")).ToList().ForEach(s => Console.WriteLine(s));

        //query_6
        lines.Where(s => s.ToUpper().StartsWith("X") || s.ToUpper().StartsWith("Y")).ToList().ForEach(s => Console.WriteLine(string.Join("", s.Reverse().ToList())));

        //query_7
        //V1
        lines.Where(s => s.ToLower().ToList().All(a => a.ToString() == "a" || a.ToString() == "e" || a.ToString() == "o" || a.ToString() == "u" || a.ToString() == "i")).
                                    ToList().ForEach(s => Console.WriteLine(s));
        //V2
        lines.Where(s => s.ToLower().Distinct().All(s => "aeio".Contains(s))).ToList().ForEach(s => Console.WriteLine(s));

        //query_8
        lines.ToList().ForEach(s => Console.WriteLine("{0} {1}", s, s.Length));

        //query_9
        lines.Where(s => s.StartsWith("B") && s.EndsWith("e")).ToList().ForEach(s => Console.WriteLine(s));

        //query_10
        lines.Where(s => s.ToLower().StartsWith("z")).OrderBy(s => s.Length).ToList().ForEach(s => Console.WriteLine(s));

        //query_11
        lines.Where(s => s.StartsWith("a") || s.StartsWith("e") || s.StartsWith("i") ||
        s.StartsWith("o") || s.StartsWith("u")).ToList().ForEach(s => Console.WriteLine(s));


        //query_12
        //V.1
        Console.WriteLine(lines.Max(s => s.Length));
        Console.WriteLine(lines.Min(s => s.Length));

        //V.2
        List<string> query_12 = lines.OrderBy(s => s.Length).ToList();
        Console.WriteLine("{0},{1}", query_12[0].Length, query_12[lines.Length - 1].Length);

        //query_13

        int query_13 = lines.Select(s => s.Length).ToList().Sum();

        //query_14

        lines.Where(s => s.ToLower().Distinct().Count() >= 5).ToList().ForEach(s => Console.WriteLine(s));

        //query_15

        lines.Take(100).ToList().ForEach(s => Console.WriteLine(string.Join("", s.Distinct().ToList())));

        //query_16
        lines.Where(s => s.ToLower().Distinct().Count() == s.Length).ToList().ForEach(s => Console.WriteLine(s));


        //LINQ Exercises
        var query_17=from l in lines
                     where l.ToLower().StartsWith("x") || l.ToLower().StartsWith("y")
                     select l;
        query_17.ToList().ForEach(s => Console.WriteLine(s));

        var query_18 = from l in lines
                       where l.ToLower().StartsWith("x")
                       orderby l.Length descending
                       select l;

        var query_19 = from l in lines
                       where l.ToLower().StartsWith("x")
                       select string.Join("",l.Reverse());

        var query_20 = from l in lines
                       where l.ToLower().StartsWith("x")
                       select new { first=l.ToString().First(), last=l.Last() };
        query_20.ToList().ForEach(s => Console.WriteLine("{0},{1}",s.first,s.last));

        var query_21 = from l in lines
                       group l by l.ToLower().Last() into linegroups
                       select new { 
                           Letter=linegroups.Key, 
                           lineCount=linegroups.Count(),
                           lineAverage=linegroups.Average(l=>l.Length)
                                   };

        foreach(var element in query_21)
        {
            Console.WriteLine("{0} {1} {2}", element.Letter,element.lineCount,element.lineAverage);
        }

        //JOIN example
        var query_22 = from line in lines
                       join line2 in lines.Where(s => s.Length > 10) on string.Join("", line.ToLower().Take(2)) equals
                                            string.Join("", line2.ToLower().TakeLast(2)) into jointlines
                       where line.Length > 10
                       select new
                       {
                           Line = line,
                           Associatedline = jointlines
                       };
        foreach (var element in query_22)
        {
            Console.WriteLine("{0} {1}", element.Line, element.Associatedline);
            foreach (var line in element.Associatedline)
            {
                Console.WriteLine("  -> {0}", line);
            }
        }

    }
    public static bool FilterByX(string s)
    {
        return s.ToLower().StartsWith("x");
    }

    public static void ErsteUbung()
    {
        string[] lines = File.ReadAllLines(@"data\wortliste.txt");
        Console.WriteLine(lines.Length);
        Console.WriteLine(lines.Count());

        Console.WriteLine(lines[10]);
        foreach (string line in lines.TakeLast(10))
        {

            Console.WriteLine(line);
        }
        foreach (string line in lines.Where(s => s.ToLower().StartsWith("x")))
        {
            Console.WriteLine(line);
        }

        foreach (string line in lines.Where(FilterByX))
        {
            Console.WriteLine(line);
        }


        Console.WriteLine(lines.Any(s => s.Length >= 15));

        string first = lines.First(s => s.Length >= 15);
        Console.WriteLine(first);

        //nimm die ereten 10 Elemnte und transformiere in grossgeschriebene Elemente
        IEnumerable<string> query = lines.Take(10).Select(line => line.ToUpper()); //das ist nur eine reine Berechnungsvorschrift!!

        List<string> query_liste = query.ToList();
        Array query_array = query.ToArray();

        query_liste.ForEach(s => Console.WriteLine(s));

        query.OrderByDescending(s => s).ToList().ForEach(s => Console.WriteLine(s));
    }
}