
namespace OOP.WriterContext
{
    /// <summary>
    /// Default writer to writer structure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class WriterBase<T> : IWriter<T> where T : class
    {
        /// <summary>
        /// A counter to indicate the number of object
        /// </summary>
        protected int _count = 0;
    
        public event EventHandler<T> OnWrite = null!;

        /// <summary>
        /// Write a separator in the screen
        /// </summary>
        /// <param name="breakLineAfter"></param>
        /// <param name="breakLineBefore"></param>
        public void WriteSeparator(bool breakLineAfter = false, bool breakLineBefore = false)
        {
            if (breakLineBefore == true)
            {
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            if (breakLineAfter == true)
            {
                Console.WriteLine();
            }
        }

        public abstract void Write(IEnumerable<T> objs);

        /// <summary>
        /// On write event dispatcher
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnWriteEvent(T obj)
        {
            OnWrite?.Invoke(this, obj);
        }
    }
}