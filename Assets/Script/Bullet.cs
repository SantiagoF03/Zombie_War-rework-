using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _timeLife;
    [SerializeField] private int _BulletMove;
    void Update()
    {
        Destroy(this.gameObject,_timeLife);
        bulletMovement();
    }

    void bulletMovement()
    {
        transform.Translate(Vector2.right * (_BulletMove * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject collisionGameObject = col.gameObject;
        HealthController objectHealthController = collisionGameObject.GetComponent<HealthController>();
        objectHealthController?.TakeDamage(10);
    }
}
