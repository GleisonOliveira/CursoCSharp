// See https://aka.ms/new-console-template for more information
using OOP.ContentContext;
using POO.ContentContext;
using POO.ContentContext.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        var article = new Article("Como fazer", "how-to");

        #region curso1
        // aulas modulo 1
        var lectureTags = new Lecture("Tags");
        var lectureProps = new Lecture("Propriedades", EContentLevel.Beginner, 2, 50);

        // lista de aulas modulo 1
        var lectures = new List<Lecture>
        {
            lectureTags,
            lectureProps
        };

        // Módulos 1
        var module = new Module("Tags e propriedades", lectures);

        // aulas modulo 2
        var lectureEvents = new Lecture("Events", EContentLevel.Beginner, 2, 50);

        // lista de aulas modulo 2
        var lectures2 = new List<Lecture>
        {
            lectureEvents
        };

        // modulo 2
        var module2 = new Module("Eventos", lectures2);

        // lista de Módulos do curso 1
        var modules = new List<Module>
        {
            module,
            module2
        };

        // curso 1
        var course = new Course("Curso de HTML", "curso-de-html", modules);
        #endregion



        #region curso2
        // aulas modulo 1
        var lectureSelectores = new Lecture("Tipos", EContentLevel.Beginner, 2, 50);

        // lista de aulas modulo 1
        var lecturesCSS = new List<Lecture>
        {
            lectureSelectores,
        };

        // Módulos 1
        var moduleCSS = new Module("Seletores", lecturesCSS);

        // lista de Módulos do curso 1
        var modulesCSS = new List<Module>
        {
            moduleCSS,
        };

        // curso 2
        var course2 = new Course("Curso de CSS", "curso-de-css", modulesCSS);
        #endregion


        var careerItem = new CareerItem("Desenvolvimento WEB", course);
        var careerItem2 = new CareerItem("Desenvolvimento Mobile", course2);
        var careerItems = new List<CareerItem>
        {
            careerItem,
            careerItem2
        };

        var career = new Career("Desenvoledor", "desenvolvedor", careerItems);
        var careers = new List<Career>
        {
            career
        };

        Console.WriteLine($"Artigo: {article.Title}, URL: {article.Url}");
        WriteCareers(careers);
    }

    public static void WriteCareers(IList<Career> careers)
    {
        var careersCount = careers.Count;
        var careersCoursesCount = careers.Sum(x => x.Careers.Count);
        var careersDurationCount = careers.Sum(x => x.Careers.Sum(y => y.Course.DurationInMinutes));


        Console.WriteLine($"Carreiras: {careersCount}, Cursos: {careersCoursesCount}, Duracao: {careersDurationCount} minutos");

        WriteSeparator(true);
        var count = 1;

        foreach (Career career in careers)
        {
            Console.WriteLine($"Carreira {count}: {career.Title}, Cursos: {career.Careers.Count}, Duracao: {career.DurationInMinutes} minutos");

            WriteCourses(career.Careers);
            WriteSeparator();
            count++;
        }
    }

    public static void WriteCourses(IList<CareerItem> careerItems)
    {
        foreach (CareerItem careerItem in careerItems)
        {
            Console.WriteLine($"- Curso: {careerItem.Course.Title}, Duracao: {careerItem.Course.DurationInMinutes}, Módulos: {careerItem.Course.Modules.Count}, Nivel: {careerItem.Course.Level}");
            WriteModules(careerItem.Course.Modules);
            WriteSeparator();
        }
    }

    public static void WriteModules(IList<Module> modules)
    {
        Console.WriteLine();
        var count = 1;

        foreach (Module module in modules)
        {
            Console.WriteLine($" - Modulo {count}: {module.Title}, Duracao: {module.DurationInMinutes}, Aulas: {module.Lectures.Count}");
            WriteLectures(module.Lectures);
            count++;
        }
    }

    public static void WriteLectures(IList<Lecture> lectures)
    {
        var count = 1;

        foreach (Lecture lecture in lectures)
        {
            Console.WriteLine($"  - Aula {count}: {lecture.Title}, Duracao: {lecture.DurationInMinutes}, Nivel: {lecture.Level}");
            count++;
        }

        Console.WriteLine();
    }

    public static void WriteSeparator(bool breakLine = false)
    {
        Console.WriteLine("-----------------------------------------------------");

        if (breakLine == true)
        {
            Console.WriteLine();
        }
    }
}