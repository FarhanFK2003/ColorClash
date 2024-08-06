using UnityEngine;

public class ArmorSpinner : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate around the z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}