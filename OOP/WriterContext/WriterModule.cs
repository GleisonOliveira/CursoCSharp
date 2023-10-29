using OOP.ContentContext;

namespace OOP.WriterContext
{
    /// <summary>
    /// Write the modules on screen
    /// </summary>
    public class WriterModule : WriterBase<Module>
    {
        public override void Write(IEnumerable<Module> modules)
        {
            foreach (Module module in modules)
            {
                Console.WriteLine($"---> Modulo {_count + 1}: {module.Title}, Duracao: {module.DurationInMinutes}, Aulas: {module.Lectures.Count()}");
                
                OnWriteEvent(module);

                _count++;
            }
        }
    }
}