using OOP.ContentContext;

namespace OOP.WriterContext
{
    /// <summary>
    /// Write a the couses on screen
    /// </summary>
    internal class WriterCourse : WriterBase<CareerItem>
    {
        public override void Write(IEnumerable<CareerItem> careerItems)
        {
            foreach (var careerItem in careerItems)
            {
                WriteSeparator(false, true);

                Console.WriteLine($"--> Curso {_count + 1}: {careerItem.Course.Title}, Duracao: {careerItem.Course.DurationInMinutes}, Módulos: {careerItem.Course.Modules.Count}, Nivel: {careerItem.Course.Level}");

                OnWriteEvent(careerItem);

                _count++;
            }
        }
    }
}