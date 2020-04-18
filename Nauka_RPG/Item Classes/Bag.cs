﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG.Character_Classes
{
    public class Bag : Item
    {
        private int bagSize;

        public Bag(string _name, double _value, double _weight, int _bagSize, int _size=1, bool _consumable=false, string _description="") : base(_name, _value, _weight, _size, _consumable, _description)
        {
            name = _name;
            value = _value;
            weight = _weight;
            bagSize = _bagSize;
            size = _size;
            consumable = false;
            description = _description;
        }
    }
}
