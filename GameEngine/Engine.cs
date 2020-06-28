using System;
using System.IO;
using System.Text.Json;

namespace EngineTest1
{
    public class Engine
    {
        Room m_prevRoom = null;
        Room m_curRoom = null;

        public Engine()
        {

        }

        public void Run()
        {

            LoadRoom("start");

            while (m_curRoom != null)
            {
                Console.ResetColor() ;
                Console.Clear();

                m_curRoom.DisplayDescription();
                Console.WriteLine("\n");

                var roomLink = m_curRoom.GetNextRoomLink();

                switch(roomLink)
                {
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

            Console.Clear();
            Console.WriteLine("The End!!");
        }

        private void LoadRoom(string name)
        {
            m_prevRoom = m_curRoom;

            m_curRoom = ReadRoomFile(name + ".json");
            m_curRoom.Name = name;
        }

        private Room ReadRoomFile(string filename)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Rooms");
            path = Path.Combine(path, filename);
            
            using (StreamReader reader = File.OpenText(path))
            {
                return JsonSerializer.Deserialize<Room>(reader.ReadToEnd());
            }
        }
    }
}
