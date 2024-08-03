using System.Collections;
using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public Color blueColor;
    public BluePlayerController playerController; // Reference to the player controller
    public AudioClip collisionSound; // Reference to the collision sound effect
    private Rigidbody rb;
    private Vector3 velocity;
    private GameController gameController;
    private AudioSource audioSource; // AudioSource component

    private bool hasCollided = false; // Flag to ensure sound only plays on collision

    private void Awake()
    {
        // Ensure the AudioSource component is attached and configure it
        audioSource = GetComponent<AudioSource>();
        //if (audioSource == null)
        //{
        //    audioSource = gameObject.AddComponent<AudioSource>();
        //}
        audioSource.playOnAwake = false; // Ensure sound does not play on awake
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing!");
            return;
        }
        rb.useGravity = true;

        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene!");
        }

        // Log the initial state of the AudioSource
        Debug.Log($"AudioSource playOnAwake: {audioSource.playOnAwake}");
    }

    private void Update()
    {
        velocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color currentColor = renderer.material.color;
                string currentHexColor = ColorToHex(currentColor);
                string blueHexColor = ColorToHex(blueColor);

                if (currentHexColor != blueHexColor)
                {
                    renderer.material.color = blueColor;

                    if (gameController != null)
                    {
                        gameController.OnBoxColorChanged(collision.gameObject, true);
                    }
                }

                if (!hasCollided)
                {
                    // Play the collision sound effect immediately
                    if (audioSource != null && collisionSound != null)
                    {
                        Debug.Log("Playing collision sound.");
                        audioSource.Play();
                    }
                    hasCollided = true; // Set flag to true to avoid playing sound again
                }

                DestroyBall();
            }
            else
            {
                Debug.LogError("Renderer component is missing on the collided object!");
            }
        }
        else
        {
            float speed = velocity.magnitude;
            Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }

    private void OnDestroy()
    {
        // Refill the ball count when the ball is destroyed
        if (playerController != null)
        {
            playerController.RefillBall();
        }
    }

    private void DestroyBall()
    {
        // Destroy the ball after collision
        Destroy(gameObject);
    }

    private string ColorToHex(Color color)
    {
        Color32 color32 = (Color32)color;
        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
    }
}
