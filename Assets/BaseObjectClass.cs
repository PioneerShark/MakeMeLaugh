using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class BaseObjectClass : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool staticObject;
    [SerializeField] float health;
    [SerializeField] float mass;
    [SerializeField] bool destructible;
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
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy();
        }
    }
    public virtual void Destroy() {
        if (destructible) this.Destroy();
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
