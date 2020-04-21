using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG.Utility
{
    public static class SystemRPG
    {
        public enum Race
        {
            Human,
            Elvan,
            Borakai,
            Yutri,
            Alboros
        }
        public enum Sex
        {
            Male,
            Female,
        }
        public enum BackgroundType
        {
            BirthPlace,
            Past,
            Profession,
        }
        public enum Occupation
        {
            Player,
            Hostile,
            Friendly,
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
        public enum DamageType
        {
            Slash,
            Pierce,
            Blunt,
            Fire,
            Cold,
            Electric,
            Toxic,
            Soul,
            Mind
        }
        public enum ResistanceType
        {
            Slash,
            Pierce,
            Blunt,
            Fire,
            Cold,
            Electric,
            Toxic,
            Soul,
            Mind
        }
        public enum WeaponType
        {
            Whip,
            Sword,
            Axe,
            Mace,
            Claw,
            Bow,
            Crossbow,
            Rifle,
            Thrown,
            Improvised
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
        public enum Difficulty
        {
            SuperEasy = 20,
            VeryEasy = 30,
            Easy = 40,
            Normal = 50,
            Difficult = 60,
            VeryDifficult = 70,
            SuperDifficult = 80
        }
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
        public enum SkillType
        {
            Whips,
            Brawl,
            Swords,
            Axes,
            Maces,
            Polearms,
            Claws,
            Bows,
            Crossbows,
            Thrown,
            Rifles,
            Improvised,
            Acrobatic,
            Athletic,
            Sneaking,
            Riding,
            Theft,
            Perception,
            Driving,
            Survival,
            Tracking,
            EscapeArtist,
            Lockpicking,
            Alchemy,
            Forgery,
            Smithing,
            Medicine,
            FirstAid,
            Navigation,
            History,
            Fauna,
            Flora,
            Religions,
            Ocultism,
            Engeneering,
            Etiquette,
            Trade,
            Decieve,
            Persuasion,
            Gossip,
            Leadership,
            Intimidation,
            Empathy,
            Seduce,
            Interrogation,
            Mentorship,
            Sigils,
            Incantations,
            MagicalPerception,
            Pacts,
            Counterspells,
            Rituals,
            Stabilisation,

        }


        private static Random diceRoll = new Random();
        public static int TestRoll()
        {
            int rollScore = diceRoll.Next(0, 100);

            return rollScore;
        }

        public static int TestRoll(bool _haveAdvantage)
        {
            int rollScore1 = diceRoll.Next(0,100);
            int rollScore2 = diceRoll.Next(0, 100);
            int rollScore;
            if (_haveAdvantage)
            {
                rollScore = Math.Max(rollScore1, rollScore2);
            } else {
                rollScore = Math.Min(rollScore1, rollScore2);
            }

            return rollScore;
        }

        public static bool IsCritical(int _rollScore)
        {
            int decimals = _rollScore / 10;
            int digits = _rollScore - decimals;

            return (decimals == digits) ? true : false;
        }

        public static int K10Roll(int _nDices=1)
        {
            int rollScore = 0;
            for (int i = 0; i < _nDices; i++)
            {
                rollScore += diceRoll.Next(1, 11);
            }
            return rollScore;
        }
        public static int K100Roll()
        {
            
            return diceRoll.Next(0, 100);
        }
        public static int DamageRoll(int _strMod, int _wpnDmg, int _conMod, int _blkValue, int _resistance, bool _isCritical=false)
        {
            int rollScore = diceRoll.Next(1, 11) + _strMod + _wpnDmg - _conMod - _blkValue - _resistance;
            rollScore += (_isCritical) ? diceRoll.Next(1, 11) : 0;

            return rollScore;
        }
        public static int AttributeGenerator(bool _raceBonus=false)
        {
            int rollScore = 0;
            int nRolls = (_raceBonus) ? 6 : 5;
            for (int i = 0; i < nRolls; i++)
            {
                rollScore += diceRoll.Next(1, 11);
            }
            
            return rollScore;
        }

        public static Dictionary<AttributeType, Attribute> SetupAttributes()
        {
            Dictionary<AttributeType, Attribute> attList = new Dictionary<AttributeType, Attribute>();

            attList.Add(AttributeType.Strength, new Attribute("Siła", 0, true));
            attList.Add(AttributeType.Constitution, new Attribute("Kondycja", 0, true));
            attList.Add(AttributeType.Precision, new Attribute("Precyzja", 0, true));
            attList.Add(AttributeType.Mobility, new Attribute("Mobilność", 0, true));
            attList.Add(AttributeType.Mind, new Attribute("Umysł", 0, false));
            attList.Add(AttributeType.Sense, new Attribute("Zmysł", 0, false));
            attList.Add(AttributeType.Personality, new Attribute("Osobowość", 0, false));
            attList.Add(AttributeType.Willpower, new Attribute("Wola", 0, false));
            attList.Add(AttributeType.Magic, new Attribute("Magia", 0, false));

            return attList;
        }

        public static Dictionary<SkillType, Skill> SetupSkills()
        {
            Dictionary<SkillType, Skill> skills = new Dictionary<SkillType, Skill>();

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

            return skills;
        }
       

        public static int HealthGenerator(int _conBonus)
        {
            int rollScore = 0;
            for (int i = 0; i < _conBonus; i++)
            {
                rollScore += diceRoll.Next(1, 11);
            }

            return rollScore;
        }

        public static bool TryAwaken(Character _character)
        {
            bool isAwaken = false;
            if (_character.IsAwaken== null)
            {
                int rollResult = K100Roll();
                isAwaken = (rollResult <= _character.awakenChance) ? true : false;
                
            }
            return isAwaken;

        }

        public static BodyPart PartHit()
        {
            int rollScore = diceRoll.Next(1, 7);
            switch (rollScore)
            {
                case 6:
                    return BodyPart.Head;
                case 5:
                    return BodyPart.RightArm;
                case 4:
                    return BodyPart.LeftArm;
                case 3:
                    return BodyPart.Torso;
                case 2:
                    return BodyPart.RightLeg;
                case 1:  
                    return BodyPart.LeftLeg;
                    
                default:
                    return BodyPart.Torso;
                    
            }
        }

        public static int InitiativeRoll(int _initBonus)
        {
            int rollScore = diceRoll.Next(1, 11);
            rollScore += _initBonus;
            return rollScore;
        }


    }
}
