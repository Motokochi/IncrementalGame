using System;
using System.Collections.Generic;
using System.Linq;
using Building;
using UnityEngine;

namespace Entities.Player
{
    public class Player : Entities
    {
        [Header("Player Stats")]
        [SerializeField] private double cultivation;
        [SerializeField] private string cultivationRealm;
        [SerializeField] private double qiGain;
        [SerializeField] private double experience;
        [SerializeField] private List<Buildings> buildings;
        

        #region Setter
    
        private void SetCultivation(double cultivation)
        {
            this.cultivation = cultivation;
            SetCultivationRealm(this.cultivation);
        }

        private void SetCultivationRealm(double cultivation)
        {
            if (cultivation >= 0f && cultivation < 10f)
            {
                cultivationRealm = "Qi Condensation stage I";
            } else if (cultivation >= 10f && cultivation < 20f)
            {
                cultivationRealm = "Qi Condensation stage II";
            } else if (cultivation >= 20f && cultivation < 30f)
            {
                cultivationRealm = "Qi Condensation stage III";
            } else if (cultivation >= 30f && cultivation < 40f)
            {
                cultivationRealm = "Qi Condensation stage IV";
            } else if (cultivation >= 40f && cultivation < 50f)
            {
                cultivationRealm = "Qi Condensation stage V";
            } else if (cultivation >= 60f && cultivation < 70f)
            {
                cultivationRealm = "Qi Condensation stage VI";
            } else if (cultivation >= 70f && cultivation < 80f)
            {
                cultivationRealm = "Qi Condensation stage VII";
            } else if (cultivation >= 80f && cultivation < 90f)
            {
                cultivationRealm = "Qi Condensation stage VIII";
            } else if (cultivation >= 90f && cultivation < 100f)
            {
                cultivationRealm = "Qi Condensation stage IX";
            } else if (cultivation >= 100f && cultivation < 110f)
            {
                cultivationRealm = "Qi Condensation stage X";
            }
        }

        private void SetQiGain(double qiGain)
        {
            this.qiGain = qiGain;
        }

        private void SetExperience(double experience)
        {
            this.experience = experience;
        }
        
        #endregion

        #region Getter
        public double GetCultivation()
        {
            return cultivation;
        }

        public string GetCultivationRealm()
        {
            return cultivationRealm;
        }

        public double GetQiGain()
        {
            return qiGain;
        }

        public double GetExperience()
        {
            return experience;
        }

        public List<Buildings> GetBuildingLists()
        {
            return buildings;
        }
    
        #endregion

        #region Methods
        public void Train()
        {
            SetCultivation( GetCultivation() + GetExperience() );
        }

        public void IdleTrain()
        {
            SetCultivation( GetCultivation() + GetQiGain() );
        }

        public void UpdateQiGain()
        {
            SetQiGain( buildings.Sum(building => building.GetQiMultiplier()) );
        }
        
        #endregion
    }
}