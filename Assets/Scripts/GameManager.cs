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
    [SerializeField] GameObject GOBuildingManager;
    BuildingManager buildingManager;
    void Start()
    {
        GameManagerRequestsComponents(); //GameManager requests all the objects
        combatManager.player_script = playerManager.InitializePlayer(); //We initialize the player in the combatManager
        UI_Manager.UIManagerRequestComponents(); //UI requests the needed components
        combatManager.CombatManagerRequestsComponents(); //CombatManager requests needed components
        UI_Manager.cultiCaveScript = buildingManager.InitializeCultivationCave(); //We initialize the cultivationCave
        trainingManager.CallRealmDictionary(); // We create the Realm Dictionary
        
        
    }

    public void GameManagerRequestsComponents(){
        playerManager = GOPlayerManager.GetComponent<PlayerManager>();
        trainingManager = GOTrainingManager.GetComponent<TrainingManager>();
        combatManager = GOCombatManager.GetComponent<CombatManager>();
        UI_Manager = GOUIManager.GetComponent<UI_Manager>();
        buildingManager = GOBuildingManager.GetComponent<BuildingManager>();
    }
}
