using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayableField : MonoBehaviour
{
    public Transform playableField; // Reference to the plane representing the playable field
    public Camera mainCamera; // Reference to the main camera

    void Start()
    {
        SetupPlaneScale();
    }

    void SetupPlaneScale()
    {
        float aspectRatio = 9.0f / 16.0f; // Typical portrait aspect ratio
        float height = 10.0f; // Example height for the orthographic camera
        float width = height * aspectRatio;

        // Set the camera orthographic size (if using orthographic projection)
        mainCamera.orthographicSize = height / 2;

        // Set the plane scale
        playableField.localScale = new Vector3(width, 1, height);
    }
}

