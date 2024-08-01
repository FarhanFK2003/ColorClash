using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> boxes;
    public Slider progressSlider;

    private int totalBoxes;
    private int blueBoxCount;

    private void Start()
    {
        totalBoxes = boxes.Count;
        progressSlider.maxValue = totalBoxes;

        // Initialize the blue box count based on the initial state of the boxes
        blueBoxCount = 0;

        List<GameObject> blueBoxes = boxes;
        Debug.Log(blueBoxCount);
        foreach (var box in blueBoxes)
        {
            Debug.Log("Enter");
            Renderer renderer = box.GetComponent<Renderer>();
            if (renderer != null && renderer.material.color == Color.blue)
            {
                Debug.Log(blueBoxCount);
                blueBoxCount++;
            }
        }

        // Set the initial value of the slider
        progressSlider.value = blueBoxCount;
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
}
