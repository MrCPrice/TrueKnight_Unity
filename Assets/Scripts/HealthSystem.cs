using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int hp = 10;
    public delegate void OnObejctDeath(GameObject character);
    public OnObejctDeath onObejctDeath;

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
}
