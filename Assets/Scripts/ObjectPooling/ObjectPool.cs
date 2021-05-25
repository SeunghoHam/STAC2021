using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] GameObject poolingObjectPrefab;
    Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;

        Initialize(20);
    }
    
    private Bullet CreateNewObject()
    {
        //var newObj = Instantiate(poolingObjectPrefab, transform).GetComponent<Bullet>();
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform); // 이 구문 좀 고민됨
        return newObj;
    }
    private void Initialize(int initCount)
    {
        for(int i=0; i <initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }
    public static Bullet GetObject()
    {
        if(Instance.poolingObjectQueue.Count > 0) // Object in Queue
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null); // Sequence (순서) 중요
            obj.gameObject.SetActive(true);
            return obj;
        }   
        else // Object Not in Queue
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
        
    }
    public static void ReturnObject(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(bullet);
    }
}
