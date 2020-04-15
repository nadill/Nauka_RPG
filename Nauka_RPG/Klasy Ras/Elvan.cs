using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public class Elvan : Character
    {
        private Dictionary<AttributeType, int> AttrRacialBonus = new Dictionary<AttributeType, int>()
        {
            { AttributeType.Precision, 10},
            { AttributeType.Mobility, 10},
            { AttributeType.Sense, 10},
        };

        private float magicChance = 0.2f;
        private int awakenMagicScore = 5;




    }
}
