using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private ActorsStats _stats;
    [SerializeField] private ZombiesFeature _feature;
    [SerializeField] private HealthController _healthController;
    
    public GameObject Player;

    #region Stats

        private float velocity => _stats.Speed;
    
        private int Life => _stats.MaxLife;

        private float AttackRange => _feature.AttackRange;

        private float DetectionRange => _feature.DetactionRange;
        
    #endregion


    #region Status

    private bool isHunting;
    
    private bool isPatrolling;

    private bool isRangeAttack;
    

    #endregion

    #region ZombieType
    private bool isBoomberZombie => _feature.isBoomberZombie;
    private bool isRunnerZombie  => _feature.isRunnerZombie;
    private bool isCommunZombie  => _feature.isCommunZombie;

    #endregion
  
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position,Player.transform.position) < AttackRange)
        {
            isRangeAttack = true;
        }
        else
        {
            isRangeAttack = false;
        }
        
        if (Vector2.Distance(transform.position,Player.transform.position) < DetectionRange 
            || _healthController.CurrentLife < _healthController.MaxLife && !isHunting)
        {
            isHunting = true;
        }

        if (isHunting && !isRangeAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(Player.transform.position.x,Player.transform.position.y),velocity * Time.deltaTime);
        }
        else if (isRangeAttack)
        {
            Attack();
        }
        

    }

    void Attack()
    {
        if (isBoomberZombie)
        {
            
        }
        if (isRunnerZombie)
        {
            
        }
        if (isCommunZombie)
        {
            
        }
    }
}
