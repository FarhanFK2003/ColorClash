//using UnityEngine;

//public class BallController3D : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public Rigidbody rb;
//    public LineRenderer lr;

//    private Vector3 dragStartPos;
//    private Touch touch;

//    private void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            touch = Input.GetTouch(0);
//            if (touch.phase == TouchPhase.Began)
//            {
//                DragStart();
//            }
//            if (touch.phase == TouchPhase.Moved)
//            {
//                Dragging();
//            }
//            if (touch.phase == TouchPhase.Ended)
//            {
//                DragRelease();
//            }
//        }
//    }

//    private void DragStart()
//    {
//        dragStartPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 1;
//        lr.SetPosition(0, dragStartPos);
//    }

//    private void Dragging()
//    {
//        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
//        lr.positionCount = 2;
//        lr.SetPosition(1, draggingPos);
//    }

//    private void DragRelease()
//    {
//        lr.positionCount = 0;

//        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

//        Vector3 force = dragStartPos - dragReleasePos;
//        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
//        rb.AddForce(clampedForce, ForceMode.Impulse);
//    }

//    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
//    {
//        // Assume the plane is at z = 0 (ground level)
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
//        float distance;
//        plane.Raycast(ray, out distance);
//        return ray.GetPoint(distance);
//    }
//}


// Noman
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallController3D : MonoBehaviour
//{
//    private Vector3 dragStartPos;
//    private Vector3 dragReleasePos;
//    private Rigidbody rb;
//    private LineRenderer lineRenderer;

//    public float launchForceMultiplier = 5f;
//    public int trajectoryPoints = 30;
//    public float timeBetweenPoints = 0.1f;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        lineRenderer = GetComponent<LineRenderer>();
//        lineRenderer.positionCount = trajectoryPoints;
//    }

//    void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            switch (touch.phase)
//            {
//                case TouchPhase.Began:
//                    DragStart(touch);
//                    break;
//                case TouchPhase.Moved:
//                    Dragging(touch);
//                    break;
//                case TouchPhase.Ended:
//                    DragRelease(touch);
//                    break;
//            }
//        }
//    }

//    private void DragStart(Touch touch)
//    {
//        dragStartPos = GetWorldPosition(touch.position);
//    }

//    private void Dragging(Touch touch)
//    {
//        Vector3 currentPos = GetWorldPosition(touch.position);
//        Vector3 diff = currentPos - dragStartPos;

//        DrawTrajectory(diff);
//    }

//    private void DragRelease(Touch touch)
//    {
//        dragReleasePos = GetWorldPosition(touch.position);
//        Vector3 dragVector = dragReleasePos - dragStartPos;
//        Vector3 launchForce = dragVector * launchForceMultiplier;
//        rb.AddForce(launchForce, ForceMode.Impulse);

//        lineRenderer.positionCount = 0; // Hide the trajectory when the ball is launched
//    }

//    private Vector3 GetWorldPosition(Vector3 screenPosition)
//    {
//        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
//        Plane plane = new Plane(Vector3.up, Vector3.zero);
//        float distance;
//        plane.Raycast(ray, out distance);
//        return ray.GetPoint(distance);
//    }

//    private void DrawTrajectory(Vector3 dragVector)
//    {
//        Vector3 launchForce = dragVector * launchForceMultiplier;
//        Vector3 currentPosition = transform.position;
//        Vector3 currentVelocity = launchForce / rb.mass;

//        for (int i = 0; i < trajectoryPoints; i++)
//        {
//            lineRenderer.SetPosition(i, currentPosition);

//            currentPosition += currentVelocity * timeBetweenPoints;
//            currentVelocity += Physics.gravity * timeBetweenPoints;
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Blue Box"))
//        {
//            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
//        }
//    }
//}


//using UnityEngine;

//public class BallController3D : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public Rigidbody rb;
//    public LineRenderer lr;

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private GameObject bluePlayer;

