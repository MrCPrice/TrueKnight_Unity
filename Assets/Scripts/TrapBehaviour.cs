using UnityEngine;
using System;

public class TrapBehaviour : MonoBehaviour
{
    public int trapDamage = Int32.MaxValue;
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<HealthSystem>().TakeDamage(trapDamage);
        }
    }
}
