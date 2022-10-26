using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
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
    [SerializeField] private float explosionTime;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionIntensity;
    [SerializeField] private LayerMask layersToExplosion;

    private float currentExplosionTime;
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
       
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        currentExplosionTime += Time.deltaTime;

        if(currentExplosionTime >= explosionTime) 
        {
            DoExplosion();
        }
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= LifeTime)
       {
            Destroy(this.gameObject);
            Debug.Log("boom");
                
                
         }

        bulletMovement();
    }

    private void DoExplosion()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, explosionRadius, layersToExplosion);

        for(int i= 0; i < colliders.Length; i++) 
        {

            Rigidbody2D rigidbody = colliders[i].gameObject.GetComponent<Rigidbody2D>();

            if(rigidbody != null)
            {
                Vector3 targetPosition = colliders[i].transform.position;
                Vector3 direction = targetPosition - transform.position;
                float distance = direction.magnitude;
                Vector3 directionNormalized = direction.normalized;

                rigidbody.AddForce(directionNormalized * explosionIntensity, ForceMode2D.Impulse);
                Debug.Log("boom2");
            }
            Debug.Log("boom");
        }
        

    }


    public void SetOwner(IGun gun) => _owner = gun;

}
