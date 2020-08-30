using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public RecycleGamObject prefab;

    private List<RecycleGamObject> poolInstances = new List<RecycleGamObject>();

    private RecycleGamObject CreateInstance(Vector3 pos)
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;
        
        poolInstances.Add(clone);

        return clone;
    }

    public RecycleGamObject NextObject(Vector3 pos)
    {
        RecycleGamObject instance = null;

        instance = CreateInstance(pos);
        instance.Restart();

        return instance;
    }
}
