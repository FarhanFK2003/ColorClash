//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public LineRenderer lr;
//    public GameObject blueBall; // Reference to the blue ball
//    public Rigidbody ballRb; // Rigidbody of the blue ball

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private Animator bluePlayerAnimator;
//    private Vector3 velocity;

//    private void Start()
//    {
//        if (lr == null)
//            lr = GetComponent<LineRenderer>();

//        mainCamera = Camera.main;
//        lr.positionCount = 0; // Initially hide the LineRenderer

//        bluePlayerAnimator = GetComponent<Animator>();

//        // Ensure the ball is just above the floor and initially inactive
//        if (blueBall != null)
//        {
//            blueBall.SetActive(false);
//            ballRb = blueBall.GetComponent<Rigidbody>();
//        }
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0 && !isDragging)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began)
//            {
//                if (Vector3.Distance(touchPosition, transform.position) < 1f) // Adjust this distance threshold as needed
//                {
//                    DragStart(touch);
//                }
//            }
//            else if (touch.phase == TouchPhase.Moved && isDragging)
//            {
//                Dragging(touch);
//            }
//            else if (touch.phase == TouchPhase.Ended && isDragging)
//            {
//                DragRelease(touch);
//            }
//        }

//        // Track velocity for reflection calculations
//        if (ballRb != null)
//        {
//            velocity = ballRb.velocity;
//        }
//    }

//    private void DragStart(Touch touch)
//    {
//        dragStartPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 1;
//        lr.SetPosition(0, dragStartPos);
//        isDragging = true;

//        // Play the raise hand animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", true);
//        }
//    }

//    private void Dragging(Touch touch)
//    {
//        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 2;
//        lr.SetPosition(1, draggingPos);
//    }

//    private void DragRelease(Touch touch)
//    {
//        lr.positionCount = 0;
//        isDragging = false;

//        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

//        Vector3 force = dragStartPos - dragReleasePos;
//        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

//        // Ensure the ball is just above the floor before applying the force
//        if (blueBall != null)
//        {
//            Vector3 position = blueBall.transform.position;
//            position.y = 0.1f; // Adjust to your floor height
//            blueBall.transform.position = position;

//            ballRb.AddForce(clampedForce, ForceMode.VelocityChange); // Using VelocityChange for smoother movement

//            // Play the throw animation
//            if (bluePlayerAnimator != null)
//            {
//                bluePlayerAnimator.SetBool("isDragging", false);
//                bluePlayerAnimator.SetTrigger("isThrowing");
//            }
//        }
//    }

//    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
//    {
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
//        if (plane.Raycast(ray, out float distance))
//        {
//            return ray.GetPoint(distance);
//        }
//        return Vector3.zero; // Return a default value if the ray does not hit the plane
//    }

//    // Method to activate the ball, called by the animation event
//    public void OnThrowAnimationStart()
//    {
//        if (blueBall != null)
//        {
//            blueBall.SetActive(true);
//        }
//    }

//    // Method to deactivate the ball, called by the animation event
//    public void OnThrowAnimationEnd()
//    {
//        if (blueBall != null)
//        {
//            blueBall.SetActive(false);
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check for collision with red boxes and change their color to blue
//        if (collision.gameObject.CompareTag("RedBox"))
//        {
//            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                renderer.material.color = Color.blue;
//            }
//        }

//        // Magnitude of the velocity vector is speed of the object (we will use it for constant speed so object never stop)
//        float speed = velocity.magnitude;

//        // Reflect params must be normalized so we get new direction
//        Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);

//        // Like earlier wrote: velocity vector is magnitude (speed) and direction (a new one)
//        ballRb.velocity = direction * speed;

//        // Deactivate the ball upon collision with an obstacle
//        if (!collision.gameObject.CompareTag("Ground"))
//        {
//            blueBall.SetActive(false);
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public LineRenderer lr;

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private Animator animator;
//    private GameObject currentBall;

//    private void Start()
//    {
//        mainCamera = Camera.main;
//        lr.positionCount = 0; // Initially hide the LineRenderer

