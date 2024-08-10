//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RedPlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball (can be negative)
//    public float throwInterval = 5f; // Interval between throws
//    public Color redColor = Color.red; // The color to change the boxes to

//    private Animator redPlayerAnimator;
//    private GameObject currentBall;

//    private void Start()
//    {
//        // Get the Animator component from the player
//        redPlayerAnimator = GetComponent<Animator>();

//        // Start the throw routine
//        StartCoroutine(ThrowRoutine());
//    }

//    private IEnumerator ThrowRoutine()
//    {
//        while (true)
//        {
//            // Wait for the specified interval before throwing the ball
//            yield return new WaitForSeconds(throwInterval);

//            // Play the throw animation
//            if (redPlayerAnimator != null)
//            {
//                redPlayerAnimator.SetTrigger("isThrowing");
//            }

//            // Start the coroutine to instantiate the ball after the animation
//            StartCoroutine(SpawnAndThrowBall(Vector3.forward * power));
//        }
//    }

//    private IEnumerator SpawnAndThrowBall(Vector3 force)
//    {
//        // Wait for the throw animation to almost complete
//        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        float waitTime = stateInfo.length - spawnDelay;
//        if (waitTime > 0)
//        {
//            yield return new WaitForSeconds(waitTime);
//        }

//        // If spawnDelay is negative, wait for the remaining time
//        if (spawnDelay < 0)
//        {
//            yield return new WaitForSeconds(-spawnDelay);
//        }

//        // Instantiate and throw the ball
//        if (ballPrefab != null && ballSpawnPoint != null)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(force, ForceMode.VelocityChange);

//            // Attach a collision script to the ball
//            BallController ballController = currentBall.AddComponent<BallController>();
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RedPlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball (can be negative)
//    public float throwInterval = 5f; // Interval between throws
//    public Vector3 throwDirection = new Vector3(1f, 0f, 0f); // Direction in which to throw the ball

//    private Animator redPlayerAnimator;
//    private GameObject currentBall;

//    private void Start()
//    {
//        // Get the Animator component from the player
//        redPlayerAnimator = GetComponent<Animator>();

//        // Start the throw routine
//        StartCoroutine(ThrowRoutine());
//    }

//    private IEnumerator ThrowRoutine()
//    {
//        while (true)
//        {
//            // Wait for the specified interval before throwing the ball
//            yield return new WaitForSeconds(throwInterval);

//            // Play the throw animation
//            if (redPlayerAnimator != null)
//            {
//                redPlayerAnimator.SetTrigger("isThrowing");
//            }

//            // Start the coroutine to instantiate the ball after the animation
//            StartCoroutine(SpawnAndThrowBall());
//        }
//    }

//    private IEnumerator SpawnAndThrowBall()
//    {
//        // Wait for the throw animation to almost complete
//        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        float waitTime = stateInfo.length - spawnDelay;
//        if (waitTime > 0)
//        {
//            yield return new WaitForSeconds(waitTime);
//        }

//        // If spawnDelay is negative, wait for the remaining time
//        if (spawnDelay < 0)
//        {
//            yield return new WaitForSeconds(-spawnDelay);
//        }

//        // Instantiate and throw the ball
//        if (ballPrefab != null && ballSpawnPoint != null)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);

//            // Apply force in the specified direction
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(throwDirection.normalized * power, ForceMode.VelocityChange);

//            // Attach a collision script to the ball if needed
//            BallController ballController = currentBall.AddComponent<BallController>();
//        }
//    }
//}

// Updated
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RedPlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball (can be negative)
//    public float throwInterval = 5f; // Interval between throws
//    public List<Vector3> throwDirections = new List<Vector3>(); // List of predefined throw directions

//    private Animator redPlayerAnimator;
//    private GameObject currentBall;
//    private System.Random random = new System.Random();

//    private void Start()
//    {
//        // Get the Animator component from the player
//        redPlayerAnimator = GetComponent<Animator>();

//        // Start the throw routine
//        StartCoroutine(ThrowRoutine());
//    }

//    private IEnumerator ThrowRoutine()
//    {
//        while (true)
//        {
//            // Wait for the specified interval before throwing the ball
//            yield return new WaitForSeconds(throwInterval);

//            // Play the throw animation
//            if (redPlayerAnimator != null)
//            {
//                redPlayerAnimator.SetTrigger("isThrowing");
//            }

//            // Start the coroutine to instantiate the ball after the animation
//            StartCoroutine(SpawnAndThrowBall());
//        }
//    }

//    private IEnumerator SpawnAndThrowBall()
//    {
//        // Wait for the throw animation to almost complete
//        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        float waitTime = stateInfo.length - spawnDelay;
//        if (waitTime > 0)
//        {
//            yield return new WaitForSeconds(waitTime);
//        }

//        // If spawnDelay is negative, wait for the remaining time
//        if (spawnDelay < 0)
//        {
//            yield return new WaitForSeconds(-spawnDelay);
//        }

