using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG.Item_Classess
{
    public class Item
    {
        protected string name;
        protected double value;
        protected double weight;
        protected int size;
        protected bool consumable;
        protected string description;
        
        public Item(string _name, double _value, double _weight, int _size=1, bool _consumable = false, string _description="")
        {
            name = _name;
            value = _value;
            weight = _weight;
            size = _size;
            consumable = _consumable;
            description = _description;
        }

    }
}
