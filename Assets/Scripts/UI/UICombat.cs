using Entities.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UICombat : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject combatManager;
        private CombatManager _combatManager;

        [Header("Text")]
        [SerializeField] private Text timer;
        [SerializeField] private Text damagePerSecond;
        [SerializeField] private Text totalDamage;
        

        private void Start()
        {
            RequestComponents();
        }

        private void Update()
        {
            timer.text = $"Timer: {_combatManager.combatTimer:0.00}";
            damagePerSecond.text = $"DPS: {_combatManager.playerDps:0.00}";
            totalDamage.text = $"Total Damage: {_combatManager.playerTotalDmg:0.00}";
        }

        private void RequestComponents()
        {
            _combatManager = combatManager.GetComponent<CombatManager>();
        }
    }
}
