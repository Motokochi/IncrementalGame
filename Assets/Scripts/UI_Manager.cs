using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject combatManager;
    [SerializeField] private IncrementalGameManager incrementalGameManager;
   // [SerializeField] private GameObject cultiCaveObject;
    [SerializeField] private Transform PopUpbox;
    [SerializeField] private CanvasGroup PopUpbackground;

    // Scripts
    private CombatManager combat_manager_script;
    private IncrementalGameManager incremental_game_manager_script;
   // private CultivationCave cultiCaveScript;
    

    [Header("Texts")]
    [SerializeField] private Text player_total_dmg_text;
    [SerializeField] private Text player_dps;
    [SerializeField] private Text combatTimer;
    [SerializeField] private Text test;

    

 

    void Start()
    {
        UIManagerRequestComponents();
       
        player_total_dmg_text.text = string.Format("DPS: {0:0.00}", combat_manager_script.player_total_dmg);
        
        
            
         
    }


    void Update()
    {
    {   
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

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);        // opens the scene after our active one
    }

    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }

    public void SelectionCombatButton()
    {
        SceneManager.LoadScene(2);        // load Combat scene
    }

    public void SelectionCultivationButton()
    {
        SceneManager.LoadScene(3);        // load Cultivation scene
    }

    public void BackButton()
    {
        SceneManager.LoadScene(1);        // return to the previous scene
    }

    public void BackButtonMenu()
    {
        SceneManager.LoadScene(0);        // return to the menu scene
    }

    public void BackButtonTraining()
    {
        SceneManager.LoadScene(3);        // return to the training scene
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
       // PopUpbox.LeanMoveLocalY(-Screen.height, 0.5f).setEaseOutExpo().setOnComplete(DisablePopUpBackground);      
        PopUpbox.gameObject.SetActive(false);
        PopUpbackground.gameObject.SetActive(false);
    }

   /* public void DisablePopUpBackground()
    {
        PopUpbackground.gameObject.SetActive(false);
    } */
}
