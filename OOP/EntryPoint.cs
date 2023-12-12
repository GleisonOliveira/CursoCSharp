using OOP.ContentContext;
using OOP.ContentContext.Enums;
using OOP.WriterContext;

internal class EntryPoint
{
    public IWriterFactory _writerFactory;

    public EntryPoint(IWriterFactory writerFactory)
    {
        _writerFactory = writerFactory;
    }
    
    public void Start(string[] args)
    {
        var htmlCourse = CreateHTMLCourse();
        var cssCourse = CreateCSSCourse();

        var careerItem = new CareerItem("Desenvolvimento WEB", htmlCourse);
        var careerItem2 = new CareerItem("Desenvolvimento Mobile", cssCourse);

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

        var careerWriter = _writerFactory.GetWriter<Career>();
        careerWriter.OnWrite += OnWriteCarrersEvent;
        careerWriter.Write(careers);

        Console.ReadKey();
    }

    /// <summary>
    /// Create all html lectures
    /// </summary>
    /// <returns></returns>
    private static Dictionary<string, IEnumerable<Lecture>> CreateHTMLLectures()
    {
        var dictionary = new Dictionary<string, IEnumerable<Lecture>>();
        dictionary.Add("Tags e propriedades", new List<Lecture>
        {
           new Lecture("Propriedades", EContentLevel.Beginner, 2, 50),
            new Lecture("Propriedades", EContentLevel.Beginner, 2, 50)
        });
        dictionary.Add("Eventos", new List<Lecture>
        {
           new Lecture("Events", EContentLevel.Beginner, 2, 50)
        });

        return dictionary;
    }

    /// <summary>
    /// Create the html course
    /// </summary>
    /// <returns></returns>
    private static Course CreateHTMLCourse()
    {
        var htmlLectures = CreateHTMLLectures();
        var modulesHTML = new List<Module>();

        foreach (var htmlLecture in htmlLectures)
        {
            modulesHTML.Add(new Module(htmlLecture.Key, htmlLecture.Value));
        }


        return new Course("Curso de HTML", "curso-de-html", modulesHTML);
    }

    /// <summary>
    /// Create all css course lecture
    /// </summary>
    /// <returns></returns>
    private static Dictionary<string, IEnumerable<Lecture>> CreateCSSLectures()
    {
        var dictionary = new Dictionary<string, IEnumerable<Lecture>>();
        dictionary.Add("Seletores", new List<Lecture>
        {
            new Lecture("Tipos", EContentLevel.Beginner, 2, 50),
            new Lecture("Descendentes", EContentLevel.Beginner, 2, 50)
        });

        return dictionary;
    }

    /// <summary>
    /// Create the CSS course
    /// </summary>
    /// <returns></returns>
    private static Course CreateCSSCourse()
    {
        var cssLectures = CreateCSSLectures();
        var modulesCSS = new List<Module>();

        foreach (var cssLecture in cssLectures)
        {
            modulesCSS.Add(new Module(cssLecture.Key, cssLecture.Value));
        }

        return new Course("Curso de CSS", "curso-de-css", modulesCSS);
    }

    /// <summary>
    /// On career write the career call couse write 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="career"></param>
    private void OnWriteCarrersEvent(object? sender, Career career)
    {
        var careerItemWriter = _writerFactory.GetWriter<CareerItem>();
        careerItemWriter.OnWrite += OnWriteCoursesEvent;
        careerItemWriter.Write(career.Careers);
    }

    /// <summary>
    /// On couse write course call module write
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="careerItem"></param>
    private void OnWriteCoursesEvent(object? sender, CareerItem careerItem)
    {
        var careerItemWriter = _writerFactory.GetWriter<Module>();
        careerItemWriter.OnWrite += OnWriteModulesEvent;
        careerItemWriter.Write(careerItem.Course.Modules);

    }

    /// <summary>
    /// On module write call lecture write
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="module"></param>
    private void OnWriteModulesEvent(object? sender, Module module)
    {
        _writerFactory.GetWriter<Lecture>().Write(module.Lectures);
    }
}