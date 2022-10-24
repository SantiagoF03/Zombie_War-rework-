using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Testeo : MonoBehaviour
{
    public int cantidad;
    public GameObject zombie;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cantidad > 0)
        {
            Pool.ZombieInstance(zombie,transform.position,quaternion.identity,this.transform);
            cantidad--;
        }
        
        
            
        
    }
}
