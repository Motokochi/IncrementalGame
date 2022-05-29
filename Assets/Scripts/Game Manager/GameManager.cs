using System;
using Entities.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace Game_Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject player;
        private Player _player;

        [Header("Timers")]
        [SerializeField] private float fixedTimer = 0;

        private void Start()
        {
            RequestComponents();
        }
        
        public void Update()
        {
            _player.UpdateQiGain();
            ActionsPerTick();
        }
        
        private void RequestComponents()
        {
            _player = player.GetComponent<Player>();
        }
        
        #region Scene Management

        public void Play()
        {
            Instantiate(player);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);        // opens the scene after our active one
        }
    
        public void Quit()
        {
            Debug.Log("Quit the game");
            Application.Quit();
        }
    
        public void LoadSceneButton(string sceneName)
        {
            SceneManager.LoadScene(sceneName);     // return to the previous scene
        }
    
        #endregion
        
        
        private void ActionsPerTick()
        {
            fixedTimer += 1f * Time.deltaTime;
            if (!(fixedTimer >= 1)) return;
            fixedTimer = 0;
            _player.IdleTrain();
        }
    }
}
