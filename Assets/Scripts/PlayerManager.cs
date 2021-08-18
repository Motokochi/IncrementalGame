using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    private Player playerScript;
    private CombatManager combatManagerScript;
    public Player InitializePlayer(){
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        return playerScript;
    }
}
