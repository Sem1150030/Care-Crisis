using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class MicroscopeGame : Minigame
{
    public GameObject[] virusses;
    private int CurrentVirusIndex;
    public GameObject background;
    public GameObject InsideMicroscopePanel;
    public GameObject OutsideMicroscopePanel;
    public static MicroscopeGame Instance;
    public MinigameManager minigameManager;
    public float CoolDownTimer = 5f;
    public bool CoolDown = false;
    public float currentCooldownTimer = 0f;
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
    
    public void VirusIndexIntialization()
    {
        int length = virusses.Length;
        System.Random random = new System.Random();
        CurrentVirusIndex = random.Next(0, length);
    }

    
    public void GoInsideMicroscope()
    {
        OutsideMicroscopePanel.SetActive(false);
        InsideMicroscopePanel.SetActive(true);
        virusses[CurrentVirusIndex].SetActive(true);
    }
    
    public void GoOutsideMicroscope()
    {
        OutsideMicroscopePanel.SetActive(true);
        InsideMicroscopePanel.SetActive(false);
        virusses[CurrentVirusIndex].SetActive(false);
    }

    public void ChooseVirus(int index)
    {
        if(!CoolDown){
            if (index == CurrentVirusIndex)
            {
                Debug.Log("Correct virus!");
                EndGame(true);
            }

            else
            {
                Debug.Log("Incorrect virus!");
                StartCooldown();
            }
        }
        else
        {
            Debug.Log("Cooldown is active.");
        }
    }
    
    void Update()
    {
        if (CoolDown)
        {
            currentCooldownTimer -= Time.deltaTime;
            if (currentCooldownTimer <= 0f)
            {
                CoolDown = false;
                currentCooldownTimer = 0f;
                Debug.Log("Cooldown finished.");
            }
        }
    }

    public void StartCooldown()
    {
        CoolDown = true;
        currentCooldownTimer = CoolDownTimer;
        Debug.Log("Cooldown started.");
    }

    public override void StartGame(string gameName)
    {
        background.SetActive(true);
        OutsideMicroscopePanel.SetActive(false);
        InsideMicroscopePanel.SetActive(false);
        virusses[CurrentVirusIndex].SetActive(false);
        VirusIndexIntialization();
        GoOutsideMicroscope();
    }

    public override void EndGame(bool success)
    {
        if (success)
        {
            Debug.Log("Microscope game completed successfully.");
            background.SetActive(false);
            OutsideMicroscopePanel.SetActive(false);
            InsideMicroscopePanel.SetActive(false);
            minigameManager.MinigameCompleted(true);
            assignedPatient.CompleteHealing(true);


        }
    }
}
