using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.Domain
{
    class StoreModel
    {
        List<Equipment> equipmentInCategory = new List<Equipment>();
        Dictionary<string, List<Equipment>> equipmentCollection = new Dictionary<string, List<Equipment>>();

        public List<Equipment> headList()
        {
            equipmentInCategory.Add(new Equipment("TestHead1",10,0,0,200,categoryEnum.Head,null));
            equipmentInCategory.Add(new Equipment("TestHead2", 0, 5, 5, 600, categoryEnum.Head, null));
            return equipmentInCategory;
        }

        public List<Equipment> shoulderList()
        {
            equipmentInCategory.Add(new Equipment("TestShoulder", 10, 0, 0, 200, categoryEnum.Shoulders, null));
            equipmentInCategory.Add(new Equipment("TestShoulder2", 0, 5, 5, 600, categoryEnum.Shoulders, null));
            return equipmentInCategory;
        }

        public void generateCollection()
        {
            equipmentCollection.Add(categoryEnum.Head, headList());

        }
        
    }
}
