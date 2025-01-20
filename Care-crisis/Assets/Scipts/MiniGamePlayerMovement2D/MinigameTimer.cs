using TMPro;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    public Color FlashColor = Color.red;
    public float FlashSpeed = 5f;
    public float FlashThreshold = 5f;
    public CollisionBehaviour collisionBehaviour;

    private bool timerStopped = false;
    private TMP_Text MinigameTimerText;
    private Color NormalColor = Color.white;
    private bool IsFlashing = false;

    private void Start()
    {
        MinigameTimerText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (collisionBehaviour.hasCrossedFinishLine)
        {
            if (!timerStopped)
            {
                timerStopped = true;
                MinigameTimerText.color = Color.green;
                Debug.Log("Player reached the finish line! Timer stopped.");
                return;
            }
        }

        // Decrease the timer
        countdownTime -= Time.deltaTime;

        // Stop the timer at 0 to prevent negative values
        if (countdownTime < 0)
        {
            countdownTime = 0;
            MinigameTimerText.color = FlashColor;
            IsFlashing = false;
            Debug.Log("Time's up!");
        }

        if (!timerStopped)
        {
            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            MinigameTimerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);

            // Start flashing when the time is below the threshold
            if (countdownTime <= FlashThreshold)
            {
                if (!IsFlashing)
                    IsFlashing = true;

                // Flash the text color
                float t = Mathf.Abs(Mathf.Sin(Time.time * FlashSpeed));
                MinigameTimerText.color = Color.Lerp(NormalColor, FlashColor, t);
            }
            else
            {
                // Reset to normal color if above the threshold
                IsFlashing = false;
                MinigameTimerText.color = NormalColor;
            }
        }
    }
}
