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
    public int BuildingLevel
    {
        buildingLevel = value;
        get
    }
}
public float Cost
{
    get
    public float Cost
    {
        return cost;
        get
        {
            return cost;
        }
        set
        {
            cost = value;
    }
    set
    {
        cost = value;
    }
}
public float QiMulti
{
    get
    {
        return qiMulti;
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