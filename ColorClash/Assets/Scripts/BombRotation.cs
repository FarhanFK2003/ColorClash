using UnityEngine;

public class BombRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public AudioClip audioClip;

    void Update()
    {
        // Rotate around the y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnDestroy()
    {
        // Create a temporary GameObject to play the destruction sound
        GameObject audioObject = new GameObject("TempAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Configure the AudioSource
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;

        // Play the audio clip
        audioSource.Play();

        // Destroy the temporary GameObject after the clip has finished playing
        Destroy(audioObject, audioClip.length);
    }
}