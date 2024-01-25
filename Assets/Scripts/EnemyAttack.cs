using UnityEngine;
using System.Collections;

public class EnemyAttack : AttackSystem
{
    public bool isCooling;

    protected override void Awake()
    {
        base.Awake();
        tagTarget = "Player";
        target = GameObject.FindWithTag(tagTarget);
    }

    protected override void TargetInRangeHandler(bool inRange)
    {
        BasicAttackPlayer(inRange, isCooling);
    }

    public void BasicAttackPlayer(bool inRange, bool amOnCoolDown)
    {
        if(inRange == true && amOnCoolDown == false)
        {
            target.GetComponent<HealthSystem>().TakeDamage(attackPower);
            StartCoroutine(AttackOnCoolDown(amOnCoolDown));
        }
    }
}
