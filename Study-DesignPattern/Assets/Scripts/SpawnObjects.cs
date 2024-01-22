using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private ObjectPoolManager poolManager;
    [SerializeField] private Vector3 minRandomPosition;
    [SerializeField] private Vector3 maxRandomPosition;

    private float GetRandomPositionX => Random.Range(minRandomPosition.x, maxRandomPosition.x);
    private float GetRandomPositionY => Random.Range(minRandomPosition.y, maxRandomPosition.y);
    private float GetRandomPositionZ => Random.Range(minRandomPosition.z, maxRandomPosition.z);
    
    private OPData currentObject;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentObject = poolManager.GetObject();
            currentObject.transform.position = new Vector3(GetRandomPositionX, GetRandomPositionY, GetRandomPositionZ);
        }
    }

}
