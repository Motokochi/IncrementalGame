using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] public float player_dps;
    [Header("Player")]
    [SerializeField] public float player_damage;
    [SerializeField] public float player_total_dmg;
    [SerializeField] public float player_dps;


    [SerializeField] private GameObject player;
    [SerializeField] private PlayerScript player_script;
    
    private PlayerScript player_script;

    [Header("Timer")]
    [SerializeField] public bool isInCombat = false;
    [SerializeField] public float combatTimer = 30.00f;

    private void Start()
    {
        player_script = player.GetComponent<PlayerScript>();
        CombatManagerRequestComponents();
        InvokeRepeating("ActionsDuringCombat", 1, 1);
    }
    private void Update()
    {
        player_dps = player_script.PlayerPassiveDPS();
        player_total_dmg = player_total_dmg + player_dps;
        if (isInCombat)
        {
            CombatTimer();
        }
    }


    private void CombatManagerRequestComponents() //Initilizes all required Components from other GameObjects
    {
        player_script = player.GetComponent<PlayerScript>();
    }
    private void ActionsDuringCombat() //Calls all the actions that should be performed while in combat
    {
        if (isInCombat)
        {
            player_damage = player_script.PlayerPassiveDPS();
            player_total_dmg = player_total_dmg + player_damage;
            player_dps = player_total_dmg / (30 - combatTimer);
        }
    }
    private void CombatTimer()
    {
        if (combatTimer > 0)
        {
            combatTimer -= Time.deltaTime;
        } else
        {
            isInCombat = false;
            combatTimer = 30.00f;
            player_total_dmg = 0;
            player_dps = 0;
        }
    }
}
