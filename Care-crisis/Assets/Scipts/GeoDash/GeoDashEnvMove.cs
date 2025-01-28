using UnityEngine;

public class GeoDashEnvMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float CurrentSpeed;
    void Update()
    {
        transform.Translate(Vector3.left * CurrentSpeed * Time.deltaTime);
    }
}
