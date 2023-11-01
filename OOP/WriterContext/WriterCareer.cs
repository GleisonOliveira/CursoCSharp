using OOP.ContentContext;

namespace OOP.WriterContext
{
    /// <summary>
    /// Write a career on screen
    /// </summary>
    internal class WriterCareer : WriterBase<Career>
    {
        public override void Write(IEnumerable<Career> careers)
        {
            WriteHeader(careers);

            foreach (Career career in careers)
            {
                Console.WriteLine($"-> Carreira {_count + 1}: {career.Title}, Cursos: {career.Careers.Count}, Duracao: {career.DurationInMinutes} minutos");

                OnWriteEvent(career);

                _count++;
            }
        }

        /// <summary>
        /// Write the header of careers
        /// </summary>
        /// <param name="careers"></param>
        private void WriteHeader(IEnumerable<Career> careers)
        {
            // Console.Clear();

            var careersCount = careers.Count();
            var careersCoursesCount = careers.Sum(x => x.Careers.Count);
            var careersDurationCount = careers.Sum(x => x.Careers.Sum(y => y.Course.DurationInMinutes));

            Console.WriteLine($"Carreiras: {careersCount}, Cursos: {careersCoursesCount}, Duracao: {careersDurationCount} minutos");

            WriteSeparator(true);
        }
    }
}