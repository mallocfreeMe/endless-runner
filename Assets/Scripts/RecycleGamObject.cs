using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycle
{
    void Restart();
    void Shutdonw();
}


public class RecycleGamObject : MonoBehaviour
{

    private List<IRecycle> recycleCompoents;

    private void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        recycleCompoents = new List<IRecycle>();

        foreach (var component in components)
        {
            if (component is IRecycle)
            {
                recycleCompoents.Add(component as IRecycle); 
            }          
        }
        
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        
        foreach (var component in recycleCompoents)
        {
            component.Restart();
        }
    }

    public void Shutdown()
    {
        gameObject.SetActive(false);
        
        foreach (var component in recycleCompoents)
        {
            component.Shutdonw();
        }
    }
}