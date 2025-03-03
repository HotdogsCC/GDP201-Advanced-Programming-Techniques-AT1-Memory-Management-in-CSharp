
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Object to pool
    [SerializeField] private GameObject objectToPool;
    //Pool of objects
    [SerializeField]private List<GameObject> objectPool;
    [SerializeField]private int intialSize = 50;

    //Singleton reference
    private static ObjectPool instance;

    //Getter for the instance
    public static ObjectPool Get()
    {
        return instance;
    }

    ObjectPool()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Intialise the object pool with some objects 
        for (int i = 0; i < intialSize; i++)
        {
            Instantiate(objectToPool).SetActive(false);
        }
          
    }

    public GameObject GetObject()
    {
        //Find first inactive object and return it
        
        
        //Otherwise create a new one and expand pool
        GameObject newObject = Instantiate(objectToPool);
        objectPool.Add(newObject);
        return newObject;

    }

    
    //Function for returning objects to the pool
    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
    }
    
   
}
