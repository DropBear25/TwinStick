using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{

    [SerializeField]

    private GameObject prefab;

    [SerializeField]

    private int poolSize;

    [SerializeField]
    private bool expandable;


    private List<GameObject> freeLists;

    private List<GameObject> usedList;

    private void Awake()
    {
        freeLists = new List<GameObject>();
        usedList = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GenerateNewObject();
        }
    }

    public GameObject GetObject()
    {
        int totalFree = freeLists.Count;
        if (totalFree == 0 && !expandable) return null;
        else if (freeLists.Count == 0) GenerateNewObject();

        GameObject g = freeLists[totalFree -1];
        freeLists.RemoveAt(totalFree - 1);
        usedList.Add(g);
        return g;
    }

    public void ReturnObject(GameObject obj)
    {
        Debug.Assert(usedList.Contains(obj));
        obj.SetActive(false);
        usedList.Remove(obj);
        freeLists.Add(obj);
    }

    private void GenerateNewObject()
    {
        GameObject g = Instantiate(prefab);
        g.transform.parent = transform;
        g.SetActive(false);
        freeLists.Add(g);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
