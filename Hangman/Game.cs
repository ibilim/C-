using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;
public class Game
{
    public int incorrect_trials { get;  private set; }
    public List<string> current_word_state { get; private set; }
    public string[] word_list { get; private set; }
    public string? random_word { get;  private set; }
    public string Player_name { get;  private set; } = "Player";
    public int MinWordLenght { get; private set; }
    public int total_trials { get; private set; }
    public string Result_status { get; private set; }
    public List<Dictionary<string,string>> Player_data { get; set; }
    public int Game_number { get; set; } = 0;

    

    public Game()
    {



    }
    public Game(string[] words)
    {
        this.word_list = words;
        this.incorrect_trials = 0;
        this.total_trials = 0;
        this.MinWordLenght = 0;
    }
    private string SetRandomWord()
    {
        Random rnd = new Random();
        List<string>? query_18 = new List<string>(from l in this.word_list
                                                  where l.Length >= this.MinWordLenght
                                                  select l);
        int random_number = rnd.Next(0, query_18.Count());
        return query_18[random_number].ToUpper();
    }
    private string GetCurrentWordState()
    {
        string current_word_in_string = "";
        foreach (string letter in this.current_word_state)
        {
            current_word_in_string += letter;
        }
        return current_word_in_string;
    }
    private void ResetSettings()
    {
        this.incorrect_trials = 0;
        this.total_trials = 0;
        
    }
    private void Play()
    {
        this.random_word = this.SetRandomWord();
        this.current_word_state = new List<string>();
        for (int i = 0; i < this.random_word.Length; i = i + 1)
        {
            this.current_word_state.Add("_ ");
        }

        if (this.total_trials>0)
        {
            this.incorrect_trials = 0;
            this.total_trials = 0;
        }
        while (true)
        {
            this.GetHangedMan(this.incorrect_trials);
            this.ShowGameresult();
            if (this.incorrect_trials > 9)
            {
                Console.WriteLine(" GAME OVER. YOU LOST :(");
                Console.WriteLine(" The Solution war : {0} \n ->Please Select a number from Menu to continue.", this.random_word);
                this.Result_status = "Failure";
                this.Game_number++;
                this.SaveGameResults_TO_XML();
                this.SaveResultsToJson();
                break;
            }
            if (this.GetCurrentWordState() == this.random_word)
            {
                Console.WriteLine(" ***Congratualtions*** \n You found the word in {0} Trials.\n ->Please Select a number from Menu to continue.", this.total_trials);
                this.Result_status = "SUCCESS";
                this.Game_number++;
                this.SaveGameResults_TO_XML();
                this.SaveResultsToJson();
                break;
            }
            Console.WriteLine(" Please enter a letter to continue:");
            string entered_let = Console.ReadLine();



            while (true)
            {
                if (entered_let.Length > 1 || entered_let is null)
                {
                    Console.WriteLine($" You entered {entered_let} . Please enter a letter at a time:");
                    entered_let = Console.ReadLine();
                }
                else if (int.TryParse(entered_let, out int number))
                {
                    Console.WriteLine(" You entered a number. Please enter a letter:");
                    entered_let = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            this.total_trials++;
            string entered_letter = entered_let.ToUpper();
            if (this.random_word.Contains(entered_letter))
            {
                int index = 0;
                foreach (char letter in this.random_word)
                {
                    if (letter.ToString() == entered_letter)
                    {
                        this.current_word_state[index] = letter.ToString();
                    }
                    index += 1;
                }
            }
            else if (this.random_word.Contains(entered_letter) is not true)
            {
                this.incorrect_trials++;
            }
        }



    }
    public void Run()
    {
        Console.WriteLine(" Welcome to Hangman Game. Please use Menu to set the Game Settings");
        this.Menu();
    }



    private void GetHangedMan(int number)
    {
        string path_hangedman = "hm" + number.ToString() + ".txt";
        string[] hangedman = File.ReadAllLines(path_hangedman);
        foreach (string line in hangedman)
        {
            Console.WriteLine(line);
        }
    }



    private void SetPlayerName()
    {
        Console.WriteLine(" Set Player Name:");
        string playername = Console.ReadLine();
        this.Player_name = playername;
        Console.WriteLine(" Player name was set to: {0} ", playername);
    }



    private void SetMinWordlenght()
    {
        while (true)
        {
            string message = $" Please enter a number between {this.word_list.Min(s => s.Length)} and {this.word_list.Max(s => s.Length)} to set Minimum Word Lenght:";
            Console.WriteLine(message);
            string minwordlenght = Console.ReadLine();
            if (Int16.TryParse(minwordlenght, out short res) is not true)
            {
                continue;
            }
            else if (Int16.Parse(minwordlenght) < this.word_list.Min(s => s.Length) || Int16.Parse(minwordlenght) > this.word_list.Max(s => s.Length))
            {
                continue;
            }
            else if (Int16.Parse(minwordlenght) >= this.word_list.Min(s => s.Length) || Int16.Parse(minwordlenght) <= this.word_list.Max(s => s.Length))
            {
                this.MinWordLenght = Int16.Parse(minwordlenght);
                Console.WriteLine($" Minimum Wordlenght was set to : {this.MinWordLenght} .");
                break;
            }
        }
    }



    private void ShowGameresult()
    {
        Console.WriteLine(" ***Current Game Results***\n Attempted Solution : {0}", this.GetCurrentWordState());
        Console.WriteLine(" Incorrect Answers.......:{0}", this.incorrect_trials);
        Console.WriteLine(" Incorrect Answers left..:{0}", 10 - this.incorrect_trials);
    }



    private void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n-----Menu----");
            Console.WriteLine(" Type 1: To set Player Name (Will be automatically setted to Player if not specified)");
            Console.WriteLine(" Type 2: To set wordlenght (Will be automatically generated if not specified)");
            Console.WriteLine(" Type 3: To start-restart Game");
            Console.WriteLine(" Type 4: To show LogData");
            Console.WriteLine(" Type 5: To Exit game");
            Console.WriteLine($"\n ****Current Game Settings****\n" +
            $" Player name.........: {this.Player_name}\n" +
            $" Minimum WordLenght..: {this.MinWordLenght}\n\n" +
            $" Enter a number from Menü to change the settings or enter 3 to PLAY with PREDEFINED settings:");



            string? answer = null;
            answer = Console.ReadLine();
            while (int.TryParse(answer, out int result) is not true)
            {
                Console.WriteLine($" You Entered {answer} Please enter a number to continue:");
                answer = Console.ReadLine();
                if (int.TryParse(answer, out int res))
                {
                    break;
                }
                continue;
            }
            while (int.TryParse(answer, out int number))
            {
                int menu_number = Int16.Parse(answer);



                while (menu_number < 1 || menu_number > 5)
                {
                    Console.WriteLine(" Please enter a Number between 1 and 5:");
                    answer = Console.ReadLine();
                    menu_number = Int16.Parse(answer);
                }
                while (menu_number < 6 && menu_number > 0)
                {
                    if (menu_number == 1)
                    {



                        this.SetPlayerName();
                        break;
                    }
                    else if (menu_number == 2)
                    {



                        this.SetMinWordlenght();
                        break;
                    }
                    else if (menu_number == 3)
                    {
                        this.Play();
                        break;
                    }
                    else if (menu_number == 4)
                    {
                        if (this.total_trials == 0)
                        {
                            Console.WriteLine(" You have not started the Game yet. PLEASE START THE GAME TO SEE LOG DATA!");
                            break;
                        }
                        this.ReadFromXml();
                        break;
                    }
                    else if (menu_number == 5)
                    {
                        this.Exit();
                    }
                }
                break;
            }
        }



    }
    private void SaveGameResults_TO_XML() // Create multi enter points
    {
        string date = DateTime.Now.ToString();
        if (File.Exists("Log.xml") is not true)
        {
            XmlDocument xml_doc = new XmlDocument();
            string xml_data = "<statistik>" +
            "<spiel>" +
            "<zeitpunkt> " + date + "</zeitpunkt>" +
            "<anzahlVersuche> " + this.total_trials.ToString() + "</anzahlVersuche>" +
            "<loesungswort>" + this.random_word + "</loesungswort>" +
            "<erfolgreich>" + this.Result_status + "</erfolgreich>" +
            "</spiel>" +
            "</statistik> ";
            xml_doc.LoadXml(xml_data);
            xml_doc.Save("Log.Xml");
        }
        else
        {
            XDocument xdoc = XDocument.Load("Log.xml");
            XElement root = xdoc.Element("statistik");
            IEnumerable<XElement> rows = root.Descendants("spiel");
            XElement firstRow = rows.First();
            firstRow.AddBeforeSelf(
            new XElement("spiel",
            new XElement("zeitpunkt", date),
            new XElement("anzahlVersuche", this.total_trials.ToString()),
            new XElement("loesungswort", this.random_word),
            new XElement("erfolgreich", this.Result_status)));
            xdoc.Save("Log.xml");
        }
    }
    private void SaveResultsToJson()
    {
        if (File.Exists("Log.json") is not true)
        {
            var game_data = new Game
            {
                Player_data = new List<Dictionary<string, string>>()
                {
                    new Dictionary<string, string>()
                    {
                    ["Player_name"] = this.Player_name,
                    ["Play_number"]=this.Game_number.ToString(),
                    ["Date"] = DateTime.Now.ToString(),
                    ["Player_Solution"] = this.GetCurrentWordState(),
                    ["Solution"] = this.random_word,
                    ["Result_status"] = this.Result_status,
                    ["Incorrect_Attempts"] = this.incorrect_trials.ToString(),
                    ["Total_Attempts"] = this.total_trials.ToString(),

                    }
                }
            };
      
            var json_options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = false };
            string json_data = JsonSerializer.Serialize(game_data, json_options);
            string json_file_name = "Log.json";
            File.WriteAllText(json_file_name, json_data);

        }
        else if (File.Exists("Log.json"))
        {
            string json_string = File.ReadAllText("Log.json");


            var game_dat = JsonSerializer.Deserialize<Game>(json_string);


            game_dat.Player_data.Add(new Dictionary<string, string>()
            {
                ["Player_name"] = this.Player_name,
                ["Play_number"]=this.Game_number.ToString(),
                ["Date"] = DateTime.Now.ToString(),
                ["Player_Solution"] = this.GetCurrentWordState(),
                ["Solution"] = this.random_word,
                ["Result_status"] = this.Result_status,
                ["Incorrect_Attempts"] = this.incorrect_trials.ToString(),
                ["Total_Attempts"] = this.total_trials.ToString(),
            });

            string json_file_name = JsonSerializer.Serialize(game_dat);
            File.WriteAllText("Log.json", json_file_name);

        }
    }
    private void ReadFromXml()
    {
        XElement root = XElement.Load("Log.xml");
        IEnumerable<XElement> elements = from el in root.Elements()
                                         select el;
        foreach (XElement element in elements)
        {
            Console.WriteLine(element);
        }
    }
    private void Exit()
    {
        Environment.Exit(0);
    }



}