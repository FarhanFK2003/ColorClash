using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    public GameObject[] cubePrefabs; // Array of cube prefabs to instantiate
    public Transform playableField; // The area where cubes can be instantiated

    void Start()
    {
        // Call a method to instantiate cubes at random positions within the playable field
        InstantiateRandomCubes();
    }

    void InstantiateRandomCubes()
    {
        int numCubes = Random.Range(50, 100); // Randomly choose between 50 to 100 cubes to spawn

        for (int i = 0; i < numCubes; i++)
        {
            // Randomly select a cube prefab from the cubePrefabs array
            GameObject cubePrefab = cubePrefabs[Random.Range(0, cubePrefabs.Length)];

            // Calculate random position within the playable field
            Vector3 randomPosition = CalculateRandomPosition();

            // Instantiate the cube prefab at the calculated random position with no rotation
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 CalculateRandomPosition()
    {
        // Size of the playable field
        float width = playableField.localScale.x;
        float height = playableField.localScale.z;

        // Random position within the bounds of the playable field
        float xPosition = Random.Range(playableField.position.x - width / 2f, playableField.position.x + width / 2f);
        float zPosition = Random.Range(playableField.position.z - height / 2f, playableField.position.z + height / 2f);

        return new Vector3(xPosition, 0.5f, zPosition);
    }
}
