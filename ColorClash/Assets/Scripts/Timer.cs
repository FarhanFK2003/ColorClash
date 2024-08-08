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

//    // Variables for rotation
//    private bool shouldRotate = false;
//    public float rotationSpeed = 20.0f; // Speed of the oscillation
//    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation

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
//        if (currentTime > 0)
//        {
//            // Update current time
//            currentTime -= Time.deltaTime;
//        }
//        // Clamp current time to avoid negative values
//        if (currentTime < 0)
//        {
//            currentTime = 0;

//            // Check the game result
//            if (gameController != null)
//            {
//                gameController.CheckGameResult();

//                // Play red player animations based on the game result
//                if (gameController.GetBlueBoxCount() > gameController.GetRedBoxCount())
//                {
//                    gameController.PlayRedLoseAnimation();
//                }
//                else
//                {
//                    gameController.PlayRedWinAnimation();
//                }
//            }
//        }

//        // Check if the current time is below the threshold
//        if (currentTime < 10)
//        {
//            shouldRotate = true;
//        }

//        // Calculate seconds
//        int seconds = Mathf.FloorToInt(currentTime);

//        // Update UI text with formatted time
//        timerText.text = seconds.ToString();

//        // Apply oscillating rotation if shouldRotate is true
//        if (shouldRotate)
//        {
//            float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;
//            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
//        }
//    }
//}

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

//    // Variables for rotation
//    private bool shouldRotate = false;
//    public float rotationSpeed = 20.0f; // Speed of the oscillation
//    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation

//    // Reference to the RedPlayerController script
//    public RedPlayerController redPlayerController;

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
//        if (currentTime > 0)
//        {
//            // Update current time
//            currentTime -= Time.deltaTime;
//        }

//        // Clamp current time to avoid negative values
//        if (currentTime < 0)
//        {
//            currentTime = 0;

//            // Disable the RedPlayerController
//            if (redPlayerController != null)
//            {
//                redPlayerController.enabled = false;
//            }

//            // Check the game result
//            if (gameController != null)
//            {
//                gameController.CheckGameResult();

//                // Play red player animations based on the game result
//                if (gameController.GetBlueBoxCount() > gameController.GetRedBoxCount())
//                {
//                    gameController.PlayRedLoseAnimation();
//                }
//                else
//                {
//                    gameController.PlayRedWinAnimation();
//                }
//            }
//        }

//        // Check if the current time is below the threshold
//        if (currentTime < 10)
//        {
//            shouldRotate = true;
//        }

//        // Calculate seconds
//        int seconds = Mathf.FloorToInt(currentTime);

//        // Update UI text with formatted time
//        timerText.text = seconds.ToString();

//        // Apply oscillating rotation if shouldRotate is true
//        if (shouldRotate)
//        {
//            float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;
//            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
//        }
//    }
//}

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

//    // Variables for rotation
//    private bool shouldRotate = false;
//    public float rotationSpeed = 20.0f; // Speed of the oscillation
//    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation

//    // Reference to the RedPlayerController script
//    public RedPlayerController redPlayerController;

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
//        if (currentTime > 0)
//        {
//            // Update current time
//            currentTime -= Time.deltaTime;
//        }

//        // Clamp current time to avoid negative values
//        if (currentTime < 0)
//        {
//            currentTime = 0;

//            // Disable the RedPlayerController
//            if (redPlayerController != null)
//            {
//                redPlayerController.enabled = false;
//            }

//            // Disable all RedBallController scripts
//            DisableAllRedBallControllers();

//            // Check the game result
//            if (gameController != null)
//            {
//                gameController.CheckGameResult();

//                // Play red player animations based on the game result
//                if (gameController.GetBlueBoxCount() > gameController.GetRedBoxCount())
//                {
//                    gameController.PlayRedLoseAnimation();
//                }
//                else
//                {
//                    gameController.PlayRedWinAnimation();
//                }
//            }
//        }

