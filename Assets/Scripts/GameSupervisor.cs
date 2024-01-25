using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSupervisor : MonoBehaviour
{
    public static GameSupervisor Instance;
    public delegate void EnemyKilled();
    public EnemyKilled enemyKilled;
    private int count;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        enemyKilled += KillTheEnemy;
    }

    public void CheckIfAllEnemiesAlive()
    {
        var taggedEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        count = -1;

        foreach(var enemy in taggedEnemies)
        {
            Debug.Log(enemy.name);
            count++;
        }
        Debug.Log(count);
    }

    public void KillTheEnemy()
    {
        CheckIfAllEnemiesAlive();

        if(count <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}