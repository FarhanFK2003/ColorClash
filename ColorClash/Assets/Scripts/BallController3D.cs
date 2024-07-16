using UnityEngine;

public class BallController3D : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody rb;
    public LineRenderer lr;

    private Vector3 dragStartPos;
    private Touch touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }

    private void DragStart()
    {
        dragStartPos = GetWorldPositionOnPlane(touch.position);
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }

    private void Dragging()
    {
        Vector3 draggingPos = GetWorldPositionOnPlane(touch.position);
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }

    private void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = GetWorldPositionOnPlane(touch.position);

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        rb.AddForce(clampedForce, ForceMode.Impulse);
    }

    private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition)
    {
        // Assume the plane is at z = 0 (ground level)
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        float distance;
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
