using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.Domain
{
    class DummyEquipmentRepository : IEqpRepository
    {
        public List<Equipment> GetEqp()
        {
            var equipments = new List<Equipment>();

            equipments.Add(new Equipment { Name = "TestHead1", Strength = 10, Intelligence = 0, Agility = 0, Price = 200, Category = CategoryEnum.Head, ImageURL = null });
            
            return equipments;
        }
    }
}
