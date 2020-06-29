using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace GameEngine
{
    public class Inventory
    {
        public string Name {get;set;}
        public string Display {get;set;} = "View (I)nventory" ;
        public string Hotkey {get;set;} = "I" ;

        public List<InventoryItem> Items {get;set;}

        public IEnumerable<InventoryItem> GetHeldItems()
        {
            return Items.Where(i => i.IsHeld == true) ;
        }

        public void Modify(string id, bool bContains)
        {
            foreach(var item in Items.Where(i => i.Id == id))
            {
                item.IsHeld = bContains ;
            }
        }

        public override string ToString()
        {
            string ret = string.Format("Contents of {0}:\n\n", Name) ;

            var heldItems = GetHeldItems() ;

            if(heldItems.Count() > 0)
            {
                foreach(var item in GetHeldItems())
                {
                    ret += string.Format("+ {0}", item.DisplayName) ;
                }
            }
            else 
            {
                ret += "< EMPTY >" ;
            }

            return ret ;
        }
    }

    public class InventoryItem
    {
        public string Id {get;set;}
        public string DisplayName {get;set;}
        public bool IsHeld {get;set;} = false;
    }
}