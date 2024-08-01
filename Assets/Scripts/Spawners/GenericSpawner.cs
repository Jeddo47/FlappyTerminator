using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public abstract class GenericSpawner<Type> : MonoBehaviour where Type : MonoBehaviour
{
    [SerializeField] private Type _prefabType;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Type> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Type>(
            createFunc: () => Instantiate(_prefabType),
            actionOnGet: OnGet,
            actionOnRelease: (prefabType) => prefabType.gameObject.SetActive(false),
            actionOnDestroy: OnTypeDestroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void ResetPool()
    {        
        _pool.Dispose();
    }

    protected abstract void OnGet(Type prefabType);    

    protected virtual void ReleaseObject(Type prefabType) 
    {
        _pool.Release(prefabType);    
    }

    protected virtual void GetObject() 
    {
        _pool.Get();    
    }

    private void OnTypeDestroy(Type prefabType)
    {
        Destroy(prefabType);
    }
}
