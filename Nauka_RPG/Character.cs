//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Nauka_RPG
{
    public enum Race
    {
        Undefined,
        Human,
        Elvan,
        Borakai,
        Yutri,
        Alboros,
    }
    public enum BackgroundType
    {
        Undefined,
        BirthPlace,
        Past,
        Profession,
    }
    public enum Occupation
    {
        Player,
        Hostile,
        Friend,
    }
    public enum HealthCondition
    {
        Healthy,
        Injured,
        Wounded,
        HeavyWounded,
        Dying,
        Dead,
    }
    public enum Status
    {
        Default,
        Bleeding,
        Asleep,
        Ill,
        Terrified,
    }
    public enum BodyPart
    {
        Head,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
    }

    public class Character
    {
        public string name;
        public string lastName;
        public Race race;
        public float height;
        public float weight;
        private int age;
        public Occupation occupation;
        private Dictionary<BackgroundType, Background> background = new Dictionary<BackgroundType, Background>();
        public List<Item> equipment = new List<Item>();
        public List<Bag> bags = new List<Bag>();
        public Dictionary<BodyPart, Weapon> equippedWeapons = new Dictionary<BodyPart, Weapon>()
        {
            { BodyPart.RightArm, null},
            { BodyPart.LeftArm, null},
        };
        private int equipmentSize = 0;
        private int handSize = 2;
        private float maxLoad;
        private float currentLoad;

        protected Dictionary<AttributeType, Attribute> attributes = new Dictionary<AttributeType, Attribute>();
        protected Dictionary<SkillType, Skill> skills = new Dictionary<SkillType, Skill>();
        private int initiativeBonus;
        private int maxHealth;
        private int currentHealth;
        public bool IsDead { get; }
        public Status status = Status.Default;
        public int HeavyWounds { get; }
        protected int maxHeavyWounds;
        protected int physicalResistance = 0;
        private int reactionPool;
        public Dictionary<BodyPart, int> armourClass = new Dictionary<BodyPart, int>()
        {
            { BodyPart.Head, 0 },
            { BodyPart.Torso, 0 },
            { BodyPart.LeftArm, 0 },
            { BodyPart.RightArm, 0 },
            { BodyPart.LeftLeg, 0 },
            { BodyPart.RightLeg, 0 },
        };

        public Character(string _name, string _lname, Race _race, int _age, Occupation _occupation)
        {
            name = _name;
            lastName = _lname;
            race = _race;
            age = _age;
            occupation = _occupation;

            // Stworzenie puli Atrybutów podstawowych

            attributes.Add(AttributeType.Strength, new Attribute("Siła", 0, true));
            attributes.Add(AttributeType.Constitution, new Attribute("Kondycja", 0, true));
            attributes.Add(AttributeType.Precision, new Attribute("Precyzja", 0, true));
            attributes.Add(AttributeType.Mobility, new Attribute("Mobilność", 0, true));
            attributes.Add(AttributeType.Mind, new Attribute("Umysł", 0, false));
            attributes.Add(AttributeType.Sense, new Attribute("Zmysł", 0, false));
            attributes.Add(AttributeType.Personality, new Attribute("Osobowość", 0, false));
            attributes.Add(AttributeType.Willpower, new Attribute("Wola", 0, false));
            
            /*
            foreach (var atr in attributes.Values)
            {
                atr.attributeValue = SystemMechanics.AttributeGenerator();
                atr.attributeBonus = atr.attributeValue / 10;
            }
            */
            attributes.Add(AttributeType.Magic, new Attribute("Magia", 0, false));
            attributes.Add(AttributeType.Soul, new Attribute("Dusza", 100, false));
            attributes.Add(AttributeType.Sanity, new Attribute("Poczytalność", 100, false));

            // Stworzenie puli umiejętności

            // Umiejętności bojowe
            skills.Add(SkillType.Whips, new Skill("Baty", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Brawl, new Skill("Bijatyka", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Swords, new Skill("Miecze", AttributeType.Precision, 1, true));
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
            skills.Add(SkillType.Alchemy, new Skill("Alchemia", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Forgery, new Skill("Fałszerstwo", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Smithing, new Skill("Kowalstwo", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Medicine, new Skill("Medycyna", AttributeType.Mind, 0, false));
            skills.Add(SkillType.FirstAid, new Skill("Pierwsza pomoc", AttributeType.Sense, 0, false));
            skills.Add(SkillType.History, new Skill("Historia", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Fauna, new Skill("Fauna", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Flora, new Skill("Flora", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Religions, new Skill("Wierzenia", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Ocultism, new Skill("Okultyzm", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Engeneering, new Skill("Inżynieria", AttributeType.Mind, 0, false));

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
            skills.Add(SkillType.Sigils, new Skill("Pieczęcie", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Incantations, new Skill("Inkantacje", AttributeType.Magic, 0, false));
            skills.Add(SkillType.MagicalPerception, new Skill("Magiczna percepcja", AttributeType.Magic, 0, false));
            skills.Add(SkillType.Pacts, new Skill("Pakty", AttributeType.Willpower, 0, false));
            skills.Add(SkillType.Counterspells, new Skill("Przeciwzaklęcia", AttributeType.Magic, 0, false));
            skills.Add(SkillType.Rituals, new Skill("Rytuały", AttributeType.Magic, 0, false));
            skills.Add(SkillType.Stabilisation, new Skill("Stabilizacja", AttributeType.Magic, 0, false));

            /*
            maxLoad = attributes[AttributeType.Strength].attributeBonus + attributes[AttributeType.Constitution].attributeBonus * 10;
            currentLoad = 0;
            HeavyWounds = 0;
            maxHeavyWounds = attributes[AttributeType.Constitution].attributeBonus + 1;
            physicalResistance += attributes[AttributeType.Constitution].attributeBonus;

            maxHealth = 10 + SystemMechanics.HealthGenerator(attributes[AttributeType.Constitution].attributeBonus);
            currentHealth = maxHealth;
            initiativeBonus = attributes[AttributeType.Sense].attributeBonus + attributes[AttributeType.Mobility].attributeBonus;
            */

            
            
        }
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
                generatedAttrValues.Add(SystemMechanics.AttributeGenerator());
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
            /*
            Console.Clear();
            Console.WriteLine("Tak przedstawiają się przydzielone atrybuty:");
            foreach (var attr in attributes)
            {
                attr.Value.CalculateAttribute();
            }
            ShowInfo();
            */
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
            skills.Add(SkillType.Alchemy, new Skill("Alchemia", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Forgery, new Skill("Fałszerstwo", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Smithing, new Skill("Kowalstwo", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Medicine, new Skill("Medycyna", AttributeType.Mind, 0, false));
            skills.Add(SkillType.FirstAid, new Skill("Pierwsza pomoc", AttributeType.Sense, 0, false));
            skills.Add(SkillType.History, new Skill("Historia", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Fauna, new Skill("Fauna", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Flora, new Skill("Flora", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Religions, new Skill("Wierzenia", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Ocultism, new Skill("Okultyzm", AttributeType.Mind, 0, false));
            skills.Add(SkillType.Engeneering, new Skill("Inżynieria", AttributeType.Mind, 0, false));

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
            skills.Add(SkillType.Sigils, new Skill("Pieczęcie", AttributeType.Precision, 0, true));
            skills.Add(SkillType.Incantations, new Skill("Inkantacje", AttributeType.Magic, 0, false));
            skills.Add(SkillType.MagicalPerception, new Skill("Magiczna percepcja", AttributeType.Magic, 0, false));
            skills.Add(SkillType.Pacts, new Skill("Pakty", AttributeType.Willpower, 0, false));
            skills.Add(SkillType.Counterspells, new Skill("Przeciwzaklęcia", AttributeType.Magic, 0, false));
            skills.Add(SkillType.Rituals, new Skill("Rytuały", AttributeType.Magic, 0, false));
            skills.Add(SkillType.Stabilisation, new Skill("Stabilizacja", AttributeType.Magic, 0, false));

            /*
            maxLoad = attributes[AttributeType.Strength].attributeBonus + attributes[AttributeType.Constitution].attributeBonus * 10;
            currentLoad = 0;
            HeavyWounds = 0;
            maxHeavyWounds = attributes[AttributeType.Constitution].attributeBonus + 1;
            physicalResistance += attributes[AttributeType.Constitution].attributeBonus;

            maxHealth = 10 + SystemMechanics.HealthGenerator(attributes[AttributeType.Constitution].attributeBonus);
            currentHealth = maxHealth;
            initiativeBonus = attributes[AttributeType.Sense].attributeBonus + attributes[AttributeType.Mobility].attributeBonus;
            */

            Console.Clear();
            Console.WriteLine("Etap 3/4");
            Console.WriteLine("Przypisz proszę poniszy atrybut do wybranej wartości, podając odpowiadający jej numer.");
            List<>

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

        public void CreateRandomCharacter()
        {


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

        private void ApplyRaceBonuses(Race _raceType)
        {
            while (race==Race.Undefined)
            {
                race = _raceType;

                switch (race)
                {
                    case Race.Human:
                        break;
                    case Race.Elvan:
                        attributes[AttributeType.Precision].attributeValue += SystemMechanics.K10Roll();
                        attributes[AttributeType.Mobility].attributeValue += SystemMechanics.K10Roll();
                        attributes[AttributeType.Sense].attributeValue += SystemMechanics.K10Roll();
                        foreach (var attr in attributes.Values)
                        {
                            attr.CalculateAttribute();
                        }


                        
                        break;
                    case Race.Borakai:
                        break;
                    case Race.Yutri:
                        break;
                    case Race.Alboros:
                        break;
                    default:
                        break;
                }
            }

        }

    }

    

}