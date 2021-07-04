using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] public float player_dps;
    [SerializeField] public float player_total_dmg;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerScript player_script;
    

    private void Start()
    {
        player_script = player.GetComponent<PlayerScript>();
    }
    private void Update()
    {
        player_dps = player_script.PlayerPassiveDPS();
        player_total_dmg = player_total_dmg + player_dps;
    }
}
