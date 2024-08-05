using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of the rotation

    void Update()
    {
        // Calculate the rotation angle using the sin function
        float rotationAngle = Mathf.Sin(Time.time * speed) * -90.0f;

        // Set the new rotation of the transform
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rotationAngle);
    }
}
