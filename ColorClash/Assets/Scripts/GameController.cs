//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameController : MonoBehaviour
//{
//    public List<GameObject> boxes;
//    public Slider progressSlider;

//    private int totalBoxes;
//    private int blueBoxCount;

//    private void Start()
//    {
//        totalBoxes = boxes.Count;
//        progressSlider.maxValue = totalBoxes;

//        // Initialize the blue box count based on the initial state of the boxes
//        blueBoxCount = 0;

//        List<GameObject> blueBoxes = boxes;
//        Debug.Log(blueBoxCount);
//        foreach (var box in blueBoxes)
//        {
//            Debug.Log("Enter");
//            Renderer renderer = box.GetComponent<Renderer>();
//            if (renderer != null && renderer.material.color == Color.blue)
//            {
//                Debug.Log(blueBoxCount);
//                blueBoxCount++;
//            }
//        }

//        // Set the initial value of the slider
//        progressSlider.value = blueBoxCount;
//    }

//    public void OnBoxColorChanged(GameObject box, bool isBlue)
//    {
//        if (isBlue)
//        {
//            blueBoxCount++;
//        }
//        else
//        {
//            blueBoxCount--;
//        }

//        // Clamp the slider value between 0 and totalBoxes
//        blueBoxCount = Mathf.Clamp(blueBoxCount, 0, totalBoxes);
//        progressSlider.value = blueBoxCount;
//    }
//}


//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameController : MonoBehaviour
//{
//    public List<GameObject> boxes;
//    public Slider progressSlider;

//    private int totalBoxes;
//    private int blueBoxCount;

//    private void Start()
//    {
//        totalBoxes = boxes.Count;
//        progressSlider.maxValue = totalBoxes;

//        // Initialize the blue box count based on the initial state of the boxes
//        blueBoxCount = 0;

//        List<GameObject> blueBoxes = boxes;
//        Debug.Log($"Total Boxes: {totalBoxes}");
//        foreach (var box in blueBoxes)
//        {
//            Debug.Log("Checking box...");
//            Renderer renderer = box.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                Color boxColor = renderer.material.color;
//                string hexColor = ColorToHex(boxColor);
//                Debug.Log($"Box Color Hex: {hexColor}");

//                if (hexColor == "#00D3FF") // Hex value for blue
//                {
//                    Debug.Log($"Found Blue Box! Current Count: {blueBoxCount}");
//                    blueBoxCount++;
//                }
//            }
//            else
//            {
//                Debug.Log("No Renderer found on the box.");
//            }
//        }

//        // Set the initial value of the slider
//        progressSlider.value = blueBoxCount;
//    }

//    // Method to convert Color to hexadecimal string
//    private string ColorToHex(Color color)
//    {
//        Color32 color32 = (Color32)color;
//        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
//    }

//    public void OnBoxColorChanged(GameObject box, bool isBlue)
//    {
//        if (isBlue)
//        {
//            blueBoxCount++;
//        }
//        else
//        {
//            blueBoxCount--;
//        }

//        // Clamp the slider value between 0 and totalBoxes
//        blueBoxCount = Mathf.Clamp(blueBoxCount, 0, totalBoxes);
//        progressSlider.value = blueBoxCount;
//    }
//}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> boxes;
    public Slider progressSlider;
    public GameObject loseCanvas;
    public GameObject winCanvas;

    private int totalBoxes;
    private int blueBoxCount;

    private void Start()
    {
        totalBoxes = boxes.Count;
        progressSlider.maxValue = totalBoxes;

        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);

        // Initialize the blue box count based on the initial state of the boxes
        blueBoxCount = 0;

        List<GameObject> blueBoxes = boxes;
        Debug.Log($"Total Boxes: {totalBoxes}");
        foreach (var box in blueBoxes)
        {
            Debug.Log("Checking box...");
            Renderer renderer = box.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color boxColor = renderer.material.color;
                string hexColor = ColorToHex(boxColor);
                Debug.Log($"Box Color Hex: {hexColor}");

                if (hexColor == "#00D3FF") // Hex value for blue
                {
                    Debug.Log($"Found Blue Box! Current Count: {blueBoxCount}");
                    blueBoxCount++;
                }
            }
            else
            {
                Debug.Log("No Renderer found on the box.");
            }
        }

        // Set the initial value of the slider
        progressSlider.value = blueBoxCount;
    }

    // Method to convert Color to hexadecimal string
    private string ColorToHex(Color color)
    {
        Color32 color32 = (Color32)color;
        return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
    }

    public void OnBoxColorChanged(GameObject box, bool isBlue)
    {
        if (isBlue)
        {
            blueBoxCount++;
        }
        else
        {
            blueBoxCount--;
        }

        // Clamp the slider value between 0 and totalBoxes
        blueBoxCount = Mathf.Clamp(blueBoxCount, 0, totalBoxes);
        progressSlider.value = blueBoxCount;
    }

    public void CheckGameResult()
    {
        // Assuming totalBoxes - blueBoxCount is the number of red boxes
        int redBoxCount = totalBoxes - blueBoxCount;

        if (blueBoxCount <= redBoxCount)
        {
            Time.timeScale = 0;
            loseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);
        }
    }
}
