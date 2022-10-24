using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ActorsStats",menuName = "Stats")]
public class ActorsStats : ScriptableObject
{
    [SerializeField] private Stats _stats;
 
 public int MaxLife => _stats.MaxLife;

 public float Speed => _stats.Speed;
}
[System.Serializable]
public struct Stats
{
    public int MaxLife;

    public float Speed;
    
    
}
