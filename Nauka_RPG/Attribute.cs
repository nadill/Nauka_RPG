using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nauka_RPG
{
    public enum AttributeType
    {
        Strength,
        Constitution,
        Precision,
        Mobility,
        Mind,
        Sense,
        Personality,
        Willpower,
        Magic,
        Soul,
        Sanity,
    }
    public class Attribute
    {

        public string attributeName;
        public int attributeValue;
        public AttributeType attributeType;
        public int attributeBonus;
        public bool IsPhysical { get; }
        private int attributeExp;
        private int expToLvl;
       

        public Attribute(string _attrName, int _attrValue, bool _isPhysical)
        {
            attributeName = _attrName;
            attributeValue = _attrValue;
            IsPhysical = _isPhysical;
            attributeExp = 0;
            
            
        }

        public void CalculateAttribute()
        {   
            attributeBonus = attributeValue / 10;
            
            expToLvl = attributeBonus;
        }

        

        


    }
}
