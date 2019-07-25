using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTestlet
{
    class Testlet
    {
        public string TestletId;

        //public Testlet(string testletId, List<Item> items)
        public Testlet(string testletId)
        {
            this.TestletId = testletId;
            //Console.WriteLine(this.TestletId);
                        
        }

        public void DoMagic(List<Item> items)
        {
            Console.WriteLine("Total Number of Questions:"+ items.Count);

            var random = new Random();
            
            int index, doneCount=0;
            List<int> vList = new List<int>();
            bool intExist = true;
            
            for (index = 0; doneCount < items.Count;)
            {
                index = random.Next(items.Count);
                doneCount++;

                if ((doneCount <= 2) && (items[index].ItemType.ToString() == "Pretest"))
                {
                    if (intExist = vList.Contains(index))
                    {
                        doneCount--;
                    }
                    else
                    {
                        vList.Add(index);
                    }
                }
                else if (doneCount > 2)
                {
                    if ((intExist = vList.Contains(index)))
                    {
                        doneCount--;
                    }
                    else
                    {
                        vList.Add(index);
                    }
                }
                else
                {
                    doneCount--;                    
                }                                              
            }

            foreach (var listIDs in vList)
            {
                Console.WriteLine("  " + items[listIDs].ItemId + "  |  " + items[listIDs].ItemType + "  |  " + items[listIDs].ItemName);
            }                   
            
            //foreach (var listItems in items)
            //{
                //Console.WriteLine(listItems.ItemId + " | " + listItems.ItemType + " | " + listItems.ItemName);
            //}

        }

        static void Main(string[] args)
        {

            List<Item> Items = new List<Item>() {
                new Item(){ ItemId="1", ItemType=ItemTypeEnum.Pretest, ItemName="Pretest Question 1"},
                new Item(){ ItemId="2", ItemType=ItemTypeEnum.Pretest, ItemName="Pretest Question 2"},
                new Item(){ ItemId="3", ItemType=ItemTypeEnum.Pretest, ItemName="Pretest Question 3"},
                new Item(){ ItemId="4", ItemType=ItemTypeEnum.Pretest, ItemName="Pretest Question 4"},
                new Item(){ ItemId="5", ItemType=ItemTypeEnum.Operational, ItemName="Operational Question 1"},
                new Item(){ ItemId="6", ItemType=ItemTypeEnum.Operational, ItemName="Operational Question 2"},
                new Item(){ ItemId="7", ItemType=ItemTypeEnum.Operational, ItemName="Operational Question 3"},
                new Item(){ ItemId="8", ItemType=ItemTypeEnum.Operational, ItemName="Operational Question 4"},
                new Item(){ ItemId="9", ItemType=ItemTypeEnum.Operational, ItemName="Operational Question 5"},
                new Item(){ ItemId="10", ItemType=ItemTypeEnum.Operational, ItemName="Operational Question 6"}                
            };

            Testlet testLet = new Testlet("1");
            testLet.DoMagic(Items);
            
            Console.Read();
        }
    }

    public class Item
    {
        public string ItemId { get; set; }
        public ItemTypeEnum ItemType { get; set; }
        public string ItemName { get; set; }
    }

    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }

}
