using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private int totalNumberOfEnemyCanSpawn = 6;
    [SerializeField] private GameObject typeEnemy;

    public List<GameObject> enemiesSpawned = new List<GameObject>();

    private void Update()
    {
        CheckEnemyCount();
    }

    private void CheckEnemyCount()
    {
        if(totalNumberOfEnemyCanSpawn > 0 && enemiesSpawned.Count < 3 )
        {
            SpawnAnEnemy();
        }
    }

    private void SpawnAnEnemy()
    {
        Vector3 area = new Vector3(Random.Range(-5,5),Random.Range(2,5),Random.Range(-5,5)) + gameObject.transform.position;
        enemiesSpawned.Add(Instantiate(typeEnemy, area, Quaternion.identity, gameObject.transform));
        totalNumberOfEnemyCanSpawn--;
    }

    public void OnEnemyDead(GameObject theEnemy)
    {
        if(enemiesSpawned.Contains(theEnemy))
            enemiesSpawned.Remove(theEnemy);
    }
}
