using System;
using System.Collections.Generic;
using DefaultNamespace;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class VitalsScript : Minigame
{
    public int BPM;
    public int BPUpper;
    public int BPLower;
    public int temperature;
    public int whiteCount;

    public Text BPMText;
    public Text BPText;
    public Text temperatureText;
    public Text whiteCountText;
    
    
    public GameObject TryAgain;
  
    public bool BPSelected = false;
    public bool BPMSelected = false;
    public bool AntibioticsSelected = false;

    public bool BPNeeded = false;
    public bool BPMNeeded = false;
    public bool AntibioticsNeeded = false;
    
    public Button BPButton;
    public Button BPMButton;
    public Button AntibioticsButton;

    public GameObject monitor;
    
    public static VitalsScript Instance; 

    public MinigameManager minigameManager;
    public PatientScript assignedPatient; 


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

    public override void StartGame(string gameName)
    {
        monitor.SetActive(true);
        System.Random random = new System.Random();
        BPM = random.Next(60, 170);
        BPUpper = random.Next(80, 160);
        BPLower = BPUpper - random.Next(10, 25);
        temperature = random.Next(36, 40);
        whiteCount = random.Next(7000, 16000);
        
        BPMText.text = BPM.ToString();
        BPText.text = BPUpper + "/" + BPLower;
        temperatureText.text = temperature.ToString() + "°C";
        whiteCountText.text = whiteCount.ToString();
        
        checkNeededMedicine();
    }
    
    public void checkNeededMedicine()
    {
        if (BPM > 100)
        {
            BPMNeeded = true;
        }
        
        if (BPUpper > 120 || BPLower > 100)
        {
            BPNeeded = true;
        }
        if (temperature >= 39 || whiteCount > 11000)
        {
            AntibioticsNeeded = true;
        }
    }

    public void giveBPmeds()
    {
        
        if (BPButton != null && BPSelected == false)
        {
            ColorBlock colorBlock = BPButton.colors;
            colorBlock.normalColor = Color.green;
            colorBlock.highlightedColor = Color.green;
            colorBlock.pressedColor = Color.green;
            colorBlock.selectedColor = Color.green;
            BPButton.colors = colorBlock;
            BPSelected = true;
        }
        else
        {
            ColorBlock colorBlock = BPButton.colors;
            colorBlock.normalColor = Color.white;
            colorBlock.highlightedColor = Color.white;
            colorBlock.pressedColor = Color.white;
            colorBlock.selectedColor = Color.white;
            BPButton.colors = colorBlock;
            BPSelected = false;
        }
    }
    
    public void giveBPMmeds()
    {
        
        if (BPMButton != null && BPMSelected == false)
        {
            ColorBlock colorBlock = BPMButton.colors;
            colorBlock.normalColor = Color.green;
            colorBlock.highlightedColor = Color.green;
            colorBlock.pressedColor = Color.green;
            colorBlock.selectedColor = Color.green;
            BPMButton.colors = colorBlock;
            BPMSelected = true;
        }
        else
        {
            ColorBlock colorBlock = BPMButton.colors;
            colorBlock.normalColor = Color.white;
            colorBlock.highlightedColor = Color.white;
            colorBlock.pressedColor = Color.white;
            colorBlock.selectedColor = Color.white;
            BPMButton.colors = colorBlock;
            BPMSelected = false;
        }
    }
    
    public void giveAntibiotics()
    {
        
        if (AntibioticsButton != null && AntibioticsSelected == false)
        {
            ColorBlock colorBlock = AntibioticsButton.colors;
            colorBlock.normalColor = Color.green;
            colorBlock.highlightedColor = Color.green;
            colorBlock.pressedColor = Color.green;
            colorBlock.selectedColor = Color.green;
            AntibioticsButton.colors = colorBlock;
            AntibioticsSelected = true;
        }
        else
        {
            ColorBlock colorBlock = AntibioticsButton.colors;
            colorBlock.normalColor = Color.white;
            colorBlock.highlightedColor = Color.white;
            colorBlock.pressedColor = Color.white;
            colorBlock.selectedColor = Color.white;
            AntibioticsButton.colors = colorBlock;
            AntibioticsSelected = false;
        }
    }
    
    public void checkMedicine()
    {
        if (BPSelected == BPNeeded && BPMSelected == BPMNeeded && AntibioticsSelected == AntibioticsNeeded)
        {
            EndGame(true);
        }
        else
        {
            TryAgain.SetActive(true);
        }
    }

    public override void EndGame(bool success)
    {
        monitor.SetActive(false);
        TryAgain.SetActive(false);
        minigameManager.MinigameCompleted(true);
        assignedPatient.CompleteHealing(true);
        
    }
}
