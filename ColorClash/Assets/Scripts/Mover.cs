//using UnityEngine;

//public class Mover : MonoBehaviour
//{
//    public float speed = 2.0f; // Adjust the speed of the movement
//    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f); // Adjust the offset vector

//    void Update()
//    {
//        // Calculate the horizontal movement using the sin function
//        float movement = Mathf.Sin(Time.time * speed);

//        // Set the new position of the transform with the offset
//        transform.position = new Vector3(movement + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);
//    }
//}

using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of the movement
    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f); // Adjust the offset vector
    public float minX = -2.0f; // Minimum X position
    public float maxX = 2.0f;  // Maximum X position

    void Update()
    {
        // Calculate the horizontal movement using the sin function
        float movement = Mathf.Sin(Time.time * speed);

        // Set the new position of the transform with the offset, clamping it within the range
        float newXPosition = Mathf.Clamp(movement + offset.x, minX, maxX);
        transform.position = new Vector3(newXPosition, transform.position.y + offset.y, transform.position.z + offset.z);
    }
}