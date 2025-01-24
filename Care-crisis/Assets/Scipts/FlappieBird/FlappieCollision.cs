using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappieCollision : MonoBehaviour
{
    public List<string> ResetTags;
    public List<string> CheckpointTags;
    public List<string> FinishTags;
    public static bool hasCrossedFinishLine = false;

    private CircleCollider2D CircleCollider2D;
    void Start()
    {
        CircleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (ResetTags.Contains(collider2D.tag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            FlappieSpaceListener.isGameStarted = false;
            Debug.Log("Player reset");
        }

        if (CheckpointTags.Contains(collider2D.tag))
        {
            Debug.Log("Player Checkpoint");
        }

        if (FinishTags.Contains(collider2D.tag))
        {
            hasCrossedFinishLine = true;
            Debug.Log("Player Finished");
        }
    }
}
