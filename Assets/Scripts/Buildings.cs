using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Buildings : MonoBehaviour
{
   public int buildingLevel;
   public float cost;
   public float qiMulti ;


    public int BuildingLevel
    {
        get
        {   
            return buildingLevel; 
        }
        set
        {
            buildingLevel = value;
        }
    }
    public float Cost
    {
        get
        {
            return cost;
        }
        set
        {
            cost = value;
        }
    }
    set
    {
        cost = value;
    }
}
public float QiMulti
{
    get
    public float QiMulti        
    {
        return qiMulti;
        get
        {
            return qiMulti;
        }
        set
        {
            qiMulti = value;
        }
    }
    set
    {
        qiMulti = value;
    }
}

 public void UpgradeBuilding()
    public void UpgradeBuilding()
    {
        BuildingLevel += 1;
        Cost = Cost*1.2f;
        Cost = Mathf.RoundToInt(Cost);
        QiMulti += 0.1f;
    } 
   

    public string ReturnLevel(){
        return buildingLevel.ToString();
    }
    
    public string ReturnCost(){
        return cost.ToString();
    } 
} 