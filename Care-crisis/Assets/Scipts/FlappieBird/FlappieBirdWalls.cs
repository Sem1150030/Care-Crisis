using UnityEngine;

public class FlappieBirdWalls : MonoBehaviour
{
    private float Acceleration = 0.3f;
    private float CurrentSpeed;
    void Start()
    {
        CurrentSpeed = 4.0f;
    }
    void Update()
    {
        if (FlappieSpaceListener.isGameStarted && !FlappieCollision.hasCrossedFinishLine)
        {
            CurrentSpeed += Acceleration * Time.deltaTime;
            transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime);
        }
    }
}
