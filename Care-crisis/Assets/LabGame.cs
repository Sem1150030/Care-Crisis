using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class LabGame : Minigame
    {
        private bool atLab = false;
        private bool hasMedicine = false;
        public bool started = false;
        public static LabGame Instance; 
        public MinigameManager minigameManager;



        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (minigameManager == null)
            {
                minigameManager = MinigameManager.Instance;
            }
        }
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && started && !atLab)
            {
                Debug.Log("Player reached the lab. Get the medicine.");
                ReachLab();
            }
        }
        
        public override void StartGame()
        {
            Debug.Log("LabGame started.");
            started = true;
            // Additional setup if needed
        }

        public override void EndGame(bool success)
        {
            if (success)
            {
                Debug.Log("LabGame completed successfully.");
            }
            
        }

        public void ReachLab()
        {
            if (!atLab && started)
            {
                atLab = true;
                Debug.Log("Player reached the lab. Get the medicine.");
                GetMedicine();
            }
        }

        private void GetMedicine()
        {
            if (atLab && started)
            {
                hasMedicine = true;
                Debug.Log("Player got the medicine. Return to the patient.");
                EndGame(true);
            }
            
        }

        
    }
}