//        // Instantiate and throw the ball
//        if (ballPrefab != null && ballSpawnPoint != null && throwDirections.Count > 0)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);

//            // Select a random direction from the list
//            Vector3 selectedDirection = throwDirections[random.Next(throwDirections.Count)];

//            // Apply force in the selected direction
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(selectedDirection.normalized * power, ForceMode.VelocityChange);

//            // Attach a collision script to the ball if needed
//            // RedBallController ballController = currentBall.AddComponent<RedBallController>();
//        }
//    }
//}

// Updated
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class RedPlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball (can be negative)
//    public float throwInterval = 5f; // Interval between throws
//    public List<Vector3> throwDirections = new List<Vector3>(); // List of predefined throw directions

//    private Animator redPlayerAnimator;
//    private System.Random random = new System.Random();
//    private bool canSpawn = true;
//    private List<GameObject> spawnedRedBalls = new List<GameObject>();

//    private void Start()
//    {
//        // Get the Animator component from the player
//        redPlayerAnimator = GetComponent<Animator>();

//        // Start the throw routine
//        StartCoroutine(ThrowRoutine());
//    }

//    private IEnumerator ThrowRoutine()
//    {
//        while (canSpawn)
//        {
//            // Wait for the specified interval before throwing the ball
//            yield return new WaitForSeconds(throwInterval);

//            // Play the throw animation
//            if (redPlayerAnimator != null)
//            {
//                redPlayerAnimator.SetTrigger("isThrowing");
//            }

//            // Start the coroutine to instantiate the ball after the animation
//            StartCoroutine(SpawnAndThrowBall());
//        }
//    }

//    private IEnumerator SpawnAndThrowBall()
//    {
//        // Wait for the throw animation to almost complete
//        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        float waitTime = stateInfo.length - spawnDelay;
//        if (waitTime > 0)
//        {
//            yield return new WaitForSeconds(waitTime);
//        }

//        // If spawnDelay is negative, wait for the remaining time
//        if (spawnDelay < 0)
//        {
//            yield return new WaitForSeconds(-spawnDelay);
//        }

//        // Instantiate and throw the ball if spawning is allowed
//        if (canSpawn && ballPrefab != null && ballSpawnPoint != null && throwDirections.Count > 0)
//        {
//            GameObject currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);

//            // Select a random direction from the list
//            Vector3 selectedDirection = throwDirections[random.Next(throwDirections.Count)];

//            // Apply force in the selected direction
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(selectedDirection.normalized * power, ForceMode.VelocityChange);

//            // Add the spawned ball to the list
//            spawnedRedBalls.Add(currentBall);
//        }
//    }

//    public void StopSpawning()
//    {
//        canSpawn = false;
//    }

//    public void DeactivateAllRedBalls()
//    {
//        foreach (var ball in spawnedRedBalls)
//        {
//            if (ball != null)
//            {
//                ball.SetActive(false);
//            }
//        }
//    }

//}

// Updated for stun
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RedPlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball (can be negative)
//    public float throwInterval = 5f; // Interval between throws
//    public List<Vector3> throwDirections = new List<Vector3>(); // List of predefined throw directions

//    private Animator redPlayerAnimator;
//    private System.Random random = new System.Random();
//    private bool canSpawn = true;
//    private bool isStunned = false; // Flag to check if the red player is stunned
//    private List<GameObject> spawnedRedBalls = new List<GameObject>();
//    private Coroutine throwRoutine;

//    private void Start()
//    {
//        // Get the Animator component from the player
//        redPlayerAnimator = GetComponent<Animator>();

//        // Start the throw routine
//        throwRoutine = StartCoroutine(ThrowRoutine());
//    }

//    private IEnumerator ThrowRoutine()
//    {
//        while (canSpawn)
//        {
//            // Wait for the specified interval before throwing the ball
//            yield return new WaitForSeconds(throwInterval);

//            // Check if the player is not stunned before throwing
//            if (!isStunned)
//            {
//                // Play the throw animation
//                if (redPlayerAnimator != null)
//                {
//                    redPlayerAnimator.SetTrigger("isThrowing");
//                }

//                // Start the coroutine to instantiate the ball after the animation
//                StartCoroutine(SpawnAndThrowBall());
//            }
//        }
//    }

//    private IEnumerator SpawnAndThrowBall()
//    {
//        // Wait for the throw animation to almost complete
//        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        float waitTime = stateInfo.length - spawnDelay;
//        if (waitTime > 0)
//        {
//            yield return new WaitForSeconds(waitTime);
//        }

//        // If spawnDelay is negative, wait for the remaining time
//        if (spawnDelay < 0)
//        {
//            yield return new WaitForSeconds(-spawnDelay);
//        }

//        // Instantiate and throw the ball if spawning is allowed
//        if (canSpawn && ballPrefab != null && ballSpawnPoint != null && throwDirections.Count > 0)
//        {
//            GameObject currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);

