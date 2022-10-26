using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    [SerializeField] private List<int> _layerMasks;



    public IGun Owner => _owner;
    private IGun _owner;

    public float Speed => Owner.Stats.BulletSpeed;
    public int Damage => Owner.Stats.BulletDamage;
    public float LifeTime => Owner.Stats.BulletLifeTime;
    private float _currentLifeTime;
    
    void bulletMovement()
    {
        transform.Translate(Vector2.right * (Speed * Time.deltaTime));
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (_layerMasks.Contains(collider.gameObject.layer))
        {
            GameObject collisionGameObject = collider.gameObject;
            HealthController objectHealthController = collisionGameObject.GetComponent<HealthController>();
            objectHealthController?.TakeDamage(10);

            Destroy(this.gameObject);
        }
    }



    void Start()
    {
        _currentLifeTime = LifeTime;
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        _currentLifeTime -= Time.deltaTime;
        if (_currentLifeTime <= 0) Destroy(this.gameObject);

        bulletMovement();
    }


    public void SetOwner(IGun gun) => _owner = gun;




}
