using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance; // Singleton voor eenvoud
    public GameObject interactButton; // Referentie naar de interactieknop
    public string miniGameName;
    public MinigameManager minigameManager;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowInteractButton(bool result)
    {
        
        interactButton.SetActive(result);
    }
    
}
