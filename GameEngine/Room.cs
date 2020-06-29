using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameEngine
{
    public class Room
    {
        [JsonIgnore]
        public string Name { get; set; }


        // Load from file
        public string Description { get; set; }
        public string ChoicePrompt { get; set; }
        public List<RoomChoiceOption> Choices { get; set; }

        public Room()
        {
        }

        public void DisplayDescription()
        {
            Console.Write(Description);

        }

        public string GetNextRoomLink(Game game)
        {
            Console.Write(ChoicePrompt);
            Console.WriteLine("\n");

            int nLeftPos = Console.CursorLeft;
            int nTopPos = Console.CursorTop;

            int nIndex = 0;
            bool bSelected = false ;
            do
            {
                Console.SetCursorPosition(nLeftPos, nTopPos);
                DisplayChoices(nIndex) ;
                Console.WriteLine() ;
                Console.WriteLine("{0}", game.Inventory.Display) ;
    
                var keyInfo = Console.ReadKey(true);

                if(keyInfo.KeyChar.ToString().ToUpper() == game.Inventory.Hotkey.ToUpper())
                {
                    // user selected the inventory screen instead
                    return "$inventory" ;
                }
                else
                {
                    switch(keyInfo.Key)
                    {
                        case ConsoleKey.DownArrow:
                            // increase the index, wrap back to 0
                            ++nIndex ;

                            if(nIndex >= Choices.Count)
                            {
                                nIndex = 0 ;
                            }
                            break ;
                        case ConsoleKey.UpArrow:
                            // decrease the index, wrap back to a bottom of the list
                            --nIndex ;

                            if(nIndex < 0)
                            {
                                nIndex = Choices.Count - 1 ;
                            }
                            break ;
                        case ConsoleKey.Spacebar:
                            bSelected = true ;
                            break ;
                        case ConsoleKey.Enter:
                            bSelected = true ;
                            break ;
                        case ConsoleKey.Escape:
                            return "$quit" ;
                            //break ;
                    }
                }
            } while (!bSelected);

            return Choices[nIndex].Link;
        }

        private void DisplayChoices(int selectedIndex)
        {
            for(int i = 0; i < Choices.Count; ++i)
            {
                var option = Choices[i] ;

                if( i == selectedIndex )
                {
                    SetConsoleColors_Selected() ;
                }
                else
                {
                    SetConsoleColors_Normal() ;
                }

                Console.WriteLine(option.Description) ;
            }

            SetConsoleColors_Normal() ;
        }

        private void SetConsoleColors_Selected()
        {
            Console.BackgroundColor = ConsoleColor.White ;
            Console.ForegroundColor = ConsoleColor.Black ;
        }

        private void SetConsoleColors_Normal()
        {
            Console.ResetColor() ;
            //Console.BackgroundColor = ConsoleColor.Black ;
            //Console.ForegroundColor = ConsoleColor.White ;
        }
    }

    public class RoomChoiceOption
    {
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
