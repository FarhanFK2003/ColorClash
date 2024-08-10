//using System.Collections;
//using UnityEngine;

//public class BallCollisionHandler : MonoBehaviour
//{
//    public Color blueColor;
//    public BluePlayerController playerController; // Reference to the player controller
//    public AudioClip collisionSound; // Reference to the collision sound effect
//    private Rigidbody rb;
//    private Vector3 velocity;
//    private GameController gameController;
//    private AudioSource audioSource; // AudioSource component

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        if (rb == null)
//        {
//            Debug.LogError("Rigidbody component is missing!");
//            return;
//        }
//        rb.useGravity = true;

//        gameController = FindObjectOfType<GameController>();
//        if (gameController == null)
//        {
//            Debug.LogError("GameController not found in the scene!");
//        }

//        audioSource = gameObject.AddComponent<AudioSource>();
//        audioSource.playOnAwake = false;
//        audioSource.clip = collisionSound;

//        // Log the initial state of the AudioSource
//        Debug.Log($"AudioSource playOnAwake: {audioSource.playOnAwake}");
//    }

//    private void Update()
//    {
//        velocity = rb.velocity;
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Box"))
//        {
//            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                Color currentColor = renderer.material.color;
//                string currentHexColor = ColorToHex(currentColor);
//                string blueHexColor = ColorToHex(blueColor);

//                if (currentHexColor != blueHexColor)
//                {
//                    renderer.material.color = blueColor;

//                    if (gameController != null)
//                    {
//                        gameController.OnBoxColorChanged(collision.gameObject, true);
//                    }
//                }

//                // Play the collision sound effect immediately
//                if (audioSource != null && collisionSound != null)
//                {
//                    Debug.Log("Playing collision sound.");
//                    audioSource.Play();
//                }

//                DestroyBall();
//            }
//            else
//            {
//                Debug.LogError("Renderer component is missing on the collided object!");
//            }
//        }
//        else
//        {
//            float speed = velocity.magnitude;
//            Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
//            rb.velocity = direction * speed;
//        }
//    }

//    private void OnDestroy()
//    {
//        // Refill the ball count when the ball is destroyed
//        if (playerController != null)
//        {
//            playerController.RefillBall();
//        }
//    }

//    private void DestroyBall()
//    {
//        // Destroy the ball after collision
//        Destroy(gameObject);
//    }

//    private string ColorToHex(Color color)
//    {
//        Color32 color32 = (Color32)color;
//        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
//    }
//}


// Updated in every sense
//using UnityEngine;

//public class BallCollisionHandler : MonoBehaviour
//{
//    public Color blueColor;
//    private Rigidbody rb;
//    private Vector3 velocity;
//    private GameController gameController;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        if (rb == null)
//        {
//            Debug.LogError("Rigidbody component is missing!");
//            return;
//        }
//        rb.useGravity = true;

//        gameController = FindObjectOfType<GameController>();
//        if (gameController == null)
//        {
//            Debug.LogError("GameController not found in the scene!");
//        }
//    }

//    private void Update()
//    {
//        velocity = rb.velocity;
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Box"))
//        {
//            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                Color currentColor = renderer.material.color;
//                string currentHexColor = ColorToHex(currentColor);
//                string blueHexColor = ColorToHex(blueColor);

//                if (currentHexColor != blueHexColor)
//                {
//                    renderer.material.color = blueColor;

//                    // Notify the GameController about the box color change
//                    if (gameController != null)
//                    {
//                        gameController.OnBoxColorChanged(collision.gameObject, true);

//                    }

//                }

//                gameController.PlayCollisionSound();

//                // Play the particle effect at the box's position
//                gameController.PlayBlueParticleEffect(collision.transform.position);

//                DestroyBall();
//            }
//            else
//            {
//                Debug.LogError("Renderer component is missing on the collided object!");
//            }
//        }

//        else if(collision.gameObject.CompareTag("StaticWall"))
//        {
//            gameController.PlayCollisionSound();

//            // Play the particle effect at the box's position
//            gameController.PlayBlueParticleEffect(collision.transform.position);

//            DestroyBall();
//        }

//        // For game egdes and bounceable walls
//        else
//        {
//            float speed = velocity.magnitude;
//            Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
//            rb.velocity = direction * speed;
//        }
//    }

//    private void OnDestroy()
//    {
//        // Refill the ball count when the ball is destroyed
//        BluePlayerController playerController = FindObjectOfType<BluePlayerController>();
//        if (playerController != null)
//        {
//            playerController.RefillBall();
//        }
//    }

//    private void DestroyBall()
//    {
//        // Destroy the ball after collision
//        Destroy(gameObject);
//    }

//    private string ColorToHex(Color color)
//    {
//        Color32 color32 = (Color32)color;
//        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
//    }
//}


using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public Color blueColor;
    private Rigidbody rb;
    private Vector3 velocity;
    private GameController gameController;
    private bool collidedWithDestroyableWall = false;
    public Vector3 particleOffset = new Vector3(0, 1, 0); // Offset for the particle system position

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

                    // Notify the GameController about the box color change
                    if (gameController != null)
                    {
                        gameController.OnBoxColorChanged(collision.gameObject, true);
                    }
                }

                gameController.PlayCollisionSound();
                // Play the particle effect at the box's position
                gameController.PlayBlueParticleEffect(collision.transform.position);

                DestroyBall();
            }
            else
            {
                Debug.LogError("Renderer component is missing on the collided object!");
            }
        }

        else if (collision.gameObject.CompareTag("StaticWall"))
        {
            gameController.PlayCollisionSound();
            // Play the particle effect at the static wall's position
            gameController.PlayBlueParticleEffect(collision.transform.position);

            DestroyBall();
        }

        else if (collision.gameObject.CompareTag("DestroyableWall"))
        {
            gameController.PlayCollisionSound();
            // Play the particle effect at the destroyable wall's position
            gameController.PlayBlueParticleEffect(collision.transform.position);

            // Mark that the collision was with a destroyable wall
            collidedWithDestroyableWall = true;

            gameController.PlayBombParticleEffect(collision.transform.position);

            Destroy(collision.gameObject);

            // Destroy the ball
            DestroyBall();
        }

        else if (collision.gameObject.CompareTag("RedBall"))
        {
            gameController.PlayCollisionSound();
            // Play the particle effect at the static wall's position
            gameController.PlayBlueParticleEffect(collision.transform.position);

            //Destroy(collision.gameObject);

            DestroyBall();
        }

        else if (collision.gameObject.CompareTag("BlueBall"))
        {
            gameController.PlayCollisionSound();
            // Play the particle effect at the static wall's position
            gameController.PlayBlueParticleEffect(collision.transform.position);

            Destroy(collision.gameObject);

            DestroyBall();
        }

        else if (collision.gameObject.CompareTag("RedPlayer"))
        {
            gameController.PlayCollisionSound();
            // Play the particle effect at the static wall's position
            gameController.PlayBlueParticleEffect(collision.transform.position + particleOffset);

            //Destroy(collision.gameObject);

            DestroyBall();
        }

        else
        {
            // For game edges and bounceable walls
            float speed = velocity.magnitude;
            Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }

    private void OnDestroy()
    {
        // Check if the collision was with a destroyable wall
        if (!collidedWithDestroyableWall)
        {
            // Refill the ball count when the ball is destroyed
            BluePlayerController playerController = FindObjectOfType<BluePlayerController>();
            if (playerController != null)
            {
                playerController.RefillBall();
            }
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

