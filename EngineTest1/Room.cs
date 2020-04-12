﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EngineTest1
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

        public string GetNextRoomLink()
        {
            Console.Write(ChoicePrompt);
            int nLeftPos = Console.CursorLeft;
            int nTopPos = Console.CursorTop;
            Console.WriteLine("\n");

            char chId = 'a';

            foreach(var option in Choices)
            {
                Console.WriteLine("{0}. {1}", chId, option.Description);
                ++chId;
            }

            int nIndex = -1;
            bool bValid = false;
            do
            {
                Console.SetCursorPosition(nLeftPos, nTopPos);

                var keyInfo = Console.ReadKey();
                var selection = keyInfo.KeyChar;

                nIndex = selection - 'a';
                bValid = nIndex >= 0 && nIndex < Choices.Count;

                if (bValid)
                {
                    break;
                }

                Console.SetCursorPosition(nLeftPos, nTopPos);
                Console.Write(' ');
            } while (!bValid);

            return Choices[nIndex].Link;
        }
    }

    public class RoomChoiceOption
    {
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
