using UnityEngine;

public class WallMovingDown : MonoBehaviour
{
    private float Acceleration = 0.3f;
    private float CurrentSpeed;
    void Start()
    {
        CurrentSpeed = 3.0f;
    }
    void Update()
    {
        CurrentSpeed += Acceleration * Time.deltaTime;
        transform.Translate(Vector3.down * CurrentSpeed * Time.deltaTime);
    }
}
