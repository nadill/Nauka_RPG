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
        public Character()
        {
            Console.Clear();
            Console.WriteLine("Etap 1/4");
            Console.Write("\nWprowadź imię swojej postaci: ");
            string inputName = Console.ReadLine();
            Console.Write("\nWprowadź imię rodowe swojej postaci: ");
            string inputLastName = Console.ReadLine();

            Console.WriteLine("Jakiej rasy ma być postać? ");
            Console.WriteLine("1. Człowiek ");
            Console.WriteLine("2. Elvan ");
            Console.WriteLine("3. Borakai ");
            Console.WriteLine("4. Yutri ");
            Console.WriteLine("5. Alboros \n");
            Console.Write("Podaj nr. odpowiadający rasie:");
            int inputRace = Convert.ToInt32(Console.ReadLine());
            Race inputRace2;

            switch (inputRace)
            {
                case 1:
                    inputRace2 = Race.Human;
                    break;
                case 2:
                    inputRace2 = Race.Elvan;
                    break;
                case 3:
                    inputRace2 = Race.Borakai;
                    break;
                case 4:
                    inputRace2 = Race.Yutri;
                    break;
                case 5:
                    inputRace2 = Race.Alboros;
                    break;
                default:
                    inputRace2 = Race.Human;
                    break;
            }

            Console.Write("\nIle twoja postać ma lat?: ");
            int inputAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nIle twoja postać ma wzrostu?: ");
            float inputHeight = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("\nIle twoja postać waży?: ");  
            float inputWeight = (float)Convert.ToDouble(Console.ReadLine());

            name = inputName;
            lastName = inputLastName;
            race = inputRace2;
            age = inputAge;
            occupation = Occupation.Player;
            weight = inputWeight;
            height = inputHeight;

            // Stworzenie puli Atrybutów podstawowych

            attributes.Add(AttributeType.Strength, new Attribute("Siła", 0, true));
            attributes.Add(AttributeType.Constitution, new Attribute("Kondycja", 0, true));
            attributes.Add(AttributeType.Precision, new Attribute("Precyzja", 0, true));
            attributes.Add(AttributeType.Mobility, new Attribute("Mobilność", 0, true));
            attributes.Add(AttributeType.Mind, new Attribute("Umysł", 0, false));
            attributes.Add(AttributeType.Sense, new Attribute("Zmysł", 0, false));
            attributes.Add(AttributeType.Personality, new Attribute("Osobowość", 0, false));
            attributes.Add(AttributeType.Willpower, new Attribute("Wola", 0, false));

            
            List<int> generatedAttrValues = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                generatedAttrValues.Add(SystemRPG.AttributeGenerator());
                Console.WriteLine($"{i+1}. {generatedAttrValues[i]}");

            }

            //int loop = 1;
            int attrChoice;
            foreach (var attr in attributes)
            {
               
                Console.Clear();
                Console.WriteLine("Etap 2/4");
                Console.WriteLine("Przypisz proszę poniszy atrybut do wybranej wartości, podając odpowiadający jej numer.");
                for (int i = 0; i < generatedAttrValues.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {generatedAttrValues[i]}");
                }
            
                Console.Write($"{attr.Value.attributeName} będzie mieć przypisaną wartość z wiersza: ");
                attrChoice = Convert.ToInt32(Console.ReadLine());
                attrChoice = (attrChoice > generatedAttrValues.Count && attrChoice <= 0) ? generatedAttrValues.Count : attrChoice;

                attributes[attr.Key].attributeValue = generatedAttrValues[attrChoice-1];
                generatedAttrValues.RemoveAt(attrChoice - 1);


            }
            attributes.Add(AttributeType.Magic, new Attribute("Magia", 0, false));
            attributes.Add(AttributeType.Soul, new Attribute("Dusza", 100, false));
            attributes.Add(AttributeType.Sanity, new Attribute("Poczytalność", 100, false));

            // Stworzenie puli umiejętności

            // Umiejętności bojowe
            skills.Add(SkillType.Whips, new Skill("Baty", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Brawl, new Skill("Bijatyka", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Swords, new Skill("Miecze", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Axes, new Skill("Topory", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Maces, new Skill("Obuchy", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Polearms, new Skill("Drzewcowe", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Claws, new Skill("Przedramienne", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Bows, new Skill("Łuki", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Crossbows, new Skill("Kusze", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Thrown, new Skill("Miotane", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Rifles, new Skill("Strzelby", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Improvised, new Skill("Improwizowane", AttributeType.Precision, 0, true));

            // Umiejętności fizyczne
            skills.Add(SkillType.Acrobatic, new Skill("Akrobatyka", AttributeType.Mobility, 0, true));
            skills.Add(SkillType.Athletic, new Skill("Atletyka", AttributeType.Constitution, 0, true));
            skills.Add(SkillType.Sneaking, new Skill("Skradanie", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Riding, new Skill("Jeździectwo", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Theft, new Skill("Kradzież", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Perception, new Skill("Percepcja", AttributeType.Sense, 0, true));
            skills.Add(SkillType.Driving, new Skill("Prowadzenie", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Survival, new Skill("Przetrwanie", AttributeType.Sense, 0, true));
            skills.Add(SkillType.Tracking, new Skill("Tropienie", AttributeType.Sense, 0, true));
            skills.Add(SkillType.EscapeArtist, new Skill("Wyswobodzenie", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Lockpicking, new Skill("Zabezpieczenia", AttributeType.Precision, 0, true));

            // Umiejętności umysłowe
            skills.Add(SkillType.Alchemy, new Skill("Alchemia", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Forgery, new Skill("Fałszerstwo", AttributeType.Precision, 0, true, true));
            skills.Add(SkillType.Smithing, new Skill("Kowalstwo", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Medicine, new Skill("Medycyna", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.FirstAid, new Skill("Pierwsza pomoc", AttributeType.Sense, 0, false));
            skills.Add(SkillType.History, new Skill("Historia", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Fauna, new Skill("Fauna", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Flora, new Skill("Flora", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Religions, new Skill("Wierzenia", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Ocultism, new Skill("Okultyzm", AttributeType.Mind, 0, false, true));
            skills.Add(SkillType.Engeneering, new Skill("Inżynieria", AttributeType.Mind, 0, false, true));

            // Umiejętności społeczne
            skills.Add(SkillType.Etiquette, new Skill("Etykieta", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Trade, new Skill("Handel", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Decieve, new Skill("Manipulacja", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Persuasion, new Skill("Perswazja", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Leadership, new Skill("Przywództwo", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Intimidation, new Skill("Zastraszanie", AttributeType.Strength, 0, false));
            skills.Add(SkillType.Empathy, new Skill("Empatia", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Seduce, new Skill("Uwodzenie", AttributeType.Personality, 0, false));
            skills.Add(SkillType.Interrogation, new Skill("Przesłuchiwanie", AttributeType.Willpower, 0, false));
            skills.Add(SkillType.Mentorship, new Skill("Mentorstwo", AttributeType.Personality, 0, false));

            // Umiejętności magiczne
            skills.Add(SkillType.Sigils, new Skill("Pieczęcie", AttributeType.Precision, 0, true, true));
            skills.Add(SkillType.Incantations, new Skill("Inkantacje", AttributeType.Magic, 0, false, true));
            skills.Add(SkillType.MagicalPerception, new Skill("Magiczna percepcja", AttributeType.Magic, 0, false, true));
            skills.Add(SkillType.Pacts, new Skill("Pakty", AttributeType.Willpower, 0, false, true));
            skills.Add(SkillType.Counterspells, new Skill("Przeciwzaklęcia", AttributeType.Magic, 0, false, true));
            skills.Add(SkillType.Rituals, new Skill("Rytuały", AttributeType.Magic, 0, false, true));
            skills.Add(SkillType.Stabilisation, new Skill("Stabilizacja", AttributeType.Magic, 0, false, true));


            Console.Clear();
            Console.WriteLine("Etap 3/4");
            Console.WriteLine("Przypisz proszę poniszy atrybut do wybranej wartości, podając odpowiadający jej numer.");
            

            Console.Write("Zapisać postać? (T/N): ");
            string decision = Console.ReadLine().ToUpper();

            switch (decision)
            {
                case "T":
                    string urlPath = @"C:\Users\Nadill\source\repos\Nauka_RPG\chars\character.csv";
                    List<string> stringList = new List<string>();
                    string csvSeparator = ",";
                    StringBuilder strBuilder = new StringBuilder();

                    stringList.Add(name);
                    stringList.Add(lastName);
                    stringList.Add(Convert.ToString(height));
                    stringList.Add(Convert.ToString(weight));
                    stringList.Add(Convert.ToString(age));

                    foreach (var item in stringList)
                    {
                        strBuilder.Append(item).Append(csvSeparator);
                    }


                    //File.Create(urlPath);
                    File.WriteAllText(urlPath, Convert.ToString(strBuilder));
                    //File.AppendAllText(urlPath, Convert.ToString(strBuilder));

                    break;
                default:
                    break;
            }
        }
        */


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