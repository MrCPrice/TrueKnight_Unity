using UnityEngine;

public class CoinSystem : EnemyMovement
{
    public int coinValue = 10;
    public HUDManger HUDManger;
    private GameObject HUDParent;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        HUDParent = GameObject.FindWithTag("HUDManger");
        HUDManger = HUDParent.GetComponent<HUDManger>();
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
