using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class BaseObjectClass : BaseEntity
{
    [SerializeField] float mass;
    private void Awake()
    {
        //static or not
        //
        if (staticObject) rb.bodyType = RigidbodyType2D.Static;
        rb.mass = mass;
    }
    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            playerController col = collision.gameObject.GetComponent<playerController>();
            Vector2 compositeVelocity = col.rb.velocity - rb.velocity;
            float velDamage = compositeVelocity.Abs().x + compositeVelocity.Abs().y;
            //Debug.Log(velDamage);
            //col.TakeDamage(velDamage);
        }
    }
}
