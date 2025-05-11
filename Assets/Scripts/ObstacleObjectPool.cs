using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] objPrefab;
    [SerializeField] private int initPoolsize;


    [SerializeField] private List<GameObject> objPool = new List<GameObject>();

    private static ObstacleObjectPool instance;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public static ObstacleObjectPool GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        CreateNewObj();
    }

    private void CreateNewObj()
    {
        int j = 0;
        for (int i = 0; i < initPoolsize; i++,j++)
        {
            if (j > objPrefab.Length - 1)
            {
                j = 0;
            }
            GameObject obj = Instantiate(objPrefab[j]);
            obj.SetActive(false);
            objPool.Add(obj);
        }
    }

    public GameObject Acquire()
    {
        if (objPool.Count == 0)
        {
            CreateNewObj();
        }

        GameObject obj = objPool[0];
        objPool.RemoveAt(0);
        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj) 
    {
        objPool.Add(obj);
        obj.SetActive(false);
    }

}
