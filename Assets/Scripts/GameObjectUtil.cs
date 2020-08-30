using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil
{
    
    private static Dictionary<RecycleGamObject, ObjectPool> pools = new Dictionary<RecycleGamObject, ObjectPool>();
    
    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        GameObject instance = null;

        var recycledScript = prefab.GetComponent<RecycleGamObject>();
        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pos).gameObject;
        } else {
            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }

        return instance;
    }

    public static void Destroy(GameObject gameObject)
    {
        var recyleGamObject = gameObject.GetComponent<RecycleGamObject>();

        if (recyleGamObject != null)
        {
            recyleGamObject.Shutdown();
        }
        else
        {
            GameObject.Destroy((gameObject));
        }    
    }

    private static ObjectPool GetObjectPool(RecycleGamObject reference)
    {
        ObjectPool pool = null;

        if (pools.ContainsKey(reference))
        {
            pool = pools[reference];
        }
        else
        {
            var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }

        return pool;
    }
}