using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingManager : MonoBehaviour
{
    public static BulletPoolingManager instance;

    [SerializeField] public GameObject poolingBulletPrefab = null;
    private Queue<Bullet> poolingBulletQueue = new Queue<Bullet>();

    void Awake() 
    {
        instance = this;

        Initialize(8);
    }

    private void Initialize(int initCount)
    {
        for(int i=0; i < initCount; i++)
        {
            poolingBulletQueue.Enqueue(CreateNewBullet());
        }
    }

    private Bullet CreateNewBullet()
    {
            var newObj = Instantiate(poolingBulletPrefab).GetComponent<Bullet>();
            newObj.gameObject.SetActive(false);
            newObj.transform.SetParent(transform);
            return newObj;
    }

    public static Bullet GetObject()
    {
        if(instance.poolingBulletQueue.Count> 0)
        {
            var obj = instance.poolingBulletQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = instance.CreateNewBullet();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Bullet obj)
    {
        instance.poolingBulletQueue.Enqueue(obj);
        obj.transform.SetParent(instance.transform);
        obj.gameObject.SetActive(false);
    }

   
   /*
    void Start()
    {
        

        for (int i = 0; i < 8; i++)
        {
            GameObject t_object = Instantiate(m_bulletPrefab, Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }

    }
    public void InsertQueue(GameObject p_obejct) // use object -> pool
    {
        // 비활성화 시킨 상태로 반납
        m_queue.Enqueue(p_obejct);
        p_obejct.SetActive(false);
    }

    public GameObject GetQueue() // 풀(큐) 에서 객체를 빌려오는 함수 // pool borrow object
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
    // Update is called once per frame
    void Update()
    {

    }*/
}
