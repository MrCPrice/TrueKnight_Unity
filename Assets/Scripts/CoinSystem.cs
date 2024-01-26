using UnityEngine;

public class CoinSystem : EnemyMovement
{
    public int coinValue = 10;
    public HUDManger HUDManger;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            HUDManger.AddToScore?.Invoke(coinValue);
            Destroy(gameObject);
        }
    }
}
