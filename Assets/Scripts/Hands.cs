using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] GameObject objectHeld;
    [SerializeField] GameObject hands;
    GameObject activeWeapon;
    // Start is called before the first frame update
    private void Awake()
    {
        if (objectHeld) 
        { 
            activeWeapon = Instantiate(objectHeld, hands.transform.position, hands.transform.rotation ,hands.transform);
        }
    }
    public void Pickup(GameObject objectPickedUp)
    {
        
    }
    public void Fire()
    {
        if (activeWeapon) 
        { 
            activeWeapon.GetComponent<RocketLaunch>().Attack();
        }
    }
}