//            // Select a random direction from the list
//            Vector3 selectedDirection = throwDirections[random.Next(throwDirections.Count)];

//            // Apply force in the selected direction
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(selectedDirection.normalized * power, ForceMode.VelocityChange);

//            // Add the spawned ball to the list
//            spawnedRedBalls.Add(currentBall);
//        }
//    }

//    public void StopSpawning()
//    {
//        canSpawn = false;
//    }

//    public void DeactivateAllRedBalls()
//    {
//        foreach (var ball in spawnedRedBalls)
//        {
//            if (ball != null)
//            {
//                ball.SetActive(false);
//            }
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("BlueBall"))
//        {
//            // Play the stunned animation
//            if (redPlayerAnimator != null)
//            {
//                redPlayerAnimator.SetTrigger("isStun");
//            }

//            // Set the isStunned flag to true and start the stun recovery routine
//            isStunned = true;
//            StartCoroutine(StunRecovery());
//        }
//    }

//    private IEnumerator StunRecovery()
//    {
//        // Stop the throw routine
//        if (throwRoutine != null)
//        {
//            StopCoroutine(throwRoutine);
//        }

//        // Wait for the stunned animation to complete
//        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        yield return new WaitForSeconds(stateInfo.length);

//        // Reset the isStunned flag to false
//        isStunned = false;

//        // Restart the throw routine
//        throwRoutine = StartCoroutine(ThrowRoutine());
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerController : MonoBehaviour
{
    public float power = 10f;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball (can be negative)
    public float throwInterval = 5f; // Interval between throws
    public List<Vector3> throwDirections = new List<Vector3>(); // List of predefined throw directions

    private Animator redPlayerAnimator;
    private System.Random random = new System.Random();
    private bool canSpawn = true;
    private bool isStunned = false; // Flag to check if the red player is stunned
    private List<GameObject> spawnedRedBalls = new List<GameObject>();
    private Coroutine throwRoutine;

    private void Start()
    {
        // Get the Animator component from the player
        redPlayerAnimator = GetComponent<Animator>();

        // Start the throw routine
        throwRoutine = StartCoroutine(ThrowRoutine());
    }

    private IEnumerator ThrowRoutine()
    {
        while (canSpawn)
        {
            // Wait for the specified interval before throwing the ball
            yield return new WaitForSeconds(throwInterval);

            // Check if the player is not stunned before throwing
            if (!isStunned)
            {
                // Play the throw animation
                if (redPlayerAnimator != null)
                {
                    redPlayerAnimator.SetTrigger("isThrowing");
                }

                // Start the coroutine to instantiate the ball after the animation
                StartCoroutine(SpawnAndThrowBall());
            }
        }
    }

    private IEnumerator SpawnAndThrowBall()
    {
        // Wait for the throw animation to almost complete
        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
        float waitTime = stateInfo.length - spawnDelay;
        if (waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
        }

        // If spawnDelay is negative, wait for the remaining time
        if (spawnDelay < 0)
        {
            yield return new WaitForSeconds(-spawnDelay);
        }

        // Instantiate and throw the ball if spawning is allowed
        if (canSpawn && ballPrefab != null && ballSpawnPoint != null && throwDirections.Count > 0)
        {
            GameObject currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            currentBall.SetActive(true);

            // Select a random direction from the list
            Vector3 selectedDirection = throwDirections[random.Next(throwDirections.Count)];

            // Apply force in the selected direction
            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
            rb.AddForce(selectedDirection.normalized * power, ForceMode.VelocityChange);

            // Add the spawned ball to the list
            spawnedRedBalls.Add(currentBall);
        }
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }

    public void DeactivateAllRedBalls()
    {
        foreach (var ball in spawnedRedBalls)
        {
            if (ball != null)
            {
                ball.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall"))
        {
            // Check if the player is already in the stun state
            AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName("Injured Stumble Idle") && !isStunned)
            {
                // Play the stunned animation
                if (redPlayerAnimator != null)
                {
                    redPlayerAnimator.SetTrigger("isStun");
                }

                // Set the isStunned flag to true and start the stun recovery routine
                isStunned = true;
                StartCoroutine(StunRecovery());
            }
        }
    }

    private IEnumerator StunRecovery()
    {
        // Stop the throw routine
        if (throwRoutine != null)
        {
            StopCoroutine(throwRoutine);
        }

        // Wait for the stun animation to complete
        AnimatorStateInfo stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
        while (!stateInfo.IsName("Injured Stumble Idle")) // Ensure the stun animation has started
        {
            stateInfo = redPlayerAnimator.GetCurrentAnimatorStateInfo(0);
            yield return null;
        }

        // Wait for the stun animation to finish
        yield return new WaitForSeconds(stateInfo.length);

        // Reset the isStunned flag to false
        isStunned = false;

        // Restart the throw routine
        throwRoutine = StartCoroutine(ThrowRoutine());
    }
}

