using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entities : MonoBehaviour
{
    [Header("Player Stats")] //Entities Stats
    [SerializeField] private float healthPoints;
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float critRate;
    [SerializeField] private float critDamage;
    [SerializeField] protected float attackSpeed;

    /*
        Variables get & set
    */
    public float HealthPoints
    {
        get{
            return healthPoints;
        }
        set{
            healthPoints = value;
        }
    }
    public float Attack
    {
        get{
            return attack;
        }
        set{
            attack = value;
        }
    }
    public float Defense
    {
        get{
            return defense;
        }
        set{
            defense = value;
        }
    }

    public float CritRate
    {
        get{
            return critRate;
        }
        set{
            critRate = value;
        }
    }
    public float CritDamage
    {
        get{
            return critDamage;
        }
        set{
            critDamage = value;
        }
    }
    public float AttackSpeed
    {
        get{
            return attackSpeed;
        }
        set{
            attackSpeed = value;
        }
    }

    /*
        Methods
    */

    public float DamageDealt(){
        float damage;
        float randValue = Random.value;
        if (randValue < critRate)
        {
            damage = attack * critDamage;
        } else
        {
            damage = attack;
        }
        return damage;
    }

    public float ReceivedDamage(float incoming_damage, float defense)
    {
        float received_dmg;
        received_dmg = incoming_damage / (incoming_damage + defense); 
        return received_dmg;
    }
}