//        // Get the Animator component
//        animator = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0 && !isDragging)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began)
//            {
//                if (Vector3.Distance(touchPosition, transform.position) < 1f) // Adjust this distance threshold as needed
//                {
//                    DragStart(touch);
//                }
//            }
//            else if (touch.phase == TouchPhase.Moved && isDragging)
//            {
//                Dragging(touch);
//            }
//            else if (touch.phase == TouchPhase.Ended && isDragging)
//            {
//                DragRelease(touch);
//            }
//        }
//    }

//    private void DragStart(Touch touch)
//    {
//        dragStartPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 1;
//        lr.SetPosition(0, dragStartPos);
//        isDragging = true;

//        // Play the raise hand animation
//        animator.SetBool("isDragging", true);
//    }

//    private void Dragging(Touch touch)
//    {
//        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 2;
//        lr.SetPosition(1, draggingPos);
//    }

//    private void DragRelease(Touch touch)
//    {
//        lr.positionCount = 0;
//        isDragging = false;

//        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

//        Vector3 force = dragStartPos - dragReleasePos;
//        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

//        // Instantiate the ball and add force
//        if (currentBall != null)
//        {
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(clampedForce, ForceMode.VelocityChange);
//        }

//        // Play the throw animation
//        animator.SetBool("isDragging", false);
//        animator.SetTrigger("isThrowing");
//    }

//    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
//    {
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
//        if (plane.Raycast(ray, out float distance))
//        {
//            return ray.GetPoint(distance);
//        }
//        return Vector3.zero; // Return a default value if the ray does not hit the plane
//    }

//    // Method to spawn the ball, called by the animation event
//    public void OnThrowAnimationEnd()
//    {
//        if (ballPrefab != null && ballSpawnPoint != null)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//        }
//    }
//}




// Best Updated

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private Animator bluePlayerAnimator;
//    private GameObject currentBall;

//    private void Start()
//    {
//        mainCamera = Camera.main;

//        // Ensure the ball prefab is inactive at the start
//        if (ballPrefab != null)
//        {
//            ballPrefab.SetActive(false);
//        }

//        // Get the Animator component from the player
//        bluePlayerAnimator = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began && !isDragging)
//            {
//                DragStart(touch);
//            }
//            else if (touch.phase == TouchPhase.Moved && isDragging)
//            {
//                Dragging(touch);
//            }
//            else if (touch.phase == TouchPhase.Ended && isDragging)
//            {
//                DragRelease(touch);
//            }
//        }
//    }

//    private void DragStart(Touch touch)
//    {
//        dragStartPos = GetWorldPositionOnPlane(touch.position);
//        isDragging = true;

//        // Play the raise hand animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", true);
//        }
//    }

//    private void Dragging(Touch touch)
//    {
//        // Visual feedback code can go here if needed
//    }

//    private void DragRelease(Touch touch)
//    {
//        isDragging = false;
//        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

//        Vector3 force = dragStartPos - dragReleasePos;
//        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

//        // Play the throw animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", false);
//            bluePlayerAnimator.SetTrigger("isThrowing");
//        }

//        // Start the coroutine to instantiate the ball after the animation
//        StartCoroutine(SpawnAndThrowBall(clampedForce));
//    }

//    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
//    {
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
//        if (plane.Raycast(ray, out float distance))
//        {
//            return ray.GetPoint(distance);
//        }
//        return Vector3.zero; // Return a default value if the ray does not hit the plane
//    }

//    private IEnumerator SpawnAndThrowBall(Vector3 force)
//    {
//        // Wait for the throw animation to complete
//        AnimatorStateInfo stateInfo = bluePlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        yield return new WaitForSeconds(stateInfo.length);

//        // Instantiate and throw the ball
//        if (ballPrefab != null && ballSpawnPoint != null)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(force, ForceMode.VelocityChange);
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float constantYPosition = 0.5f; // Adjust this value to your desired constant Y position

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private Animator bluePlayerAnimator;
//    private GameObject currentBall;

//    private void Start()
//    {
//        mainCamera = Camera.main;

