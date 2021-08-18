using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject GOPlayerManager;
    PlayerManager playerManager;
    [SerializeField] GameObject GOCombatManager;
    CombatManager combatManager;
    [SerializeField] GameObject GOUIManager;
    UI_Manager UI_Manager;
    [SerializeField] GameObject GOTrainingManager;
    TrainingManager trainingManager;
    void Start()
    {
        GameManagerRequestsComponents(); //GameManager requests all the objects
        combatManager.player_script = playerManager.InitializePlayer(); //We initialize the player in the combatManager
        trainingManager.CallRealmDictionary(); // We create the Realm Dictionary
        UI_Manager.UIManagerRequestComponents(); //UI requests the needed components
        combatManager.CombatManagerRequestsComponents(); //CombatManager requests needed components
    }

    public void GameManagerRequestsComponents(){
        playerManager = GOPlayerManager.GetComponent<PlayerManager>();
        trainingManager = GOTrainingManager.GetComponent<TrainingManager>();
        combatManager = GOCombatManager.GetComponent<CombatManager>();
        UI_Manager = GOUIManager.GetComponent<UI_Manager>();
    }
}
