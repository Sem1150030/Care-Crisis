using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LabGame : Minigame
    {
        private bool atLab = false;
        private bool hasMedicine = false;
        public bool started = false;
        public static LabGame Instance; 
        public MinigameManager minigameManager;
        public Button startGameButton;
        public string gameName;
        public GameObject infoText;



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
                infoText.SetActive(false);
                ReachLab();
            }
        }
        
        public override void StartGame(string gameName)
        {
            Debug.Log("LabGame started.");
            started = true;
            this.gameName = gameName;
            infoText.SetActive(true);
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
                startGameButton.gameObject.SetActive(true);
                
            }
        }

        public void startGame()
        { 
        startGameButton.gameObject.SetActive(false);
        Debug.Log($"Start minigame: {gameName}");

        switch (gameName)
            {
                case "MicroscopeGame":
                    if (MicroscopeGame.Instance != null)
                    {
                        MicroscopeGame.Instance.StartGame("d");
                    }
                    else
                    {
                        Debug.LogError("MicroscopeGame instance is not initialized!");
                    }
                    break;
            } 
        }

        

        
    }
}