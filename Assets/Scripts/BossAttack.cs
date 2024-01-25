using UnityEngine;
using System.Collections;

public class BossAttack : EnemyAttack
{
    public float bossTimeForCoolDown = 15f;
    public GameObject enemyBullet;
    public GameObject spawner;
    public int numOfShots = 3;
    public float shotDelay = 5f;

    protected override void Awake()
    {
        base.Awake();
        attackCoolDown = bossTimeForCoolDown;
        StartCoroutine(BossShootingRoutine(numOfShots, shotDelay, bossTimeForCoolDown));
    }

    void ShootPlayer()
    {
        Instantiate(enemyBullet, spawner.transform.position, Quaternion.identity);
    }

    IEnumerator BossShootingRoutine(int cycles, float delayForShots, float coolDownTime)
    {
        for(int i = 0; i < cycles; i++)
        {
            ShootPlayer();
            yield return new WaitForSeconds(delayForShots);
        }

        isCooling = true;
        yield return new WaitForSeconds(coolDownTime);
        isCooling = false;

        StartCoroutine(BossShootingRoutine(cycles, delayForShots, coolDownTime));
    }
}