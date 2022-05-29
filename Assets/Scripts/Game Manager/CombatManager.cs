using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Entities;

public class CombatManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] public float playerDamage;
    [SerializeField] public float playerTotalDmg;
    [SerializeField] public float playerDps = 0;

    
    [Header("References")] 
    [SerializeField] private GameObject player;
    private Player _player;



    [Header("CombatTimer")]
    [SerializeField] public bool isInCombat = false;
    [SerializeField] public float combatMaxTimer;
    [SerializeField] public float combatTimer;

    [Header("Timers")]
    [SerializeField] private float dpsRefreshRate;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField][Range(0.06f,0.5f)] private float refreshRate = 0.5f;

    public void Start()
    {
        RequestsComponents();
    }

    private void Update()
    {
        CombatTimer();
        ActionsDuringCombat();
    }
    
    private void RequestsComponents()
    {
        _player = player.GetComponent<Player>();
    }

    private void ActionsDuringCombat() //Calls all the actions that should be performed while in combat
    {
        if (!isInCombat) return;
        dpsRefreshRate += 1f * Time.deltaTime; // Refresh rate of the DPS Text
        timeBetweenAttacks += 1f * Time.deltaTime; //Attacks per second
        if (timeBetweenAttacks >= _player.GetAttackSpeed()){
            timeBetweenAttacks = 0f;
            playerDamage = _player.DamageDealt();
            playerTotalDmg += playerDamage;
        }
        if (!(dpsRefreshRate >= refreshRate)) return;
        dpsRefreshRate = 0f;
        playerDps = playerTotalDmg / (combatMaxTimer - combatTimer);
    }
    private void CombatTimer()
    {
        if (!isInCombat) return;
        if (combatTimer > 0)
        {
            combatTimer -= Time.deltaTime;
        }
        else
        {
            isInCombat = false;
            combatTimer = combatMaxTimer;
            playerTotalDmg = 0;
            playerDps = 0;
        }
    }
}
