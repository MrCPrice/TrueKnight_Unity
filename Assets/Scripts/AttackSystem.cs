using UnityEngine;
using System.Collections;

public class AttackSystem : MonoBehaviour
{
    public int attackPower = 1;
    public float attackCoolDown = 3f;
    protected GameObject target;
    protected string tagTarget;

    protected delegate void TargetInRange(bool isInRange);
    protected TargetInRange targetInRange;

    protected virtual void Awake()
    {
        targetInRange += TargetInRangeHandler;
    }

    protected virtual void TargetInRangeHandler(bool inRange){}

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == tagTarget)
        {
            Debug.Log("Staying " + gameObject.name);
            targetInRange?.Invoke(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == tagTarget)
        {
            Debug.Log("Exiting " + gameObject.name);
            targetInRange?.Invoke(false);
        }
    }

    void OnDestroy()
    {
        Debug.Log("Destroy " + gameObject.name);
        targetInRange?.Invoke(false);
        targetInRange -= TargetInRangeHandler;
    }

    protected IEnumerator AttackOnCoolDown(bool isCoolDownActive)
    {
        isCoolDownActive = true;
        yield return new WaitForSeconds(attackCoolDown);
        isCoolDownActive = false;
    }
}
