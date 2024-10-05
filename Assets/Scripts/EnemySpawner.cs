using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;

    private readonly float[] positions = { -2.2F, -1.1F, 0F, 1.1F, 2.2F };

    [SerializeField]
    private float spawnInterval = 1.5F;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine() {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(2F);

        int enemyLevel = 1;
        int spawnCount = 0;
        float enemySpeed = 5F;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                int index = Random.Range(enemyLevel >= 4 ? enemyLevel - 4 : 0, enemyLevel);
                SpawnEnemy(positions[i], index, enemySpeed);
            }

            if (++spawnCount % 10 == 0) {
                enemyLevel++;
                enemySpeed += 2;

                yield return new WaitForSeconds(1F);
            }

            if (enemyLevel >= enemies.Length) {
                SpawnBoss();
                enemyLevel = 1;
                enemySpeed = 5F;
                GameManager.instance.changeBackGround();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float enemySpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y);
        GameObject enemyObj = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.SetEnemySpeed(enemySpeed);
    }

    void SpawnBoss() {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
