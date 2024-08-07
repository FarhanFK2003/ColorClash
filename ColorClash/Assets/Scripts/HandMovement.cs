using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Speed of the movement
    public Vector3 targetOffset = new Vector3(1.0f, 1.0f, 0.0f);  // Offset for the diagonal movement

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingToTarget = true;
    private float t = 0.0f;
    private bool isHandActive = true;  // To keep track of the hand's active state

    void Start()
    {
        // Store the starting position of the hand
        startPosition = transform.localPosition;
        targetPosition = startPosition + targetOffset;
    }

    void Update()
    {
        // Check for player tap and hold input
        if (Input.GetMouseButton(0))
        {
            SetHandActive(false);
        }
        else
        {
            SetHandActive(true);

        }

        // Only move the hand if it is active
        if (isHandActive)
        {
            // Move towards the target position
            if (movingToTarget)
            {
                t += Time.deltaTime * speed;
                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);

                // Check if the hand has reached the target position
                if (t >= 1.0f)
                {
                    t = 0.0f;
                    movingToTarget = false;
                }
            }
            // Move back towards the starting position
            else
            {
                t += Time.deltaTime * speed;
                transform.localPosition = Vector3.Lerp(targetPosition, startPosition, t);

                // Check if the hand has reached the starting position
                if (t >= 1.0f)
                {
                    t = 0.0f;
                    movingToTarget = true;
                }
            }
        }
    }

    // Method to set the hand active or inactive
    private void SetHandActive(bool active)
    {
        isHandActive = active;
        gameObject.SetActive(active);
    }
}



