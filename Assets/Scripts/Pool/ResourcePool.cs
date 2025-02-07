using System.Collections.Generic;
using UnityEngine;
public class ResourcePool<T> where T : MonoBehaviour
{
    private Queue<T> pool;
    private T prefab;
    private Transform parent;
    public ResourcePool(T prefab, int size, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
        pool = new Queue<T>();
        InitializePool(size);
    }
    private void InitializePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            CreateNewObject();
        }
    }
    private void CreateNewObject()
    {
        T newObject = GameObject.Instantiate(prefab, parent);
        newObject.gameObject.SetActive(false);
        pool.Enqueue(newObject);
    }
    public T GetObject()
    {
        if (pool.Count > 0)
        {
            T tempObject = pool.Dequeue();
            tempObject.gameObject.SetActive(true);
            return tempObject;
        }
        else
        {
            T tempObject = GameObject.Instantiate(prefab, parent);
            tempObject.gameObject.SetActive(true);
            return tempObject;
        }
    }
    public void ReturnObject(T returnedObject)
    {
        returnedObject.gameObject.SetActive(false);
        pool.Enqueue(returnedObject);
    }
}
