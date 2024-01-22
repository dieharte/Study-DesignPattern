using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPData : MonoBehaviour
{
    private const float timeToDeactivate = 5f;

    private float currentTime;
    private ObjectPoolManager pool;

    // Simulate construct
    public void Initialize(ObjectPoolManager objectPoolManager)
    {
        pool = objectPoolManager;
    }

    public void Restart()
    {
        currentTime = timeToDeactivate;
    }

    private void FixedUpdate()
    {
        currentTime -= Time.fixedDeltaTime;
        if(currentTime <= 0) 
        {
            pool.ReturnObject(this);
        }
    }
}
