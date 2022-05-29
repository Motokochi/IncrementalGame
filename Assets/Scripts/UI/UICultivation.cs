using System;
using Entities.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UICultivation : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject player;
        private Player _player;

        [Header("Text")]
        [SerializeField] private Text cultivationRealm;
        [SerializeField] private Text cultivationLevel;
        [SerializeField] private Text cultivationCaveLevel;
        

        private void Start()
        {
            RequestComponents();
        }

        void Update()
        {
            cultivationRealm.text = "Cultivation Realm:\n" + _player.GetCultivationRealm();
            cultivationLevel.text = $"Cultivation Level:\n{_player.GetCultivation():#.##}";
            cultivationCaveLevel.text = $"LVL {_player.GetBuildingLists()[0].GetBuildingLevel()}";
        }

        private void RequestComponents()
        {
            _player = player.GetComponent<Player>();
        }
    }
}
