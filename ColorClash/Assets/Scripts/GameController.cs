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

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameController : MonoBehaviour
//{
//    public List<GameObject> boxes;
//    public Slider progressSlider;
//    public GameObject loseCanvas;
//    public GameObject winCanvas;

//    private int totalBoxes;
//    private int blueBoxCount;

//    private void Start()
//    {
//        totalBoxes = boxes.Count;
//        progressSlider.maxValue = totalBoxes;

//        loseCanvas.SetActive(false);
//        winCanvas.SetActive(false);

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

//    public void CheckGameResult()
//    {
//        // Assuming totalBoxes - blueBoxCount is the number of red boxes
//        int redBoxCount = totalBoxes - blueBoxCount;

//        if (blueBoxCount <= redBoxCount)
//        {
//            Time.timeScale = 0;
//            loseCanvas.SetActive(true);
//        }
//        else
//        {
//            Time.timeScale = 0;
//            winCanvas.SetActive(true);
//        }
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameController : MonoBehaviour
//{
//    public List<GameObject> boxes;
//    public Slider progressSlider;
//    public GameObject loseCanvas;
//    public GameObject winCanvas;
//    public AudioClip collisionSound;

//    private AudioSource audioSource;
//    private int totalBoxes;
//    private int blueBoxCount;

//    private void Start()
//    {
//        totalBoxes = boxes.Count;
//        progressSlider.maxValue = totalBoxes;

//        loseCanvas.SetActive(false);
//        winCanvas.SetActive(false);

//        // Initialize the blue box count based on the initial state of the boxes
//        blueBoxCount = 0;

//        audioSource = GetComponent<AudioSource>();
//        if (audioSource == null)
//        {
//            audioSource = gameObject.AddComponent<AudioSource>();
//        }
//        audioSource.playOnAwake = false;

//        // Check initial state of boxes
//        foreach (var box in boxes)
//        {
//            Renderer renderer = box.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                Color boxColor = renderer.material.color;
//                string hexColor = ColorToHex(boxColor);
//                if (hexColor == "#00D3FF") // Hex value for blue
//                {
//                    blueBoxCount++;
//                }
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

//        // Play the collision sound effect
//        if (audioSource != null && collisionSound != null)
//        {
//            audioSource.PlayOneShot(collisionSound);
//        }

//    }

//    public void CheckGameResult()
//    {
//        // Assuming totalBoxes - blueBoxCount is the number of red boxes
//        int redBoxCount = totalBoxes - blueBoxCount;

//        if (blueBoxCount <= redBoxCount)
//        {
//            Time.timeScale = 0;
//            loseCanvas.SetActive(true);
//        }
//        else
//        {
//            Time.timeScale = 0;
//            winCanvas.SetActive(true);
//        }
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameController : MonoBehaviour
//{
//    public List<GameObject> boxes;
//    public Slider progressSlider;
//    public GameObject loseCanvas;
//    public GameObject winCanvas;
//    public AudioClip collisionSound;
//    public AudioClip winSound;
//    public AudioClip loseSound;

//    private AudioSource audioSource;
//    private int totalBoxes;
//    private int blueBoxCount;

//    private void Start()
//    {
//        totalBoxes = boxes.Count;
//        progressSlider.maxValue = totalBoxes;

//        loseCanvas.SetActive(false);
//        winCanvas.SetActive(false);

//        // Initialize the blue box count based on the initial state of the boxes
//        blueBoxCount = 0;

//        audioSource = GetComponent<AudioSource>();
//        if (audioSource == null)
//        {
//            audioSource = gameObject.AddComponent<AudioSource>();
//        }
//        audioSource.playOnAwake = false;

//        // Check initial state of boxes
//        foreach (var box in boxes)
//        {
//            Renderer renderer = box.GetComponent<Renderer>();
//            if (renderer != null)
//            {
//                Color boxColor = renderer.material.color;
//                string hexColor = ColorToHex(boxColor);
//                if (hexColor == "#00D3FF") // Hex value for blue
//                {
//                    blueBoxCount++;
//                }
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

//        // Play the collision sound effect
//        PlayCollisionSound();

//    }

//    public void PlayCollisionSound()
//    {
//        if (audioSource != null && collisionSound != null)
//        {
//            audioSource.PlayOneShot(collisionSound);
//        }
//    }

//    public void PlayWinSound()
//    {
//        if (audioSource != null && collisionSound != null)
//        {
//            audioSource.PlayOneShot(winSound);
//        }
//    }

//    public void PlayLoseSound()
//    {
//        if (audioSource != null && collisionSound != null)
//        {
//            audioSource.PlayOneShot(loseSound);
//        }
//    }

//    public void CheckGameResult()
//    {
//        int redBoxCount = totalBoxes - blueBoxCount;

//        if (blueBoxCount <= redBoxCount)
//        {
//            Time.timeScale = 0;
//            loseCanvas.SetActive(true);
//            PlayLoseSound();
//        }
//        else
//        {
//            Time.timeScale = 0;
//            winCanvas.SetActive(true);
//            PlayWinSound();
//        }
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
    public AudioClip collisionSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public GameObject blueParticleEffectPrefab;
    public GameObject redParticleEffectPrefab;

    private AudioSource audioSource;
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

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;

        // Check initial state of boxes
        foreach (var box in boxes)
        {
            Renderer renderer = box.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color boxColor = renderer.material.color;
                string hexColor = ColorToHex(boxColor);
                if (hexColor == "#00D3FF") // Hex value for blue
                {
                    blueBoxCount++;
                }
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

        // Play the collision sound effect
        PlayCollisionSound();

    }

    public void PlayCollisionSound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    public void PlayWinSound()
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
    }

    public void PlayLoseSound()
    {
        if (audioSource != null && loseSound != null)
        {
            audioSource.PlayOneShot(loseSound);
        }
    }

    public void PlayBlueParticleEffect(Vector3 position)
    {
        if (blueParticleEffectPrefab != null)
        {
            GameObject particleEffect = Instantiate(blueParticleEffectPrefab, position, Quaternion.identity);
            ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                Destroy(particleEffect, particleSystem.main.duration + 2);
            }
            else
            {
                Debug.LogError("ParticleSystem component is missing on the particleEffectPrefab!");
            }
        }
    }

    public void PlayRedParticleEffect(Vector3 position)
    {
        if (redParticleEffectPrefab != null)
        {
            GameObject particleEffect = Instantiate(redParticleEffectPrefab, position, Quaternion.identity);
            ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                Destroy(particleEffect, particleSystem.main.duration + 2);
            }
            else
            {
                Debug.LogError("ParticleSystem component is missing on the particleEffectPrefab!");
            }
        }
    }

    public void CheckGameResult()
    {
        int redBoxCount = totalBoxes - blueBoxCount;

        if (blueBoxCount <= redBoxCount)
        {
            Time.timeScale = 0;
            loseCanvas.SetActive(true);
            PlayLoseSound();
        }
        else
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);
            PlayWinSound();
        }
    }
}