//        // Ensure the ball prefab is inactive at the start
//        if (ballPrefab != null)
//        {
//            ballPrefab.SetActive(false);
//        }

//        // Get the Animator component from the player
//        bluePlayerAnimator = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began && !isDragging)
//            {
//                DragStart(touch);
//            }
//            else if (touch.phase == TouchPhase.Moved && isDragging)
//            {
//                Dragging(touch);
//            }
//            else if (touch.phase == TouchPhase.Ended && isDragging)
//            {
//                DragRelease(touch);
//            }
//        }
//    }

//    private void DragStart(Touch touch)
//    {
//        dragStartPos = GetWorldPositionOnPlane(touch.position);
//        isDragging = true;

//        // Play the raise hand animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", true);
//        }
//    }

//    private void Dragging(Touch touch)
//    {
//        // Visual feedback code can go here if needed
//    }

//    private void DragRelease(Touch touch)
//    {
//        isDragging = false;
//        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

//        Vector3 force = dragStartPos - dragReleasePos;
//        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

//        // Play the throw animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", false);
//            bluePlayerAnimator.SetTrigger("isThrowing");
//        }

//        // Start the coroutine to instantiate the ball after the animation
//        StartCoroutine(SpawnAndThrowBall(clampedForce));
//    }

//    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
//    {
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
//        if (plane.Raycast(ray, out float distance))
//        {
//            return ray.GetPoint(distance);
//        }
//        return Vector3.zero; // Return a default value if the ray does not hit the plane
//    }

//    private IEnumerator SpawnAndThrowBall(Vector3 force)
//    {
//        // Wait for the throw animation to complete
//        AnimatorStateInfo stateInfo = bluePlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        yield return new WaitForSeconds(stateInfo.length);

//        // Instantiate and throw the ball
//        if (ballPrefab != null && ballSpawnPoint != null)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(force, ForceMode.VelocityChange);
//        }
//    }

//    private void FixedUpdate()
//    {
//        if (currentBall != null)
//        {
//            Vector3 position = currentBall.transform.position;
//            position.y = constantYPosition;
//            currentBall.transform.position = position;
//        }
//    }
//}

// Fixed Update

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public GameObject ballPrefab;
//    public Transform ballSpawnPoint;
//    public float constantYPosition = 0.5f; // Adjust this value to your desired constant Y position
//    public LineRenderer lr;

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private Animator bluePlayerAnimator;
//    private GameObject currentBall;

//    private void Start()
//    {
//        mainCamera = Camera.main;

//        // Ensure the ball prefab is inactive at the start
//        if (ballPrefab != null)
//        {
//            ballPrefab.SetActive(false);
//        }

//        // Get the Animator component from the player
//        bluePlayerAnimator = GetComponent<Animator>();

//        // Ensure the LineRenderer component is attached
//        if (lr == null)
//        {
//            lr = gameObject.AddComponent<LineRenderer>();
//        }
//        lr.positionCount = 0; // Initially hide the LineRenderer
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began && !isDragging)
//            {
//                DragStart(touch);
//            }
//            else if (touch.phase == TouchPhase.Moved && isDragging)
//            {
//                Dragging(touch);
//            }
//            else if (touch.phase == TouchPhase.Ended && isDragging)
//            {
//                DragRelease(touch);
//            }
//        }
//    }

//    private void DragStart(Touch touch)
//    {
//        dragStartPos = GetWorldPositionOnPlane(touch.position);
//        isDragging = true;

//        // Play the raise hand animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", true);
//        }

//        // Initialize the LineRenderer positions
//        lr.positionCount = 1;
//        lr.SetPosition(0, dragStartPos);
//    }

//    private void Dragging(Touch touch)
//    {
//        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 2;
//        lr.SetPosition(1, draggingPos);
//    }

//    private void DragRelease(Touch touch)
//    {
//        isDragging = false;
//        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

//        Vector3 force = dragStartPos - dragReleasePos;
//        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

