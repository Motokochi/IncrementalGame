using UnityEngine;

namespace Game_Manager
{
    public class DontDestroy : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject player;
        
        private void Awake()
        {
            if (player != null)
            {
                DontDestroyOnLoad(player);
            }
        }
    }
}
