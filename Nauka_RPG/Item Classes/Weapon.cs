using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG.Character_Classes
{
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
    public enum DamageType
    {
        Slash,
        Pierce,
        Blunt,
        Fire,
        Ice,
        Electric,
        Magic,
        Mind,
        Soul
    }
    public class Weapon : Item
    {
        private int damageValue;
        private int blockValue;
        private int requredStr;
        private bool isShield;
        private SkillType linkedSkill;
        private WeaponType weaponType;
        private bool needAmmunition;
        //private DamageType damageType;

        public Weapon(string _name, double _value, double _weight, int _dmgValue, int _blkValue, int _reqStr, bool _isShield, WeaponType _wpnType, bool _needAmmo=false, int _size=1, bool _consumable=false, string _description="" ) :base(_name, _value, _weight, _size=1, _consumable=false, _description = "")
        {
            name = _name;
            value = _value;
            weight = _weight;
            damageValue = _dmgValue;
            blockValue = _blkValue;
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
