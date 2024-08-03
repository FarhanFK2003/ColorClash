//using UnityEngine;

//public class BallController : MonoBehaviour
//{
//    public float speed = 10f; // Speed of the ball
//    private Rigidbody rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        // Give the ball an initial force to start moving
//        rb.AddForce(new Vector3(1, 0, 1).normalized * speed, ForceMode.Impulse);
//    }

//    void FixedUpdate()
//    {
//        // Maintain a consistent speed
//        rb.velocity = rb.velocity.normalized * speed;
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Reflect the ball's velocity based on the normal of the collision
//        Vector3 normal = collision.contacts[0].normal;
//        Vector3 incomingVelocity = rb.velocity;

//        // Calculate the reflection
//        Vector3 reflection = Vector3.Reflect(incomingVelocity, normal);

//        // Ensure the velocity is maintained at the desired speed
//        rb.velocity = reflection.normalized * speed;
//    }
//}

// Updated
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RedBallController : MonoBehaviour
//{
//    // Drag and drop Rigidbody in Inspector
//    public Rigidbody rb;
//    public Vector3 velocity;

//    void Start()
//    {
//        // Add force once at start
//        rb.AddForce(Vector3.back * 3.0f, ForceMode.VelocityChange);

//    }

//    void Update()
//    {
//        // Track velocity, it holds magnitude and direction (for collision math)
//        velocity = rb.velocity;
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Magnitude of the velocity vector is speed of the object (we will use it for constant speed so object never stop)
//        float speed = velocity.magnitude;

//        // Reflect params must be normalized so we get new direction
//        Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);

//        // Like earlier wrote: velocity vector is magnitude (speed) and direction (a new one)
//        rb.velocity = direction * speed;
//    }
//}

// Updated for Slider Only
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController : MonoBehaviour
{
    // Drag and drop Rigidbody in Inspector
    public Rigidbody rb;
    public Vector3 velocity;
    public Color redColor = Color.red; // The color to change the boxes to
    public GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }
        // Add force once at start
        rb.AddForce(Vector3.back * 3.0f, ForceMode.VelocityChange);

        // Get the GameController component
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (rb != null)
        {
            // Track velocity, it holds magnitude and direction (for collision math)
            velocity = rb.velocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rb == null) return;

        // Check if the collided object has the "Box" tag
        if (collision.gameObject.CompareTag("Box"))
        {
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color currentColor = renderer.material.color;
                string currentHexColor = ColorToHex(currentColor);
                string redHexColor = ColorToHex(redColor);

                // Check if the box is already red
                if (currentHexColor != redHexColor)
                {
                    // Change the color to red
                    renderer.material.color = redColor;

                    // Notify the game controller about the color change
                    if (gameController != null)
                    {
                        gameController.OnBoxColorChanged(collision.gameObject, false);
                    }
                }

                gameController.PlayCollisionSound();

                // Play the particle effect at the box's position
                gameController.PlayRedParticleEffect(collision.transform.position);

                Debug.Log("Particle");

                // Destroy the ball upon collision with the box
                Destroy(gameObject);
            }
        }
        else
        {
            // Reflect params must be normalized so we get new direction
            float speed = velocity.magnitude;
            Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }

    // Method to convert Color to hexadecimal string (needed here as well)
    private string ColorToHex(Color color)
    {
        Color32 color32 = (Color32)color;
        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
    }
}