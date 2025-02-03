using Microsoft.Extensions.Hosting;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class PeopleData
    {
        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate",
            "Nigel",
            "Lowe",
            "Martin",
            "Kristoffer",
            "Jone",
            "Andreas",
            "Jostein",
            "Alex",
            "Aksel",
            "Sander",
            "Abdi",
            "Kristian",
            "Erlend",
            "Espen",
            "Enock",
            "Giar",
            "Petter",
            "Steven",
            "Tonnes",
            "Noah",
            "Magnus",
            "Hans",
            "Nikolai",
            "Hakon",
            "Martin",
            "Erik"

        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"

        };
        private List<string> _domain = new List<string>()
        {
            "bbc.co.uk",
            "google.com",
            "theworld.ca",
            "something.com",
            "tesla.com",
            "nasa.org.us",
            "gov.us",
            "gov.gr",
            "gov.nl",
            "gov.ru"
        };
        private List<string> _firstword = new List<string>()
        {
            "The",
            "Two",
            "Several",
            "Fifteen",
            "A bunch of",
            "An army of",
            "A herd of"


        };
        private List<string> _secondword = new List<string>()
        {
            "Orange",
            "Purple",
            "Large",
            "Microscopic",
            "Green",
            "Transparent",
            "Rose Smelling",
            "Bitter"
        };
        private List<string> _thirdword = new List<string>()
        {
            "Buildings",
            "Cars",
            "Planets",
            "Houses",
            "Flowers",
            "Leopards"
        };

        private List<Person> _people = new List<Person>();


        public List<Person> People { get { return _people; } }


        public PeopleData()
        {
            Random authorRandom = new Random();
            Random ageRandom = new Random();
            

            for (int x = 1; x < 1000; x++)
            {
                Person person = new Person();
                person.Id = x;
                string firstname = _firstnames[authorRandom.Next(_firstnames.Count)];
                string lastname = _lastnames[authorRandom.Next(_lastnames.Count)];

                person.Name =  $"{firstname} { lastname}";
                person.Email = $"{firstname}.{lastname}@{_domain[authorRandom.Next(_domain.Count)]}";
                person.Age = ageRandom.Next(20, 99);
                person.OfficeId = authorRandom.Next(1, 3);
                _people.Add(person);
            }




        }
    }
}