//        // Play the throw animation
//        if (bluePlayerAnimator != null)
//        {
//            bluePlayerAnimator.SetBool("isDragging", false);
//            bluePlayerAnimator.SetTrigger("isThrowing");
//        }

//        // Start the coroutine to instantiate the ball after the animation
//        StartCoroutine(SpawnAndThrowBall(clampedForce));

//        // Hide the LineRenderer
//        lr.positionCount = 0;
//    }

//    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
//    {
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
//        if (plane.Raycast(ray, out float distance))
//        {
//            return ray.GetPoint(distance);
//        }
//        return Vector3.zero; // Return a default value if the ray does not hit the plane
//    }

//    private IEnumerator SpawnAndThrowBall(Vector3 force)
//    {
//        // Wait for the throw animation to complete
//        AnimatorStateInfo stateInfo = bluePlayerAnimator.GetCurrentAnimatorStateInfo(0);
//        yield return new WaitForSeconds(stateInfo.length);

//        // Instantiate and throw the ball
//        if (ballPrefab != null && ballSpawnPoint != null)
//        {
//            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
//            currentBall.SetActive(true);
//            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//            rb.AddForce(force, ForceMode.VelocityChange);
//        }
//    }

//    private void FixedUpdate()
//    {
//        if (currentBall != null)
//        {
//            Vector3 position = currentBall.transform.position;
//            position.y = constantYPosition;
//            currentBall.transform.position = position;
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public float constantYPosition = 0.5f; // Adjust this value to your desired constant Y position
    public LineRenderer lr;
    public float spawnDelay = 0.2f; // Time before the animation ends to spawn the ball

    private Vector3 dragStartPos;
    private bool isDragging = false;
    private Camera mainCamera;
    private Animator bluePlayerAnimator;
    private GameObject currentBall;

    private void Start()
    {
        mainCamera = Camera.main;

        // Ensure the ball prefab is inactive at the start
        if (ballPrefab != null)
        {
            ballPrefab.SetActive(false);
        }

        // Get the Animator component from the player
        bluePlayerAnimator = GetComponent<Animator>();

        // Ensure the LineRenderer component is attached
        if (lr == null)
        {
            lr = gameObject.AddComponent<LineRenderer>();
        }
        lr.positionCount = 0; // Initially hide the LineRenderer
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

            if (touch.phase == TouchPhase.Began && !isDragging)
            {
                DragStart(touch);
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Dragging(touch);
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                DragRelease(touch);
            }
        }
    }

    private void DragStart(Touch touch)
    {
        dragStartPos = GetWorldPositionOnPlane(touch.position);
        isDragging = true;

        // Play the raise hand animation
        if (bluePlayerAnimator != null)
        {
            bluePlayerAnimator.SetBool("isDragging", true);
        }

        // Initialize the LineRenderer positions
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }

    private void Dragging(Touch touch)
    {
        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }

    private void DragRelease(Touch touch)
    {
        isDragging = false;
        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        // Play the throw animation
        if (bluePlayerAnimator != null)
        {
            bluePlayerAnimator.SetBool("isDragging", false);
            bluePlayerAnimator.SetTrigger("isThrowing");
        }

        // Start the coroutine to instantiate the ball after the animation
        StartCoroutine(SpawnAndThrowBall(clampedForce));

        // Hide the LineRenderer
        lr.positionCount = 0;
    }

    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero; // Return a default value if the ray does not hit the plane
    }

    private IEnumerator SpawnAndThrowBall(Vector3 force)
    {
        // Wait for the throw animation to almost complete
        AnimatorStateInfo stateInfo = bluePlayerAnimator.GetCurrentAnimatorStateInfo(0);
        float waitTime = stateInfo.length - spawnDelay;
        if (waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
        }

        // Instantiate and throw the ball
        if (ballPrefab != null && ballSpawnPoint != null)
        {
            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            currentBall.SetActive(true);
            Rigidbody rb = currentBall.GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (currentBall != null)
        {
            Vector3 position = currentBall.transform.position;
            position.y = constantYPosition;
            currentBall.transform.position = position;
        }
    }
}