//    private void Start()
//    {
//        // Ensure the ball has a Rigidbody and LineRenderer component
//        if (rb == null)
//            rb = GetComponent<Rigidbody>();

//        if (lr == null)
//            lr = GetComponent<LineRenderer>();

//        mainCamera = Camera.main;
//        lr.positionCount = 0; // Initially hide the LineRenderer

//        // Find the blue player in the scene
//        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began)
//            {
//                if (Vector3.Distance(touchPosition, bluePlayer.transform.position) < 1f) // Adjust this distance threshold as needed
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
//        rb.AddForce(clampedForce, ForceMode.Impulse);
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
//}




// Real Code
//using UnityEngine;

//public class BallController3D : MonoBehaviour
//{
//    public float power = 10f;
//    public float maxDrag = 5f;
//    public Rigidbody rb;
//    public LineRenderer lr;

//    private Vector3 dragStartPos;
//    private bool isDragging = false;
//    private Camera mainCamera;
//    private GameObject bluePlayer;
//    private Animator bluePlayerAnimator;

//    private void Start()
//    {
//        // Ensure the ball has a Rigidbody and LineRenderer component
//        if (rb == null)
//            rb = GetComponent<Rigidbody>();

//        if (lr == null)
//            lr = GetComponent<LineRenderer>();

//        mainCamera = Camera.main;
//        lr.positionCount = 0; // Initially hide the LineRenderer

//        // Find the blue player in the scene
//        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");
//        bluePlayerAnimator = bluePlayer.GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

//            if (touch.phase == TouchPhase.Began)
//            {
//                if (Vector3.Distance(touchPosition, bluePlayer.transform.position) < 1f) // Adjust this distance threshold as needed
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

//        // Play the throw animation
//        bluePlayerAnimator.SetBool("isThrowing", true);
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
//        rb.AddForce(clampedForce, ForceMode.Impulse);

//        // Stop the throw animation and return to idle
//        bluePlayerAnimator.SetBool("isThrowing", false);
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
//}


using UnityEngine;

public class BallController3D : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody rb;
    public LineRenderer lr;

    private Vector3 dragStartPos;
    private bool isDragging = false;
    private Camera mainCamera;
    private GameObject bluePlayer;
    private Animator bluePlayerAnimator;

    private void Start()
    {
        // Ensure the ball has a Rigidbody and LineRenderer component
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (lr == null)
            lr = GetComponent<LineRenderer>();

        mainCamera = Camera.main;
        lr.positionCount = 0; // Initially hide the LineRenderer

        // Find the blue player in the scene
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");
        bluePlayerAnimator = bluePlayer.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = GetWorldPositionOnPlane(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (Vector3.Distance(touchPosition, bluePlayer.transform.position) < 1f) // Adjust this distance threshold as needed
                {
                    DragStart(touch);
                }
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
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
        isDragging = true;

        // Play the raise hand animation
        bluePlayerAnimator.SetBool("isDragging", true);
    }

    private void Dragging(Touch touch)
    {
        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }

    private void DragRelease(Touch touch)
    {
        lr.positionCount = 0;
        isDragging = false;

        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        rb.AddForce(clampedForce, ForceMode.Impulse);

        // Play the throw animation
        bluePlayerAnimator.SetBool("isDragging", false);
        bluePlayerAnimator.SetTrigger("isThrowing");
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

    // This function can be called from an Animation Event at the start of the throw animation
    //public void OnThrowAnimationStart()
    //{
    //    // Synchronize the hand with the ball
    //    // Ensure the ball follows the hand position at the start of the throw animation
    //    Vector3 ballPosition = bluePlayer.transform.position + bluePlayer.transform.forward * 1.5f;
    //    rb.position = ballPosition;
    //}

    //// This function will be called at the end of the ThrowHand animation
    //public void OnThrowAnimationEnd()
    //{
    //    // Reset the trigger (not needed for a trigger, just a safeguard)
    //    bluePlayerAnimator.ResetTrigger("isThrowing");
    //}
}
