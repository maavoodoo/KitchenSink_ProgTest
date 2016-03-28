using System.Diagnostics;

namespace KitchenSink.Module
{
    public class ConsoleModule : IConsoleModule
    {
        public void WriteOutput(string text)
        {
            Debug.WriteLine(text);
        }
    }
}
