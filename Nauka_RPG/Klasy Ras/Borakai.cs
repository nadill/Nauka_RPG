using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public class Borakai : Character
    {
        private Dictionary<AttributeType, int> AttrRacialBonus = new Dictionary<AttributeType, int>()
        {
            { AttributeType.Strength, 10},
            { AttributeType.Constitution, 10},
            { AttributeType.Willpower, 10},
        };

        private float magicChance = 0.15f;
        private int awakenMagicScore = 4;

        
        private void ApplyRacialBonuses()
        {
            this.physicalResistance += 1;
            this.maxHeavyWounds += 1;
            foreach (var attr in AttrRacialBonus.Keys)
            {
                attributes[attr].attributeValue += 10;
            }
        }
      
    }
}
