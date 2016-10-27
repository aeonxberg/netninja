using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.Domain
{
    class Ninja
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int strength;

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        int intelligence;

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }
        int agility;

        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }
        int gold;

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        string imageURL;

        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }
        Equipment head;

        public Equipment Head
        {
            get { return head; }
            set { head = value; }
        }
        Equipment shoulders;

        public Equipment Shoulders
        {
            get { return shoulders; }
            set { shoulders = value; }
        }
        Equipment chest;

        public Equipment Chest
        {
            get { return chest; }
            set { chest = value; }
        }
        Equipment pants;

        public Equipment Pants
        {
            get { return pants; }
            set { pants = value; }
        }
        Equipment boots;

        public Equipment Boots
        {
            get { return boots; }
            set { boots = value; }
        }

        public void newNinja(string name, int str, int intl, int agl, int gold, Equipment head,Equipment shoulders,Equipment chest,Equipment pants,Equipment boots,)
        {
            this.name = name;
            this.strength = str;
            this.intelligence=intl;
            this.agility=agl;
            this.gold=gold;
            this.head=head;
            this.shoulders=shoulders;
            this.chest=chest;
            this.pants=pants;
            this.boots=boots;
        }
    }
}
