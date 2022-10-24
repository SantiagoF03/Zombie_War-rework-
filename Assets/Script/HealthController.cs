using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int MaxLife;
    public int CurrentLife;
    // Start is called before the first frame update
    private void Start()
    {
        CurrentLife = MaxLife;
    }

    public void TakeDamage(int Damage)
    {
        CurrentLife -= Damage;

        if (CurrentLife <= 0) Death();

    }

    void Death()
    {
        Pool.RemovedGameObject(this.gameObject);
    }

    public void Revive()
    {
        CurrentLife = MaxLife;
    }
}
