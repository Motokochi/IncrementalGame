using UnityEngine;
using UnityEngine.Serialization;

namespace Entities
{
    public abstract class Entities : MonoBehaviour {
    
    [Header("Entity Stats")]
    [SerializeReference] private float healthPoints; 
    [SerializeReference] private float attack;
    [SerializeReference] private float defense;
    [SerializeReference] private float criticalRate;
    [SerializeReference] private float criticalDamage;
    [SerializeReference] private float attackSpeed;
    

    #region Setter
    protected void SetHealthPoints(float healthPoints) 
    {
        this.healthPoints = healthPoints;
    }
    
    protected void SetAttack(float attack) 
    {
        this.attack = attack;
    }
    
    protected void SetDefense(float defense) 
    {
        this.defense = defense;
    }

    protected void SetCriticalRate(float criticalRate)
    {
        this.criticalRate = criticalRate;
    }

    protected void SetCriticalDamage(float criticalDamage)
    {
        this.criticalDamage = criticalDamage;
    }

    protected void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
    }
    
    #endregion

    #region Getter
    public float GetHealthPoints() 
    {
        return healthPoints;
    }
    
    public float GetAttack() 
    {
        return attack;
    }

    public float GetDefense()
    {
        return defense;
    }

    public float GetCriticalRate()
    {
        return criticalRate;
    }

    public float GetCriticalDamage()
    {
        return criticalDamage;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
    
    #endregion

    #region Methods

    public float DamageDealt(){
        float damage;
        var randValue = Random.value;
        if (randValue < criticalRate)
        {
            damage = attack * criticalDamage;
        } else
        {
            damage = attack;
        }
        return damage;
    }

    public float ReceivedDamage(float incomingDamage, float defense)
    {
        return incomingDamage / (incomingDamage + defense);
    }
    
    #endregion
    
    }
}

