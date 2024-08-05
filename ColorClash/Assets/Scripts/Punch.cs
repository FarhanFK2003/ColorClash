//using UnityEngine;

//public class Punch : MonoBehaviour
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

public class Punch : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of the movement
    public float range = 2.0f; // The distance the punch moves in the x direction
    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f); // Adjust the offset vector

    void Update()
    {
        // Calculate the horizontal movement using the PingPong function
        float movement = Mathf.PingPong(Time.time * speed, range);

        // Set the new position of the transform with the offset
        transform.position = new Vector3(movement + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);
    }
}

