using System;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                //Console.CursorVisible = false ;
                var engine = new Engine();
                engine.Run();
            }
            catch(Exception e)
            {
                //-- We Crashed
                Console.WriteLine("Crash: {0}", e.ToString()) ;
            }

            //Console.CursorVisible = true ;
        }
    }
}
