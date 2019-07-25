using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathButtonPool : MonoBehaviour
{
    //singelton set up
    private PathButtonPool()
    { }

    void Awake()
    { instance = this;  }

    public static PathButtonPool instance;

    //variables
    public GameObject prefab;
    public Stack<GameObject> prefabStack = new Stack<GameObject>();

    public GameObject GetPooledObject()
    {
        GameObject prefabToSpawn;
        if (prefabStack.Count == 0)
        {
            prefabToSpawn = GameObject.Instantiate(prefab);
            prefabToSpawn.AddComponent<Pool>().pool = this;
            return prefabToSpawn;
        }
        else
        {
            prefabToSpawn = prefabStack.Pop();
            prefabToSpawn.SetActive(true);
            return prefabToSpawn;
        }
    }

    public void ReturnToPool(GameObject toReturn)
    {
        if (toReturn.GetComponent<Pool>().pool == this)
        {
            toReturn.SetActive(false);
            toReturn.transform.SetParent(null);
            prefabStack.Push(toReturn);
        }
        else
        {
            Destroy(toReturn);
            Debug.Log("Object sent to wrong pool. Deleting...");
        }
    }
}
//helper class used to make sure object came from this pool
public class Pool : MonoBehaviour
{
    public PathButtonPool pool;
}
