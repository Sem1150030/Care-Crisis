using UnityEngine;

public class FlappieSpaceListener : MonoBehaviour
{
    public static bool isGameStarted = false;

    void Update()
    {
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
    }
}
