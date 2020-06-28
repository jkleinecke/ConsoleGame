using System;

namespace EngineTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false ;

            try {
            var engine = new Engine();
            engine.Run();
            }
            catch(Exception e)
            {
                //-- We Crashed
                Console.WriteLine("Crash: {0}", e.ToString()) ;
            }

            Console.CursorVisible = true ;
        }
    }
}
