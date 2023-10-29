namespace OOP.WriterContext
{
    public interface IWriter<T> where T : class
    {
        /// <summary>
        /// Event to notify when object is writed
        /// </summary>
        event EventHandler<T> OnWrite;

        /// <summary>
        /// Write the object on screen
        /// </summary>
        /// <param name="objs"></param>
        void Write(IEnumerable<T> objs);
    }
}