using UnityEngine;

public class PlayerAttack : AttackSystem
{
    private bool buttonPressed;
    private float lastUsedAttack;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void TargetInRangeHandler(bool inRange, GameObject incoming)
    {
        if(buttonPressed == true && inRange == true && Time.time > lastUsedAttack + attackCoolDown)
            {
                if(incoming == null)
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
                }
                else
                {
                    target = incoming;
                }

                if(target != null)
                {
                    target.GetComponent<HealthSystem>().TakeDamage(attackPower);
                }

                lastUsedAttack = Time.time;
            }
    }

    void FixedUpdate()
    {
        //Debug.Log("in range is " + inRange);
        if(Input.GetKey("x"))
        {
            buttonPressed = true;
        }
        else
        {
            buttonPressed = false;
        }
    }
}
