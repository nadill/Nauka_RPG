using System;
using System.Collections.Generic;
using System.Text;
using static Nauka_RPG.Utility.SystemRPG;

namespace Nauka_RPG
{
    public class Background
    {
        public string bgName;
        public Dictionary<SkillType, int> bgSkillMod;
        public BackgroundType bgType;

        public Background(string _bgName, BackgroundType _bgType)
        {
            bgName = _bgName;
            bgType = _bgType;
            bgSkillMod = new Dictionary<SkillType, int>(); 
        }

        public void AppendSkillsToBg(SkillType _skillType)
        {
            bgSkillMod.Add(_skillType, 1);
        }

    }
}
