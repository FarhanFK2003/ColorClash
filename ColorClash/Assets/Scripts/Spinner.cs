using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate around the y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}