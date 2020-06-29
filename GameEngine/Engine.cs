using System;
using System.IO;
using System.Text.Json;

namespace GameEngine
{
    public class Engine
    {
        Room m_prevRoom = null;
        Room m_curRoom = null;

        Game m_Game = null ;

        enum Mode
        {
            Room,
            Inventory
        }
        Mode m_eMode = Mode.Room;

        public Engine()
        {

        }

        public void Run()
        {
            m_Game = ReadGameFile() ;

            LoadRoom(m_Game.Entrypoint);

            while (m_curRoom != null)
            {
                Console.ResetColor() ;
                Console.Clear();

                switch(m_eMode)
                {
                    case Mode.Room:
                        Run_Room() ;
                        break ;
                    case Mode.Inventory:
                        Run_Inventory() ;
                        break ;
                }
               
            }

            Console.Clear();
            Console.WriteLine("The End!!");
        }

        private void Run_Inventory()
        {
            Console.WriteLine(m_Game.Inventory.ToString()) ;
            Console.WriteLine("\nPress any key to return") ;
            Console.ReadKey() ;
            m_eMode = Mode.Room ;
        }

        private void Run_Room()
        {
            m_curRoom.DisplayDescription();
            Console.WriteLine("\n");

            var roomLink = m_curRoom.GetNextRoomLink(m_Game);

            if(roomLink.StartsWith("$pickup"))
            {
                string[] split = roomLink.Split(":") ;

                m_Game.Inventory.Modify(split[1], true) ;
                //-- load the previous room again from file
                LoadRoom(m_prevRoom.Name);                
            }
            else if(roomLink.StartsWith("$drop"))
            {
                string[] split = roomLink.Split(":") ;

                m_Game.Inventory.Modify(split[1], false) ;
                //-- load the previous room again from file
                LoadRoom(m_prevRoom.Name);
            }
            else
            {
                switch(roomLink)
                {
                    case "$inventory":
                        m_eMode = Mode.Inventory;
                        break ;
                    case "$repeat":
                        //-- do nothing and let this same room run again
                        break;
                    case "$previous":
                        //-- load the previous room again from file
                        LoadRoom(m_prevRoom.Name);
                        break;
                    case "$end":
                        m_curRoom = null;
                        break;
                    case "$quit":
                        return ;
                        //break ;
                    default:
                        //-- must be a new room, load it
                        LoadRoom(roomLink);
                        break;
                }
            }
        }

        private Game ReadGameFile()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
            path = Path.Combine(path, "Game.json");
            
            using (StreamReader reader = File.OpenText(path))
            {
                return JsonSerializer.Deserialize<Game>(reader.ReadToEnd());
            }
        }

        private void LoadRoom(string name)
        {
            m_prevRoom = m_curRoom;

            string filename = name ;

            if(filename.EndsWith(".json") == false)
            {
                // add the json extension if it is missing
                filename += ".json" ;
            }

            m_curRoom = ReadRoomFile(filename);
            m_curRoom.Name = name;
        }

        private Room ReadRoomFile(string filename)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content");
            path = Path.Combine(path, "Rooms");
            path = Path.Combine(path, filename);
            
            using (StreamReader reader = File.OpenText(path))
            {
                return JsonSerializer.Deserialize<Room>(reader.ReadToEnd());
            }
        }
    }
}
