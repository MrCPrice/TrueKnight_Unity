using UnityEngine;
using System.Collections;

public class EnemyAttack : AttackSystem
{
    public bool isCooling;

    protected override void Awake()
    {
        base.Awake();
        target = GameObject.FindWithTag(tagTarget);
    }

    protected override void TargetInRangeHandler(bool inRange, GameObject incoming)
    {
        BasicAttackPlayer(inRange, isCooling, incoming);
    }

    public void BasicAttackPlayer(bool inRange, bool amOnCoolDown, GameObject incoming)
    {
        if(inRange == true && amOnCoolDown == false && incoming == target)
        {
            target.GetComponent<HealthSystem>().TakeDamage(attackPower);
            StartCoroutine(AttackOnCoolDown(amOnCoolDown));
        }
    }
}