//        // Check if the current time is below the threshold
//        if (currentTime < 10)
//        {
//            shouldRotate = true;
//        }

//        // Calculate seconds
//        int seconds = Mathf.FloorToInt(currentTime);

//        // Update UI text with formatted time
//        timerText.text = seconds.ToString();

//        // Apply oscillating rotation if shouldRotate is true
//        if (shouldRotate)
//        {
//            float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;
//            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
//        }
//    }

//    private void DisableAllRedBallControllers()
//    {
//        RedBallController[] redBallControllers = FindObjectsOfType<RedBallController>();
//        foreach (RedBallController redBallController in redBallControllers)
//        {
//            redBallController.enabled = false;
//            redBallController.gameObject.SetActive(false); // Set the red ball to inactive
//        }
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

    // Reference to the RedPlayerController script
    public RedPlayerController redPlayerController;

    // References to the game objects that need to be deactivated
    public GameObject blueCursor;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial time
        currentTime = totalTime;

        // Find the GameController
        gameController = FindObjectOfType<GameController>();

        // Find the BlueCursor and Arrow game objects
        if (blueCursor == null)
        {
            blueCursor = GameObject.Find("BlueCursor");
        }
        if (arrow == null)
        {
            arrow = GameObject.Find("Arrow");
        }
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

            // Get the BluePlayerController and set the timer up flag
            BluePlayerController bluePlayerController = FindObjectOfType<BluePlayerController>();
            if (bluePlayerController != null)
            {
                bluePlayerController.SetTimerUp();
            }


            // Disable the RedPlayerController
            if (redPlayerController != null)
            {
                redPlayerController.StopSpawning();
                redPlayerController.DeactivateAllRedBalls();
            }

            // Deactivate BlueCursor and Arrow
            if (blueCursor != null)
            {
                blueCursor.SetActive(false);
            }
            if (arrow != null)
            {
                arrow.SetActive(false);
            }

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

//    // Variables for rotation
//    private bool shouldRotate = false;
//    public float rotationSpeed = 20.0f; // Speed of the oscillation
//    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation

//    // References to the game objects that need to be deactivated
//    public GameObject blueCursor;
//    public GameObject arrow;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Set initial time
//        currentTime = totalTime;

//        // Find the GameController
//        gameController = FindObjectOfType<GameController>();

//        // Find the BlueCursor and Arrow game objects
//        if (blueCursor == null)
//        {
//            blueCursor = GameObject.Find("BlueCursor");
//        }
//        if (arrow == null)
//        {
//            arrow = GameObject.Find("Arrow");
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (currentTime > 0)
//        {
//            // Update current time
//            currentTime -= Time.deltaTime;
//        }
//        // Clamp current time to avoid negative values
//        if (currentTime < 0)
//        {
//            currentTime = 0;

//            // Deactivate BlueCursor and Arrow
//            if (blueCursor != null)
//            {
//                blueCursor.SetActive(false);
//            }
//            if (arrow != null)
//            {
//                arrow.SetActive(false);
//            }

//            // Check the game result
//            if (gameController != null)
//            {
//                gameController.CheckGameResult();

//                // Play red player animations based on the game result
//                if (gameController.GetBlueBoxCount() > gameController.GetRedBoxCount())
//                {
//                    gameController.PlayRedLoseAnimation();
//                }
//                else
//                {
//                    gameController.PlayRedWinAnimation();
//                }
//            }
//        }

//        // Check if the current time is below the threshold
//        if (currentTime < 10)
//        {
//            shouldRotate = true;
//        }

//        // Calculate seconds
//        int seconds = Mathf.FloorToInt(currentTime);

//        // Update UI text with formatted time
//        timerText.text = seconds.ToString();

//        // Apply oscillating rotation if shouldRotate is true
//        if (shouldRotate)
//        {
//            float rotationZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;
//            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
//        }
//    }
//}
