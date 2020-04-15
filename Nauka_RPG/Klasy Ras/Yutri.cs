using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public class Yutri : Character
    {
        private Dictionary<AttributeType, int> AttrRacialBonus = new Dictionary<AttributeType, int>()
        {
            { AttributeType.Mind, 10},
            { AttributeType.Sense, 10},
            { AttributeType.Personality, 10},
        };

        private float magicChance = 0.2f;
        private int awakenMagicScore = 5;

       

    }
}
