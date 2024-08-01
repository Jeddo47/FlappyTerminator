using UnityEngine;
using UnityEngine.Pool;

public abstract class GenericSpawner<Type> : MonoBehaviour where Type : MonoBehaviour
{
    [SerializeField] private Type _objectType;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Type> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Type>(
            createFunc: () => Instantiate(_objectType),
            actionOnGet: OnGet,
            actionOnRelease: (objectType) => objectType.gameObject.SetActive(false),
            actionOnDestroy: OnTypeDestroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void ResetPool()
    {        
        _pool.Clear();
    }

    protected abstract void OnGet(Type objectType);    

    protected virtual void ReleaseObject(Type objectType) 
    {
        _pool.Release(objectType);    
    }

    protected virtual void GetObject() 
    {
        _pool.Get();    
    }

    private void OnTypeDestroy(Type objectType)
    {
        Destroy(objectType.gameObject);
    }
}
