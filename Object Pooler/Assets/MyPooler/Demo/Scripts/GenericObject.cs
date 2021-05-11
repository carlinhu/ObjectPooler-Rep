using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObject : MonoBehaviour, PooledObjInterface
{
    public float defTimerToDestroy = 3f;
    public float timeToDestroy = 3f;
    public string poolTag;
    public bool isActive = false;

    public void OnObjectPooled()
    {
        isActive = true;
        timeToDestroy = defTimerToDestroy;
    }

    public void Discard()
    {
        MyPooler.ObjectPooler.Instance.ReturnToPool(poolTag, this.gameObject);
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0f)
            {
                Discard();
            }
        }
    }
}
