using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ReactionTest : Minigame
{
    public PatientScript assignedPatient; // Verwijzing naar de toegewezen patiënt
    public GameObject reactionButton; // De knop die de speler moet aanklikken
    public GameObject ReactionPanel;
    public float minWaitTime = 2f; // Minimale tijd voor de knop verschijnt
    public float maxWaitTime = 5f; // Maximale tijd voor de knop verschijnt
    public float maxReactionTime = 3f; // Maximale tijd om te reageren (na verschijnen van de knop)
    public static ReactionTest Instance;
    public bool finished = false;

    private float reactionTimeLeft;
    private bool isButtonVisible = false;

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

        // Ensure minigameManager is assigned
        if (minigameManager == null)
        {
            minigameManager = MinigameManager.Instance;
        }
    }

    public override void StartGame()
    {
        // Ensure assignedPatient is assigned
        if (assignedPatient == null)
        {
            Debug.LogError("assignedPatient is not assigned!");
            return;
        }

        // Zet de knop uit bij het begin
        reactionButton.SetActive(false);

        // Start een willekeurige wachttijd voor het verschijnen van de knop
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        Invoke("ShowReactionButton", waitTime); // Toon de knop na de wachttijd
    }

    void ShowReactionButton()
    {
        ReactionPanel.SetActive(true);
        isButtonVisible = true;
        reactionButton.SetActive(true); // Maak de knop zichtbaar
        reactionTimeLeft = maxReactionTime; // Stel de tijd in die de speler heeft om te reageren
    }

    void Update()
    {
        if (isButtonVisible && !finished)
        {
            // Tel af voor de tijd om te reageren
            reactionTimeLeft -= Time.deltaTime;
            if (reactionTimeLeft <= 0)
            {
                EndGame(false); // Speler reageerde niet op tijd
            }
        }
    }

    // Dit wordt aangeroepen als de speler de knop aanklikt
    public void OnButtonClick()
    {
        if (isButtonVisible)
        {
            EndGame(true); // Speler heeft succesvol gereageerd
        }
    }

    public override void EndGame(bool success)
    {
        if (success)
        {
            Debug.Log("Reactietest voltooid. Succes!");
            assignedPatient.CompleteHealing(true); // Patiënt is genezen
            ReactionPanel.SetActive(false);
            isButtonVisible = false;
            finished = true;
            minigameManager.MinigameCompleted(true);
        }
        else
        {
            Debug.Log("Reactietest mislukt. Je hebt niet op tijd gereageerd.");
            assignedPatient.CompleteHealing(false); // Patiënt is niet genezen
            ReactionPanel.SetActive(false);
            minigameManager.MinigameCompleted(false);
        }

        // Verberg de knop en stop de game
        reactionButton.SetActive(false);
    }
}