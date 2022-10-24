using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform SpawnBullet;

    public void Shoot()
    {
        GameObject _bullet = Instantiate(bullet, SpawnBullet.transform.position, SpawnBullet.rotation);
    }
}
