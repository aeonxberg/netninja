using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.Domain
{
    class StoreModel
    {
        Equipment dummyEqp = new Equipment();
        List<Equipment> equipmentInCategory = new List<Equipment>();
        Dictionary<CategoryEnum, List<Equipment>> equipmentCollection = new Dictionary<CategoryEnum, List<Equipment>>();

        public List<Equipment> headList()
        //Test Data
        {
           // equipmentInCategory.Add(dummyEqp);
            equipmentInCategory.Add(new Equipment{Name = "TestHead2", Strength=0, Intelligence= 5, Agility = 5, Price =600, CategoryEnum.Head, null});
            return equipmentInCategory;
        }

        public List<Equipment> shoulderList()
        //Test Data
        {
       /*     equipmentInCategory.Add(new Equipment("TestShoulder", 10, 0, 0, 200, CategoryEnum.Shoulders, null));
            equipmentInCategory.Add(new Equipment("TestShoulder2", 0, 5, 5, 600, CategoryEnum.Shoulders, null));
      */      return equipmentInCategory;
        }

        public void generateCollection()
        {
            equipmentCollection.Add(CategoryEnum.Head, headList());
            equipmentCollection.Add(CategoryEnum.Shoulders, shoulderList());
        }

        public Dictionary<CategoryEnum, List<Equipment>> getCollection()
        {
            generateCollection();
            return equipmentCollection;
        }
        
    }
}
