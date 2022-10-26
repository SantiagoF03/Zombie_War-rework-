using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthController : MonoBehaviour,IDamagable
{
    [SerializeField] private ActorsStats _stats;
    public int maxLife => MaxLife;
    public int MaxLife => _stats.MaxLife;
    
    public int CurrentLife;

    private int RegenratePerSeconds => _stats.RegeneratePerSeconds;
    
    private float TimeToStartCure => _stats.TimeRegenerateLife;
    private float currentTimeCure;
    
    // Start is called before the first frame update
    private void Start()
    {
        CurrentLife = MaxLife;
        StartCoroutine(StarCure());
    }

    private void Update()
    {
        if(MaxLife == CurrentLife)
        {
            if (currentTimeCure > 0)   currentTimeCure = 0;
        }
    }

    public void TakeDamage(int Damage)
    {
        CurrentLife -= Damage;

        if (CurrentLife <= 0) Death();

    }

    public void Health(int Cure)
    {
        CurrentLife += Cure;
    }


    public void Death()
    {
        Pool.RemovedGameObject(this.gameObject);
    }

    public void Revive()
    {
        CurrentLife = MaxLife;
    }

    IEnumerator StarCure()
    {
        while (true)
        {
            if (MaxLife > CurrentLife)
            {
                currentTimeCure += 1 + Time.deltaTime;
            }
            CurrentLife = Mathf.Clamp(CurrentLife, 0, maxLife);
            
            if (currentTimeCure >= TimeToStartCure)
            {
                Health(RegenratePerSeconds);
            }
            yield return new WaitForSeconds(1f);
                   
        }
      
        
       
    }
}
