using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int hp = 10;
    public delegate void OnObejctDeath(GameObject character);
    public OnObejctDeath onObejctDeath;
    public Slider HealthBar = null;
    public GameObject Coin;

    void Awake()
    {
        onObejctDeath += DeathHandler;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if(hp<=0)
        {
            onObejctDeath?.Invoke(gameObject);
            onObejctDeath = null;
        }

        if(HealthBar != null)
        {
            HealthBar.value = hp;
        }
    }

    public void DeathHandler(GameObject character)
    {
        if(gameObject == character)
        {
            switch(character.tag)
            {
                case "Player":
                    Destroy(character);
                    SceneManager.LoadScene(2);
                    break;

                case "Boss":
                    Destroy(character);
                    SceneManager.LoadScene(3);
                    break;

                case "Enemy":
                    DropCoins(character);
                    GameSupervisor.Instance.spawnEnemies.OnEnemyDead(character);
                    GameSupervisor.Instance.enemyKilled?.Invoke();
                    Destroy(character);
                    break;

                default:
                    break;
            }
        }
    }

    void OnDestroy()
    {
        onObejctDeath -= DeathHandler;
    }

    private void DropCoins(GameObject character)
    {
        int amountDrop = Random.Range(3,9);

        for(int i=0;i<amountDrop;i++)
        {
            Instantiate(Coin, character.transform.position, Quaternion.identity);
        }
    }
}
