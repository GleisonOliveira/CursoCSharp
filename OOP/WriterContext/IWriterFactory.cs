namespace OOP.WriterContext
{

    public interface IWriterFactory
    {
        /// <summary>
        /// Get the writer based on type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IWriter<T> GetWriter<T>() where T : class;
    }
}