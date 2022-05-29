using System;
using Entities.Player;
using UnityEngine;

namespace Building
{
    [System.Serializable]
    public abstract class Buildings : MonoBehaviour
    { 
        [Header("References")] 
        [SerializeField] private GameObject player;
        private Player _player;
        
        [Header("Building Stats")]
        [SerializeReference] private int buildingLevel;
        [SerializeReference] private double cost;
        [SerializeReference] private double qiMultiplier;
        [SerializeReference] private double costIncrease;
        [SerializeReference] private double qiMultiplierIncrease;
        

        #region Setter
        private void SetBuildingLevel(int buildingLevel)
        {
            this.buildingLevel = buildingLevel;
        }

        private void SetCost(double cost)
        {
            this.cost = cost;
        }

        private void SetQiMultiplier(double qiMultiplier)
        {
            this.qiMultiplier = qiMultiplier;
        }

        private void SetCostIncrease(double costIncrease)
        {
            this.costIncrease = costIncrease;
        }

        private void SetQiMultiplierIncrease(double qiMultiplierIncrease)
        {
            this.qiMultiplierIncrease = qiMultiplierIncrease;
        }
        
        #endregion

        #region Getter
        public int GetBuildingLevel()
        {
            return buildingLevel;
        }

        public double GetCost()
        {
            return cost;
        }

        public double GetQiMultiplier()
        {
            return qiMultiplier;
        }

        public double GetCostIncrease()
        {
            return costIncrease;
        }

        public double GetQiMultiplierIncrease()
        {
            return qiMultiplierIncrease;
        }
        #endregion
        
        #region Methods
        public void UpgradeBuilding()
        {
            SetBuildingLevel( GetBuildingLevel() + 1 );
            SetCost( GetCost() * GetCostIncrease() );
            SetQiMultiplier( GetQiMultiplier() + GetQiMultiplierIncrease() );
        }
        #endregion
    }
} 