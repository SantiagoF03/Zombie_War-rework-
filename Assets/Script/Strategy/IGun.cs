using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun : IWeapon
{
    GunStats Stats { get; }
    GameObject BulletPrefab { get; }
    int MagSize { get; }

    void Reload();
    
}
