using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // The enemy prefab to be spawned
    [SerializeField] private GameObject[] enemies;
    // How long between each spawn
    [SerializeField] private float spawnTime = 3f;
    // An array of the spawn points this enemy can spawn from
    [SerializeField] private Transform[] spawnPoints;         


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    { 
        // Find a random index between zero and one less than the number of spawn points
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Find a random index between zero and one less than the number of enemy types
        int enemyIndex = Random.Range(0, enemies.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation
        Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}