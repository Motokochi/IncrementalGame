using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [Header("References")]
    private GameObject GOCultivationCave;
    private CultivationCave cultivationCaveScript;

    public CultivationCave InitializeCultivationCave(){
        cultivationCaveScript = GameObject.FindGameObjectWithTag("Cultivation Cave").GetComponent<CultivationCave>();
        return cultivationCaveScript;
    }
}
