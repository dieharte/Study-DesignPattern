using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolSingleton : Singleton<ObjectPoolSingleton>
{
    private Dictionary<int, ObjectPool> pools = new Dictionary<int, ObjectPool>();

    public void SetupPool(OPDataBase prefab)
    {
        ObjectPool op = new ObjectPool(this, prefab);
        pools.Add(prefab.GetInstanceID(), op);
    }

    public OPDataBase GetObject(OPDataBase prefab) => pools[prefab.GetInstanceID()].GetObject();
    public void ReturnObject(OPDataBase prefab, OPDataBase currentInstance) => pools[prefab.GetInstanceID()].ReturnObject(currentInstance);
}

public class ObjectPool
{
    private MonoBehaviour singletonMono;
    private Transform parentHolder;
    private IObjectPool<OPDataBase> pool;
    private Component prefab;

    public ObjectPool(MonoBehaviour mono, Component prefab, bool collectionChecks = true, int maxPoolSize = 10)
    {
        this.prefab = prefab;
        parentHolder = new GameObject(prefab.name).transform;
        singletonMono = mono;
        pool = new ObjectPool<OPDataBase>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
    }

    public OPDataBase GetObject() => pool.Get();
    public void ReturnObject(OPDataBase current) => pool.Release(current);

    private OPDataBase CreatePooledItem()
    {
        var go = GameObject.Instantiate(prefab, parentHolder);
        (go as OPDataBase).Initialize(this);
        return (go as OPDataBase);
    }

    private void OnReturnedToPool(OPDataBase objectData)
    {
        objectData.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(OPDataBase objectData)
    {
        objectData.Restart();
        objectData.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(OPDataBase objectData)
    {
        GameObject.Destroy(objectData.gameObject);
    }
}
