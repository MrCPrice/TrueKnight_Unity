using UnityEngine;

public class EnemyMovement : Movement
{
    public float awarnessRange = 15;
    public GameObject player;

    public void MoveToPlayer()
    {
        if(player == null)
        {
            Debug.LogError("player is null");
        }

        float distToPlayer = Vector3.Distance(transform.position,player.transform.position);

        if(distToPlayer < awarnessRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        MoveToPlayer();
    }
}