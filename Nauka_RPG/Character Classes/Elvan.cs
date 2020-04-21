using System;
using System.Collections.Generic;
using System.Text;
using static Nauka_RPG.Utility.SystemRPG;

namespace Nauka_RPG.Character_Classes
{
    public sealed class Elvan : Character
    {
       

        public Elvan(string _fName, string _lName, Race _race, int _age, double _height, double _weight, Sex _sex)
        {
            name = _fName;
            lastName = _lName;
            race = _race;
            age = _age;
            height = _height;
            weight = _weight;
            sex = _sex;

            equipment = new List<Item_Classess.Item>();
            bags = new List<Item_Classess.Bag>();

            attributes = SetupAttributes();
            attributes[AttributeType.Precision].attributeValue += 10;
            attributes[AttributeType.Mobility].attributeValue += 10;
            attributes[AttributeType.Sense].attributeValue += 10;

            skills = SetupSkills();
            skills[SkillType.Perception].bonusAdvantage = true;



        }



    }
    }


        
    

