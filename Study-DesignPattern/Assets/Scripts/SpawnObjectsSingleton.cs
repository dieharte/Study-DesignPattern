using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsSingleton : MonoBehaviour
{
    [SerializeField] private OPDataBase prefab;
    [SerializeField] private Vector3 minRandomPosition;
    [SerializeField] private Vector3 maxRandomPosition;

    private float GetRandomPositionX => Random.Range(minRandomPosition.x, maxRandomPosition.x);
    private float GetRandomPositionY => Random.Range(minRandomPosition.y, maxRandomPosition.y);
    private float GetRandomPositionZ => Random.Range(minRandomPosition.z, maxRandomPosition.z);

    private OPDataBase currentObject;

    private void Start()
    {
        ObjectPoolSingleton.Instance.SetupPool(prefab);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentObject = ObjectPoolSingleton.Instance.GetObject(prefab);
            currentObject.transform.position = new Vector3(GetRandomPositionX, GetRandomPositionY, GetRandomPositionZ);
        }
    }

}
