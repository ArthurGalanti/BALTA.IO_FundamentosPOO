using Balta.ContentContext;
using Balta.NotificationContext;

internal class Program
{
    private static void Main(string[] args)
    {
        var articles = new List<Article>();
        articles.Add(new Article("Article about OPP", "object-oriented"));
        articles.Add(new Article("Article about .NET", "dotnet-concepts"));
        articles.Add(new Article("Article about Xamarin", "dotnet-xamarin"));

        var courses = new List<Course>();
        courses.Add(new Course("Fundamentals OPP", "oop-fundamentals"));
        courses.Add(new Course("Fundamentals C#", "csharp-fundamentals"));
        courses.Add(new Course("Fundamentals SQL", "sql-fundamentals"));

        courses.Add(new Course("Concepts of Dart", "dart-concepts"));
        courses.Add(new Course("First App", "first-app"));

        var careers = new List<Career>();
        careers.Add(new Career("Backend", "backend-dotNet"));
        var careerDotnet = careers.First<Career>(x => x.Url == "backend-dotNet"); // Usado o Find por URL, pois toda vez o Guid será aleatório
        careerDotnet.Items.Add(new CareerItem(2, "Learn SQL", "", courses.First<Course>(x => x.Url == "sql-fundamentals")));
        careerDotnet.Items.Add(new CareerItem(1, "Start here", "", courses.First<Course>(x => x.Url == "csharp-fundamentals")));
        careerDotnet.Items.Add(new CareerItem(3, "OOP", "", courses.First<Course>(x => x.Url == "oop-fundamentals")));

        careers.Add(new Career("Mobile", "mobile-flutter"));
        var careerFlutter = careers.First<Career>(x => x.Url == "mobile-flutter"); // Usado o Find por URL, pois toda vez o Guid será aleatório
        careerFlutter.Items.Add(new CareerItem(2, "Create your first App", "", courses.First<Course>(x => x.Url == "first-app")));
        careerFlutter.Items.Add(new CareerItem(1, "Learn Dart", "", courses.First<Course>(x => x.Url == "dart-concepts")));


        Console.WriteLine("*             ARTICLES             *");
        foreach (Article article in articles)
        {
            Console.WriteLine(article.Id);
            Console.WriteLine(article.Title);
            Console.WriteLine(article.Url);
        }


        Console.WriteLine("*             CAREERS             *");
        foreach (var career in careers)
        {
            Console.WriteLine(career.Title);
            foreach (var item in career.Items.OrderBy(x => x.Order))
            {
                Console.WriteLine($"{item.Order} - {item.Title}");
                Console.WriteLine(item.Course?.Title);
                Console.WriteLine(item.Course?.Level);

                foreach (var notification in item.Notifications)
                {
                    Console.WriteLine($"{notification.Property} - {notification.Message}");
                }
            }

        }

    }
}