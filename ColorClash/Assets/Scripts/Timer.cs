//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Timer : MonoBehaviour
//{
//    [SerializeField] private float totalTime = 180.0f; // Total countdown time in seconds
//    private float currentTime; // Current remaining time

//    public TextMeshProUGUI timerText; // Reference to the UI Text element

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Set initial time
//        currentTime = totalTime;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Update current time
//        currentTime -= Time.deltaTime;

//        // Clamp current time to avoid negative values
//        if (currentTime < 0)
//        {
//            currentTime = 0;
//            SceneManager.LoadScene("S1_Farhan 1");
//        }

//        // Calculate seconds
//        int seconds = Mathf.FloorToInt(currentTime);

//        // Update UI text with formatted time
//        timerText.text = seconds.ToString();
//    }
//}

//Updated
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Timer : MonoBehaviour
//{
//    [SerializeField] private float totalTime = 180.0f; // Total countdown time in seconds
//    private float currentTime; // Current remaining time

//    public TextMeshProUGUI timerText; // Reference to the UI Text element
//    private GameController gameController;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Set initial time
//        currentTime = totalTime;

//        // Find the GameController
//        gameController = FindObjectOfType<GameController>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Update current time
//        currentTime -= Time.deltaTime;

//        // Clamp current time to avoid negative values
//        if (currentTime < 0)
//        {
//            currentTime = 0;

//            // Check the game result
//            if (gameController != null)
//            {
//                gameController.CheckGameResult();
//            }
//        }

//        // Calculate seconds
//        int seconds = Mathf.FloorToInt(currentTime);

//        // Update UI text with formatted time
//        timerText.text = seconds.ToString();
//    }
//}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime = 180.0f; // Total countdown time in seconds
    private float currentTime; // Current remaining time

    public TextMeshProUGUI timerText; // Reference to the UI Text element
    private GameController gameController;

    // Variables for rotation
    private bool shouldRotate = false;
    public float rotationSpeed = 20.0f; // Speed of the oscillation
    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation

    // Start is called before the first frame update
    void Start()
    {
        // Set initial time
        currentTime = totalTime;

        // Find the GameController
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            // Update current time
            currentTime -= Time.deltaTime;
        }
        // Clamp current time to avoid negative values
        if (currentTime < 0)
        {
            currentTime = 0;

            // Check the game result
            if (gameController != null)
            {
                gameController.CheckGameResult();

                // Play red player animations based on the game result
                if (gameController.GetBlueBoxCount() > gameController.GetRedBoxCount())
                {
                    gameController.PlayRedLoseAnimation();
                }
                else
                {
                    gameController.PlayRedWinAnimation();
                }
            }
        }

        // Check if the current time is below the threshold
        if (currentTime < 10)
        {
            shouldRotate = true;
        }

        // Calculate seconds
        int seconds = Mathf.FloorToInt(currentTime);

        // Update UI text with formatted time
        timerText.text = seconds.ToString();

        // Apply oscillating rotation if shouldRotate is true
        if (shouldRotate)
        {
            float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
}

