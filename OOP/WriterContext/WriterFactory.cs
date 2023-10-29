using OOP.ContentContext;

namespace OOP.WriterContext
{
    /// <summary>
    /// Get a factory based on type
    /// </summary>
    public class WriterFactory : IWriterFactory
    {
        /// <summary>
        /// Get the writer based on type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IWriter<T> GetWriter<T>() where T : class
        {
            return typeof(T) switch
            {
                Type t when t == typeof(Career) => (IWriter<T>)new WriterCareer(),
                Type t when t == typeof(CareerItem) => (IWriter<T>)new WriterCourse(),
                Type t when t == typeof(Lecture) => (IWriter<T>)new WriterLecture(),
                Type t when t == typeof(Module) => (IWriter<T>)new WriterModule(),
                _ => throw new Exception("The writer was not recognized")
            };
        }
    }
}