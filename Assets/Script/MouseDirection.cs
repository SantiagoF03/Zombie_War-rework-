using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDirection : MonoBehaviour
{
    private Vector3 Objetive;

    [SerializeField] private Camera camera;

    [SerializeField] private float velocityMov;

    private Vector2 dirrection;

    private Rigidbody2D rb;

    private Vector2 input;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Objetive = camera.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadion = Mathf.Atan2(Objetive.y - transform.position.y, Objetive.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadion - 90;
        transform.rotation = Quaternion.Euler(0,0,anguloGrados);

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        dirrection = input.normalized;
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dirrection * velocityMov * Time.fixedDeltaTime);
    }
}
