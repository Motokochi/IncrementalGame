using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TempUI_Manager : MonoBehaviour
{
    
    [SerializeField] private GameObject cultiCaveObject;
    private CultivationCave cultiCaveScript;
  [Header("BuildingTexts")]
     public Text CultiCavelvlText;
    public Text CultiCavecostText;
    public Text CultiCavelvlBelowButton;

   
    void Start()
    {
        cultiCaveScript = cultiCaveObject.GetComponent<CultivationCave>();

    }

    // Update is called once per frame
    void Update()
    { 
       
       //set Cultivation text
        CultiCavelvlText.text = string.Format("LVL: {0:0}", cultiCaveScript.BuildingLevel);
        CultiCavecostText.text = "Cost:" + cultiCaveScript.Cost.ToString();
        CultiCavelvlBelowButton.text ="LVL:" + cultiCaveScript.BuildingLevel.ToString(); 
    }
}
