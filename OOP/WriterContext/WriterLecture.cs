using OOP.ContentContext;

namespace OOP.WriterContext
{
    /// <summary>
    /// Write the lectures on screen
    /// </summary>
    public class WriterLecture : WriterBase<Lecture>
    {
        public override void Write(IEnumerable<Lecture> lectures)
        {
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"----> Aula {_count + 1}: {lecture.Title}, Duracao: {lecture.DurationInMinutes}, Nivel: {lecture.Level}");

                OnWriteEvent(lecture);

                _count++;
            }
        }
    }
}