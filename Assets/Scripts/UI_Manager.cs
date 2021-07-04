using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject combatManager;
    [SerializeField] private CombatManager combat_manager_script;

    [Header("Texts")]
    [SerializeField] private Text player_total_dmg_text;

    void Start()
    {
        combat_manager_script = combatManager.GetComponent<CombatManager>();
        player_total_dmg_text.text = string.Format("{0:0.00}", combat_manager_script.player_total_dmg);
    }


    void Update()
    {
        player_total_dmg_text.text = string.Format("{0:0.00}", combat_manager_script.player_total_dmg);
    }
}
