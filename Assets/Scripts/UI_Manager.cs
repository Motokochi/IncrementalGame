using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject combatManager;
    [SerializeField] private CombatManager combat_manager_script;
    [SerializeField] private IncrementalGameManager incrementalGameManager;

    // Scripts
    private CombatManager combat_manager_script;
    private IncrementalGameManager incremental_game_manager_script;

    [Header("Texts")]
    [SerializeField] private Text player_total_dmg_text;
    [SerializeField] private Text player_dps;
    [SerializeField] private Text combatTimer;

    void Start()
    {
        combat_manager_script = combatManager.GetComponent<CombatManager>();
        player_total_dmg_text.text = string.Format("{0:0.00}", combat_manager_script.player_total_dmg);
        UIManagerRequestComponents();
        player_total_dmg_text.text = string.Format("DPS: {0:0.00}", combat_manager_script.player_total_dmg);
    }


    void Update()
    {
        player_total_dmg_text.text = string.Format("{0:0.00}", combat_manager_script.player_total_dmg);
        if (combat_manager_script.isInCombat)
        {
            player_total_dmg_text.text = string.Format("Total Damage: {0:0.00}", combat_manager_script.player_total_dmg);
            player_dps.text = string.Format("DPS: {0:0.00}", combat_manager_script.player_dps);
        }
        combatTimer.text = string.Format("Timer: {0:0.00}", combat_manager_script.combatTimer);
    }

    private void UIManagerRequestComponents()
    {
        // Combat Manager Components
        combat_manager_script = combatManager.GetComponent<CombatManager>();

        //Incremental Manager Components
        incremental_game_manager_script = incrementalGameManager.GetComponent<IncrementalGameManager>();
    }
}
