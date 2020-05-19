//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Nauka_RPG.Utility;
using Nauka_RPG.Item_Classess;
using static Nauka_RPG.Utility.SystemRPG;

namespace Nauka_RPG
{
    


    public abstract class Character
    {
        protected string name;
        protected string lastName;
        protected Race race;
        protected double height;
        protected double weight;
        protected int age;
        protected Sex sex;
        protected Occupation occupation;

        protected List<Item> equipment;
        protected List<Bag> bags;
        protected int eqCapacity = 0;
        public int EqCapacity { 
            get
            {   
                foreach (Bag bag in bags)
                {
                    eqCapacity += bag.BagSize;
                }
                return eqCapacity;
            } }

        protected Dictionary<BodyPart, Weapon> equippedWeapons = new Dictionary<BodyPart, Weapon>()
        {
            { BodyPart.RightArm, null},
            { BodyPart.LeftArm, null},
        };
        protected const int handSize = 2;
        protected Dictionary<BodyPart, int> armourClass = new Dictionary<BodyPart, int>()
        {
            { BodyPart.Head, 0 },
            { BodyPart.Torso, 0 },
            { BodyPart.LeftArm, 0 },
            { BodyPart.RightArm, 0 },
            { BodyPart.LeftLeg, 0 },
            { BodyPart.RightLeg, 0 },
        };
        public int HeavyWounds { get; }
        public int HeavyWoundThreshold { get { return attributes[AttributeType.Constitution].attributeBonus + 2; } }
        public int PhysicalResistance { get { return attributes[AttributeType.Constitution].attributeBonus; } }
        public int ReactionPool { get { return 1+ attributes[AttributeType.Mobility].attributeBonus / 2; } }
         
        public float MaxLoad { get { return 10 * (attributes[AttributeType.Constitution].attributeBonus + attributes[AttributeType.Strength].attributeBonus); } }
        protected float currentLoad = 0;


        protected Dictionary<AttributeType, Attribute> attributes;
        protected Dictionary<SkillType, Skill> skills; 
        protected Dictionary<BackgroundType, Background> background;

        public int InitiativeBonus { get { return attributes[AttributeType.Mobility].attributeBonus + attributes[AttributeType.Sense].attributeBonus; } }
        protected int maxHealth;
        public int MaxHealth { get { return maxHealth; } }
        protected int currentHealth = 0;

        protected int soul;
        protected int sanity;
        public bool? IsAwaken { get; }
        public int awakenChance = 0;
        public override string ToString()
        {
            return string.Format($"{name} {lastName}");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Imie: {name}, imie rodowe: {lastName}, wiek: {age}");
            Console.WriteLine($"Rasa: {race}");
            Console.WriteLine($"\nAtrybuty:");
            foreach (var atr in attributes)
            {
                Console.WriteLine($"{atr.Value.attributeName}: {atr.Value.attributeValue} (+{atr.Value.attributeBonus})");
            }
            Console.WriteLine($"\nMaks. życie: {maxHealth}");

        }

