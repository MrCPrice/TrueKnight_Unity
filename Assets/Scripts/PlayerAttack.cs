using UnityEngine;

public class PlayerAttack : AttackSystem
{
    private bool inRange;
    private float lastUsedAttack;

    protected override void Awake()
    {
        base.Awake();
        tagTarget = "Enemy";
    }

    protected override void TargetInRangeHandler(bool inRange)
    {
        this.inRange = inRange;
        Debug.Log("in rangehandler is " + inRange);
    }

    void FixedUpdate()
    {
        //Debug.Log("in range is " + inRange);
        if(Input.GetKey("x"))
        {
            if(inRange == true && Time.time > lastUsedAttack + attackCoolDown)
            {
                var taggedEnemies = GameObject.FindGameObjectsWithTag(tagTarget);

                foreach(var enemy in taggedEnemies)
                {
                    if(target == null)
                    {
                     target = enemy;
                    }

                    float closestAttackDist = transform.position.magnitude - target.transform.position.magnitude;
                    float enemyAttackDist = transform.position.magnitude - enemy.transform.position.magnitude;

                    if(enemyAttackDist > closestAttackDist)
                    {
                        target = enemy;
                    }
                }

                if(target != null)
                {
                    target.GetComponent<HealthSystem>().TakeDamage(attackPower);
                }

                lastUsedAttack = Time.time;
            }
        }
    }
}
