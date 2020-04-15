using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public class Human : Character
    {
        private Dictionary<AttributeType, int> AttrRacialBonus = new Dictionary<AttributeType, int>();

        private float magicChance = 0.1f;
        private int awakenMagicScore = 3;

    }
}
