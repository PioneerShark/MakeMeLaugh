using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [HideInInspector] Rigidbody2D rb;
    [SerializeField] float speed, damage, health;
    void Start()
    {
        if (!(TryGetComponent<Rigidbody2D>(out rb))) {
            Debug.Log("Rigidbody2D missing");
            Destroy(this.gameObject);
        }
        if (!(TryGetComponent<Collider2D>(out Collider2D col))) { 
            
            Debug.Log("Collider2D missing");
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    private void Update()
    {
        transform.Translate(rb.velocity.x + speed*Time.deltaTime, rb.velocity.y, 0);
    }

    private void OnDestroy()
    {
        Debug.Log("wow, that really was Destroyed");    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController col = collision.gameObject.GetComponent<playerController>();
            col.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
