using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 dragStartPos;
    private Vector3 dragReleasePos;
    private Rigidbody rb;
    private LineRenderer lineRenderer;

    public float launchForceMultiplier = 5f;
    public int trajectoryPoints = 30;
    public float timeBetweenPoints = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = trajectoryPoints;
    }

    void OnMouseDown()
    {
        dragStartPos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        Vector3 currentPos = Input.mousePosition;
        Vector3 diff = currentPos - dragStartPos;
        Vector3 direction = new Vector3(diff.x, 0, diff.y);
        transform.position = direction * Time.deltaTime;

        DrawTrajectory();
    }

    void OnMouseUp()
    {
        dragReleasePos = Input.mousePosition;
        Vector3 dragVector = dragReleasePos - dragStartPos;
        Vector3 launchForce = new Vector3(dragVector.x, 0, dragVector.y) * launchForceMultiplier;
        rb.AddForce(launchForce);
        
        lineRenderer.positionCount = 0; // Hide the trajectory when the ball is launched
    }

    void DrawTrajectory()
    {
        Vector3 dragVector = Input.mousePosition - dragStartPos;
        Vector3 launchForce = new Vector3(dragVector.x, 0, dragVector.y) * launchForceMultiplier;
        Vector3 currentPosition = transform.position;
        Vector3 currentVelocity = launchForce / rb.mass * Time.fixedDeltaTime;

        for (int i = 0; i < trajectoryPoints; i++)
        {
            lineRenderer.SetPosition(i, currentPosition);

            currentPosition += currentVelocity * timeBetweenPoints;
            currentVelocity += Physics.gravity * timeBetweenPoints;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Blue Box"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
