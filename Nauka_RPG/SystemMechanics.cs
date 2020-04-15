﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public static class SystemMechanics
    {

        public static int TestRoll()
        {
            Random diceRoll = new Random();
            int rollScore = diceRoll.Next(0, 100);

            return rollScore;
        }

        public static int TestRoll(bool _haveAdvantage)
        {
            Random diceRoll = new Random();
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

        public static int DamageRoll()
        {
            Random diceRoll = new Random();
            int rollScore = diceRoll.Next(1, 11);

            return rollScore;
        }
        public static int AttributeGenerator(bool _raceBonus=false)
        {
            Random diceRoll = new Random();
            int rollScore = 0;
            int nRolls = (_raceBonus) ? 6 : 5;
            for (int i = 0; i < nRolls; i++)
            {
                rollScore += diceRoll.Next(1, 11);
            }
            
            return rollScore;
        }

       

        public static int HealthGenerator(int _conBonus)
        {
            Random diceRoll = new Random();
            int rollScore = 0;
            for (int i = 0; i < _conBonus; i++)
            {
                rollScore += diceRoll.Next(1, 11);
            }

            return rollScore;
        }



        public static BodyPart PartHit()
        {
            Random diceRoll = new Random();
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
            Random diceRoll = new Random();
            int rollScore = diceRoll.Next(1, 11);
            rollScore += _initBonus;
            return rollScore;
        }


    }
}
