using UnityEngine;

public class BossMovement : EnemyMovement
{
    public BossAttack bossAttack;

    void FixedUpdate()
    {
        if(bossAttack.isCooling == false)
        {
            MoveToPlayer();
        }
        
    }
}
