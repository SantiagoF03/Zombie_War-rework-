using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{
    
    float Speed { get; }
    int Damage { get; }
    float LifeTime { get; }

    void Travel();
    void OnTriggerEnter2D(Collider2D collider);
    GunStats Stats { get; }

}
