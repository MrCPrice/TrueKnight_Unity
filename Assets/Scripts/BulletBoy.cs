using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoy : MonoBehaviour
{
    private string tagTarget = "Player";
    public float bulletSpeed = 0.5f;
    public int dmg = 1;
    public float lifeTime = 10f;
    private GameObject target;

    void Awake()
    {
        target = GameObject.FindWithTag(tagTarget);
        StartCoroutine(SelfDestruct());
    }

        void Update()
    {
        GoKillPlayer();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<HealthSystem>().TakeDamage(dmg);
            Destroy(gameObject);
        }
    }

    void GoKillPlayer()
    {
        if(target != null)
        {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
