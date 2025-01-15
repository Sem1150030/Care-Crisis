using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PatientScript currentPatient; // Huidige patiënt waarmee de speler kan interageren

    void OnTriggerEnter2D(Collider2D other)
    {
        // Controleer of de collider een patiënt is
        if (other.CompareTag("Patient"))
        {
            currentPatient = other.GetComponent<PatientScript>();
            if (currentPatient != null)
            {
                // Toon interactieknop
                UIManager.Instance.ShowInteractButton(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Controleer of de collider een patiënt is
        if (other.CompareTag("Patient"))
        {
            currentPatient = null;
            // Verberg interactieknop
            UIManager.Instance.ShowInteractButton(false);
        }
    }

    public void Interact()
    {
        if (currentPatient != null)
        {
            // Start genezingsproces bij de patiënt
            currentPatient.StartHealing();
            UIManager.Instance.ShowInteractButton(false); // Verberg knop
        }
    }
}
