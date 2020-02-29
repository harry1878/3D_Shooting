using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] enemys;
    public float[] spawnTimes;
    public Transform[] spawnPoints;

    private void Start()
    {
        // InvokeReapeating("함수명", 2, 1)
        // 함수명을 2초후에 1초마다 실행시켜라
        InvokeRepeating("SpawnBunny", spawnTimes[0], spawnTimes[0]);
        InvokeRepeating("SpawnBear", spawnTimes[1], spawnTimes[1]);
        InvokeRepeating("SpawnElephant", spawnTimes[2], spawnTimes[2]);
    }

    private void SpawnBunny()
    {
        if (playerHealth.currentHealth <= 0) return;

        Instantiate(enemys[0],
                    spawnPoints[0].position,
                    spawnPoints[0].rotation);
    }

    private void SpawnBear()
    {
        if (playerHealth.currentHealth <= 0) return;

        Instantiate(enemys[1],
                    spawnPoints[1].position,
                    spawnPoints[1].rotation);
    }

    private void SpawnElephant()
    {
        if (playerHealth.currentHealth <= 0) return;

        Instantiate(enemys[2],
                    spawnPoints[2].position,
                    spawnPoints[2].rotation);
    }
}
