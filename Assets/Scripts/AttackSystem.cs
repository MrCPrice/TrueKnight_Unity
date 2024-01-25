using UnityEngine;
using System.Collections;

public class AttackSystem : MonoBehaviour
{
    public int attackPower = 1;
    public float attackCoolDown = 3f;
    protected GameObject target;
    public string tagTarget;

    protected delegate void TargetInRange(bool isInRange, GameObject incoming);
    protected TargetInRange targetInRange;

    protected virtual void Awake()
    {
        targetInRange += TargetInRangeHandler;
    }

    protected virtual void TargetInRangeHandler(bool inRange, GameObject incoming){}

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == tagTarget)
        {
            targetInRange?.Invoke(true, collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == tagTarget)
        {
            targetInRange?.Invoke(false, collider.gameObject);
        }
    }

    void OnDestroy()
    {
        targetInRange?.Invoke(false, null);
        targetInRange -= TargetInRangeHandler;
    }

    protected IEnumerator AttackOnCoolDown(bool isCoolDownActive)
    {
        isCoolDownActive = true;
        yield return new WaitForSeconds(attackCoolDown);
        isCoolDownActive = false;
    }
}
