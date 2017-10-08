using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2
{
    class ItemManager
    {
            private static ItemManager instance = null;
            private List<Item> itemList;

            private ItemManager()
            {
                itemList = new List<Item>();
            }

            public static ItemManager Init()
            {
                if (instance == null)
                {
                    instance = new ItemManager();
                }
                return instance;
            }

            //Ideda prekę į sąrašą
            public void AddItem(Item item)
            {
                itemList.Add(item);
            }

            //Pasako ar sąraše jau yra tokia prekė
            public bool Exists(Item newItem)
            {
                return itemList.Contains(newItem);
            }

            //Grąžina pigiausią prekę su tokių pat pavadinimu
            public Item FindCheapest(Item newItem)
            {
                foreach (Item oldItem in instance.itemList)
                {
                    if (new ItemNameCompare().Compare(oldItem, newItem) == 0 && new ItemPriceCompare().Compare(oldItem, newItem) < 0)
                        newItem = oldItem;

                }
                return newItem;
            }

            public int Count()
            {
                return itemList.Count();
            }

            public void ClearList()
            {
                itemList.Clear();
            }
        }
    }

