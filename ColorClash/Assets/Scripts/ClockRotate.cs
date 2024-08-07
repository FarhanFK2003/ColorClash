//using UnityEngine;

//public class TimedOscillation : MonoBehaviour
//{
//    public float delayBeforeOscillation = 20.0f; // Delay before oscillation starts
//    public float rotationSpeed = 20.0f; // Speed of the oscillation
//    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation

//    private bool shouldRotate = false;
//    private float elapsedTime = 0.0f; // Track elapsed time

//    // Update is called once per frame
//    void Update()
//    {
//        // Update elapsed time
//        elapsedTime += Time.deltaTime;

//        // Check if the elapsed time is greater than the delay
//        if (elapsedTime >= delayBeforeOscillation)
//        {
//            shouldRotate = true;
//        }

//        // Apply oscillating rotation if shouldRotate is true
//        if (shouldRotate)
//        {
//            float rotationZ = Mathf.Sin((elapsedTime - delayBeforeOscillation) * rotationSpeed) * rotationAmplitude;
//            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
//        }
//    }
//}

using UnityEngine;

public class TimedOscillation : MonoBehaviour
{
    public float delayBeforeOscillation = 10.0f; // Delay before oscillation starts
    public float rotationSpeed = 20.0f; // Speed of the oscillation
    public float rotationAmplitude = 5.0f; // Amplitude of the oscillation
    public AudioClip alertSound; // The sound clip to play
    private AudioSource audioSource; // The AudioSource component

    private bool shouldRotate = false;
    private bool soundPlayed = false; // To ensure the sound plays only once
    private float elapsedTime = 0.0f; // Track elapsed time

    void Start()
    {
        // Get the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time is greater than the delay
        if (elapsedTime >= delayBeforeOscillation)
        {
            shouldRotate = true;

            // Play the sound effect if it hasn't been played yet
            if (!soundPlayed)
            {
                audioSource.PlayOneShot(alertSound);
                soundPlayed = true;
            }
        }

        // Apply oscillating rotation if shouldRotate is true
        if (shouldRotate)
        {
            float rotationZ = Mathf.Sin((elapsedTime - delayBeforeOscillation) * rotationSpeed) * rotationAmplitude;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
}
