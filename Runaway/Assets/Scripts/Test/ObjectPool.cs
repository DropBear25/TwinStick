using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PoolItem{
    public GameObject prefab;
    public int amount;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool singleton;
    public List<PoolItem> items;
    public List<GameObject> poolItems;

     void Awake()
    {
        singleton = this;  
    }

    public GameObject Get(string tag)
    {
        for(int i = 0; i < poolItems.Count; i++)
        {
            if(!poolItems[i].activeInHierarchy && poolItems[i].tag == tag)
            {
                return poolItems[i];
            }
        }
        return null;
    }

     void Start()
    {
        poolItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                poolItems.Add(obj);
            }
        }
    }
}
