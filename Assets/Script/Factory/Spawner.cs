using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : IFactory<T>
{
    public GameObject Create(GameObject prefab)
    {
        return GameObject.Instantiate(prefab);
    }
    
}
