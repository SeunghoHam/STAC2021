using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] GameObject poolingObjectPrefab;
    Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    private void Awkae()
    {
        Instance = this;
        
    }
    private void Initalize(int initCount)
    {
        for(int i=0; i <initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateObject());
        }
    }
    private Bullet CreateObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform); // 이 구문 좀 고민됨
        return newObj;
    }
    public static Bullet GetObject()
    {
        if(Instance.poolingObjectQueue.Count > 0) // Object in Queue
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }   
        else
        {
            var newObj = Instance.CreateObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
        
    }
    public static void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
