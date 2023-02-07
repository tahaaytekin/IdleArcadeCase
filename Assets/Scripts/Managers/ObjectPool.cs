using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : CustomBehaviour
{

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

    }
    #region SerializedPool
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public Transform parent;
    }
    #endregion
    #region Singleton
    public static ObjectPool instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, pool.parent);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    #region Overload 1
    public GameObject GetObject(string tag, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Böyle Bir Tag Bulunamadý : " + tag);
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        //IPooledObject pooledobject = objectToSpawn.GetComponent<IPooledObject>();
        //if (pooledobject != null)
        //{
        //    pooledobject.OnSpawn();
        //}
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    #endregion
    #region Overload 2
    public GameObject GetObject(string tag, Vector3 position, Transform parent)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Böyle Bir Tag Yok: " + tag);
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.transform.parent = parent;
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        //IPooledObject pooledobject = objectToSpawn.GetComponent<IPooledObject>();
        //if (pooledobject != null)
        //{
        //    pooledobject.OnSpawn();
        //}
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    #endregion
   
}
