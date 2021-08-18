using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] public float player_damage;
    [SerializeField] public float player_total_dmg;
    [SerializeField] public float player_dps = 0;


    [HideInInspector] public Player player_script;
    [SerializeField] private GameObject GOPlayerManager;
    private PlayerManager playerManager;
    

    [Header("CombatTimer")]
    [SerializeField] public bool isInCombat = false;
    [SerializeField] public float combatMaxTimer;
    [SerializeField] public float combatTimer;

    [Header("Timers")]
    [SerializeField] private float dpsRefreshRate;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField][Range(0.06f,0.5f)] private float RefreshRate = 0.5f;

    private void Update()
    {
        CombatTimer();
        ActionsDuringCombat();
    }
    
    public void CombatManagerRequestsComponents() //CombatManager requests components
    {
        playerManager = GOPlayerManager.GetComponent<PlayerManager>();
    }

    private void ActionsDuringCombat() //Calls all the actions that should be performed while in combat
    {
        if (isInCombat){
            dpsRefreshRate = dpsRefreshRate + 1f * Time.deltaTime; // Refresh rate of the DPS Text
            timeBetweenAttacks = timeBetweenAttacks + 1f * Time.deltaTime; //Attacks per second
            if (timeBetweenAttacks >= player_script.AttackSpeed){
                timeBetweenAttacks = 0f;
                player_damage = player_script.DamageDealt();
                player_total_dmg = player_total_dmg + player_damage;
            }
            if (dpsRefreshRate >= RefreshRate ){
                dpsRefreshRate = 0f;
                player_dps = player_total_dmg / (combatMaxTimer - combatTimer);
            }
        }
    }
    private void CombatTimer()
    {
        if (isInCombat){
                if (combatTimer > 0)
            {
                combatTimer -= Time.deltaTime;
            } else {
            isInCombat = false;
            combatTimer = combatMaxTimer;
            player_total_dmg = 0;
            player_dps = 0;
            }
        }
    }
}
