using System;
using System.Collections;
using System.Collections.Generic;
using static Nauka_RPG.Utility.SystemRPG;

namespace Nauka_RPG
{
    public class Skill
    {


        public string name;
        public AttributeType linkedAttribute;
        public int skillValue;
        public bool IsPhysical { get; }
        public bool IsExpert { get; }
        public bool bonusAdvantage = false;
        public bool IsSpecialist { get; }


        private int skillExp;
        private int skillToLvl;

        public Skill(string _name, AttributeType _linkedAttr, int _skillValue, bool _isPhysical, bool _isSpecialist=false)
        {
            name = _name;
            linkedAttribute = _linkedAttr;
            skillValue = _skillValue;
            IsPhysical = _isPhysical;
            IsExpert = false;
            IsSpecialist = _isSpecialist;

            skillToLvl = skillValue+1;
            skillExp = 0;
        }

        private void SkillGetExp()
        {
            skillExp++;
            if(skillExp == skillToLvl)
            {
                skillValue++;
                skillToLvl = skillValue + 1;
                skillExp = 0;
            }
        }

        

       


    }
}
