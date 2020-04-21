using System;
using System.Collections.Generic;
using System.Text;
using static Nauka_RPG.Utility.SystemRPG;


namespace Nauka_RPG.Item_Classess
{


    public class Weapon : Item
    {
        private int dmgValue;
        private DamageType dmgType;
        private int parryValue;
        private int requredStr;
        private bool isShield;
        private SkillType linkedSkill;
        private WeaponType weaponType;
        private bool needAmmunition;
        

        public Weapon(string _name, double _value, double _weight, int _dmgValue, DamageType _dmgType, int _blkValue, int _reqStr, bool _isShield, WeaponType _wpnType, bool _needAmmo=false, int _size=1, bool _consumable=false, string _description="" ) :base(_name, _value, _weight, _size=1, _consumable=false, _description = "")
        {
            name = _name;
            value = _value;
            weight = _weight;
            dmgValue = _dmgValue;
            parryValue = _blkValue;
            requredStr = _reqStr;
            isShield = _isShield;
            weaponType = _wpnType;
            size = _size;
            consumable = false;
            description = _description;
            needAmmunition = _needAmmo;


        }
        
        
    }
}
