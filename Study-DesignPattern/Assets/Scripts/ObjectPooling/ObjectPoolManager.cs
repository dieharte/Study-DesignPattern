using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private OPData prefab;
    private Transform parentHolder;
    private IObjectPool<OPData> pool;

    public bool collectionChecks = true;
    public int maxPoolSize = 10;

    private void Start()
    {
        parentHolder = new GameObject("OPData Holder").transform;
        pool = new ObjectPool<OPData>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
    }

    public OPData GetObject() => pool.Get();
    public void ReturnObject(OPData current) => pool.Release(current);

    private OPData CreatePooledItem()
    {
        var go = Instantiate(prefab, parentHolder);
        go.Initialize(this);
        return go;
    }

    private void OnReturnedToPool(OPData objectData)
    {
        objectData.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(OPData objectData)
    {
        objectData.Restart();
        objectData.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(OPData objectData)
    {
        Destroy(objectData.gameObject);
    }
}
