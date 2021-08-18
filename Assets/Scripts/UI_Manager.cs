using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject combatManager;
    [SerializeField] private GameObject GOTrainingManager;
    
    [SerializeField] private GameObject cultiCaveObject;
    private TrainingManager incrementalGameManager;
    [HideInInspector] public CultivationCave cultiCaveScript;
    private CombatManager combat_manager_script;

    [Header("GameObjects")]
    [SerializeField] private Transform PopUpbox;
    [SerializeField] private CanvasGroup PopUpbackground;


    [Header("Combat Scene Texts")]
    [SerializeField] private Text player_total_dmg_text;
    [SerializeField] private Text player_dps;
    [SerializeField] private Text combatTimer;
    
    [Header("Training Scene Texts")]
    [SerializeField] private Text CultiCavelvlText;
    [SerializeField] private Text CultiCavecostText;
    [SerializeField] private Text CultiCavelvlBelowButton;

    void Update()
    {
        CombatSceneUI();
        TrainingSceneUI();
    }

    public void UIManagerRequestComponents()
    {
        //Combat Manager Components
        combat_manager_script = combatManager.GetComponent<CombatManager>();
        //Incremental Manager Components
        incrementalGameManager = GOTrainingManager.GetComponent<TrainingManager>();
        //CultivationCave Components
        cultiCaveScript = cultiCaveObject.GetComponent<CultivationCave>();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);        // opens the scene after our active one
    }

    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }

    public void BackButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);     // return to the previous scene
    }

    public void OnEnable()               //clicking on the Load Button enables the PopUp thus starting this
    {
       PopUpbackground.alpha = 0;
       PopUpbackground.LeanAlpha(1, 0.5f);                                          //making background visible  (background is the dimming effect)
       PopUpbox.localPosition = new Vector2(63, -Screen.height);                    //box set below the visible area
       PopUpbox.LeanMoveLocalY(1250, 0.5f).setEaseOutExpo().delay = 0.1f;         //moves the box into the scene with a slight delay
    }

    public void CloseLoadPopUp()
    {
        PopUpbackground.LeanAlpha(0, 0.5f);                                                                             //making background invisible again
        PopUpbox.gameObject.SetActive(false);
        PopUpbackground.gameObject.SetActive(false);
    }

    public void CombatSceneUI(){
        if (SceneManager.GetActiveScene().name  == "CombatScene"){
            if (combat_manager_script.isInCombat)
            {
                player_total_dmg_text.text = string.Format("Total Damage: {0:0.00}", combat_manager_script.player_total_dmg);
                player_dps.text = string.Format("DPS: {0:0.00}", combat_manager_script.player_dps);
            }
            combatTimer.text = string.Format("Timer: {0:0.00}", combat_manager_script.combatTimer);
        }
    }

    public void TrainingSceneUI(){
        if (SceneManager.GetActiveScene().name  == "TrainingScene"){
            CultiCavelvlText.text = "LVL:" + cultiCaveScript.ReturnLevel();
            CultiCavecostText.text = "Cost:" + cultiCaveScript.ReturnCost();
            CultiCavelvlBelowButton.text ="LVL:" + cultiCaveScript.ReturnLevel();
        }
    }
}
