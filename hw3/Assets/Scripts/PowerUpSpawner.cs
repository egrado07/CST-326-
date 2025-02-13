using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps; 
    public float spawnInterval = 5f; // Time between spawns

    private float minX = -4.5f, maxX = 4.5f;
    private float minZ = -4.5f, maxZ = 4.5f;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 2f, spawnInterval);
    }

    void SpawnPowerUp()
    {
        if (powerUps.Length == 0) return;

        // Choose a random power-up
        GameObject powerUp = powerUps[Random.Range(0, powerUps.Length)];

        // Random position within the bounds
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));

        // Spawn the power-up
        Instantiate(powerUp, spawnPosition, Quaternion.identity);
    }
}
