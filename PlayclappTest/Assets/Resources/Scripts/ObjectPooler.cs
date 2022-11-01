using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler instance;

    public static List<GameObject> poolObjectsTarget = new List<GameObject>();
    public int ColOfPool = 6;

    [SerializeField] private GameObject TargedPre;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

        for (int i = 0; i < ColOfPool; i++)
        {
            GameObject obj = Instantiate(TargedPre);
            obj.SetActive(false);
            poolObjectsTarget.Add(obj);
        }
    }

    public GameObject SpawnCube()
    {
        for (int i = 0; i < poolObjectsTarget.Count; i++)
        {
            if (!poolObjectsTarget[i].activeInHierarchy)
            {
                return poolObjectsTarget[i];
            }

        }
        return null;
    }



}