        public bool AttributeTest(AttributeType _attribute, out int _result, out bool _isCritical, Difficulty _difficulty)
        {
            _result = SystemRPG.K100Roll();
            _isCritical = SystemRPG.IsCritical(_result);

            if (attributes[_attribute].attributeBonus*10 + attributes[_attribute].attributeValue > 100)
            {
                int bonus = attributes[_attribute].attributeBonus * 10 + attributes[_attribute].attributeValue - 100;
                _result += bonus;
                return true;
            } 
            else if (_result <= attributes[_attribute].attributeValue + attributes[_attribute].attributeBonus*10 && _result >= (int)_difficulty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void RecieveDamage(int _damage, DamageType _type)
        {

        }
        public bool SkillTest(SkillType _skill, out int _result, out bool _isCritical, Difficulty _difficulty = 0)
        {
            _result = SystemRPG.K100Roll();
            _isCritical = SystemRPG.IsCritical(_result);

            if (skills[_skill].skillValue * 10 + attributes[skills[_skill].linkedAttribute].attributeValue > 100)
            {
                int bonus = skills[_skill].skillValue * 10 + attributes[skills[_skill].linkedAttribute].attributeValue - 100;
                _result += bonus;
                return true;
            }
            else if (_result <= skills[_skill].skillValue * 10 + attributes[skills[_skill].linkedAttribute].attributeValue && _result >= (int)_difficulty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AttackRoll(Character _target)
        {

        }
        public void Equip(Item _item)
        {

        }
        public void Unequip(Item _item)
        {

        }
        public void Loot( Character _target)
        {

        }

        


        /*
        private List<Background> ReturnBackgrounds()
        {
            List<Background> generatedBg = new List<Background>();

            generatedBg.Add(new Background("Sawanny Bokar", BackgroundType.BirthPlace));
            generatedBg[0].AppendSkillsToBg(SkillType.Tracking);
            generatedBg[0].AppendSkillsToBg(SkillType.Sneaking);
            generatedBg[0].AppendSkillsToBg(SkillType.Fauna);
            generatedBg[0].AppendSkillsToBg(SkillType.Bows);
            generatedBg[0].AppendSkillsToBg(SkillType.Survival);
            generatedBg.Add(new Background("Podmiasto Gurdam", BackgroundType.BirthPlace));
            generatedBg[1].AppendSkillsToBg(SkillType.Smithing);
            generatedBg[1].AppendSkillsToBg(SkillType.Navigation);
            generatedBg[1].AppendSkillsToBg(SkillType.Perception);
            generatedBg[1].AppendSkillsToBg(SkillType.Theft);
            generatedBg[1].AppendSkillsToBg(SkillType.Trade);
            generatedBg.Add(new Background("Gejzery Mufar", BackgroundType.BirthPlace));
            generatedBg[2].AppendSkillsToBg(SkillType.Athletic);

            generatedBg.Add(new Background("Zatoka głębinowych szponów", BackgroundType.BirthPlace));
            generatedBg[3].AppendSkillsToBg(SkillType.Navigation);
            generatedBg[3].AppendSkillsToBg(SkillType.Survival);

            generatedBg.Add(new Background("Diamentowe jeziora", BackgroundType.BirthPlace));
            generatedBg[4].AppendSkillsToBg(SkillType.Medicine);
            generatedBg[4].AppendSkillsToBg(SkillType.Trade);
            generatedBg[4].AppendSkillsToBg(SkillType.Athletic);
           
            generatedBg.Add(new Background("Las cieni", BackgroundType.BirthPlace));
            generatedBg[5].AppendSkillsToBg(SkillType.Sneaking);
            generatedBg[5].AppendSkillsToBg(SkillType.Acrobatic);
            generatedBg[5].AppendSkillsToBg(SkillType.Bows);
            generatedBg[5].AppendSkillsToBg(SkillType.Fauna);
            generatedBg[5].AppendSkillsToBg(SkillType.Flora);
            generatedBg.Add(new Background("Szczątki Randaru", BackgroundType.BirthPlace));
            generatedBg[6].AppendSkillsToBg(SkillType.Athletic);
            generatedBg[6].AppendSkillsToBg(SkillType.Acrobatic);

            generatedBg.Add(new Background("Metropolia Dirritum", BackgroundType.BirthPlace));
            generatedBg[7].AppendSkillsToBg(SkillType.Trade);
            generatedBg[7].AppendSkillsToBg(SkillType.Theft);
            generatedBg[7].AppendSkillsToBg(SkillType.Intimidation);
            generatedBg[7].AppendSkillsToBg(SkillType.Decieve);
            generatedBg[7].AppendSkillsToBg(SkillType.Persuasion);
            generatedBg.Add(new Background("Lasy elańskie", BackgroundType.BirthPlace));
            generatedBg[8].AppendSkillsToBg(SkillType.Flora);
            generatedBg[8].AppendSkillsToBg(SkillType.Acrobatic);
            generatedBg[8].AppendSkillsToBg(SkillType.Tracking);
            generatedBg[8].AppendSkillsToBg(SkillType.Fauna);
            generatedBg[8].AppendSkillsToBg(SkillType.Sneaking);
            generatedBg.Add(new Background("Starożytne miasto Nadir", BackgroundType.BirthPlace));
            generatedBg[9].AppendSkillsToBg(SkillType.History);
            generatedBg[9].AppendSkillsToBg(SkillType.Religions);
            generatedBg[9].AppendSkillsToBg(SkillType.Ocultism);



            return generatedBg;
        }
        */

    }

    

}