using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entities
{
        public Player(float healthPoints, float attack, float defense, float critRate, float critDamage,float attackSpeed) {
         this.HealthPoints = healthPoints;
         this.Attack = attack;
         this.AttackSpeed = attackSpeed;
         this.Defense = defense;
         this.CritRate = critRate;
         this.CritDamage = critDamage;
        }
}