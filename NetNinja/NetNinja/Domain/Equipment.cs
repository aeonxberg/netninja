using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.Domain
{
    public class Equipment
    {
        string name;
        int strength;
        int intelligence;
        int agility;
        int price;
        string imageURL;
        CategoryEnum category;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }

        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }


        internal CategoryEnum Category
        {
            get { return category; }
            set { category = value; }
        }


        public void newEquipment(string name, int str, int intel, int agl, int price, CategoryEnum cat, string ImageUrl)
        {
            // TODO: Complete member initialization
            this.name = name;
            strength = str;
            intelligence = intel;
            agility = agl;
            this.price = price;
            this.category = cat;
            imageURL = ImageUrl;
        }
    }
}
