using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.Domain
{
    class Equipment
    {
        string name;
        int strength;
        int intelligence;
        int agility;
        int price;
        string imageURL;
        categoryEnum category;


        public Equipment(string name, int str, int intel, int agl, int price, categoryEnum cat, string ImageUrl)
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
