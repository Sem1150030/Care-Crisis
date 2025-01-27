// PlayerInteraction.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PatientScript currentPatient; // Current patient the player can interact with

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is a patient
        if (other.CompareTag("Patient"))
        {
            currentPatient = other.GetComponent<PatientScript>();
            if (currentPatient != null)
            {
                // Show interaction button
                UIManager.Instance.ShowInteractButton(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collider is a patient
        if (other.CompareTag("Patient"))
        {
            currentPatient = null;
            // Hide interaction button
            UIManager.Instance.ShowInteractButton(false);
        }
    }

    public void Interact()
    {
        if (currentPatient != null)
        {
            UIManager.Instance.ShowInteractButton(false); // Hide button

            // Start healing process for the patient
            currentPatient.StartHealing();
        }
    }
}