using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ZombieFeature",menuName = "Feature")]
public class ZombiesFeature : ScriptableObject
{
   [SerializeField] private FeaturesZombie _featuresZombie;
   
   public float AttackRange => _featuresZombie.AttackRange;

   public float DetactionRange => _featuresZombie.DetactionRange;
   
   
   public bool isBoomberZombie => _featuresZombie.isBoomberZombie;
   public bool isRunnerZombie  => _featuresZombie.isRunnerZombie;
   public bool isCommunZombie  => _featuresZombie.isCommunZombie;
}
[System.Serializable]
public struct FeaturesZombie
{
   public float AttackRange;
   
   public float DetactionRange;
   
   public bool isBoomberZombie;
   public bool isRunnerZombie;
   public bool isCommunZombie;
}
