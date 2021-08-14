using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int cultivation_realm;


    [Header("Player Stats")] // Player related Stats
    [SerializeField] private float player_hp;
    [SerializeField] private float player_atk;
    [SerializeField] private float player_def;
    [SerializeField] private float player_crate;
    [SerializeField] private float player_cdmg;
    [SerializeField] private float player_attspd;

    private void Update()
    {
        
    }

    // Active DPS requires clicking from the player and doesn't scales of attspd.
    public float PlayerActiveDPS()
    {
        float player_damage;
        float randValue = Random.value;

        if (randValue < player_crate)
        {
            player_damage = player_atk * player_cdmg;
        }
        else
        {
            player_damage = player_atk;
        }
        return player_damage;
    }

    // Passive DPS Scales of Player's attspd
    public float PlayerPassiveDPS()
    {
        float player_damage;
        float randValue = Random.value;

        if (randValue < player_crate)
        {
            player_damage = player_atk * player_cdmg * player_attspd;
        } else
        {
            player_damage = player_atk * player_attspd;
        }
        return player_damage;
    }

    public float PlayerReceivedDMG(float enemy_dmg, float player_def)
    {
        float player_received_dmg;
        player_received_dmg = enemy_dmg / (enemy_dmg + player_def); 
        return player_received_dmg;
    }
}
