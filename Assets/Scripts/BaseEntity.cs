using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector]public Rigidbody2D rb;
    [SerializeField] public bool staticObject;
    [SerializeField] public float health;
    [SerializeField] public bool destructible;
    private void Awake()
    {
        if (!TryGetComponent<Rigidbody2D>(out rb))
        {
            Debug.Log("Rigidbody2D missing");
            Destroy(this.gameObject);
        }
        if (!TryGetComponent<Collider2D>(out Collider2D col))
        {

            Debug.Log("Collider2D missing");
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyEntity();
        }
    }
    public virtual void DestroyEntity()
    {
        if (destructible) Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
