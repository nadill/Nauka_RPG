using System;
using System.Collections;
using System.Collections.Generic;

namespace Nauka_RPG
{
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
    public class Skill
    {


        public string name;
        public AttributeType linkedAttribute;
        public int skillValue;
        public bool IsPhysical { get; }
        public bool IsExpert { get; }


        private int skillExp;
        private int skillToLvl;

        public Skill(string _name, AttributeType _linkedAttr, int _skillValue, bool _isPhysical)
        {
            name = _name;
            linkedAttribute = _linkedAttr;
            skillValue = _skillValue;
            IsPhysical = _isPhysical;
            IsExpert = false;

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
