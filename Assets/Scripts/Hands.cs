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
    public void Equip(GameObject newEquip) {
        BaseRangedWeapon useless;
        if (newEquip.TryGetComponent<BaseRangedWeapon>(out useless) && activeWeapon == null) 
        {
            objectHeld = newEquip;
            activeWeapon = Instantiate(objectHeld, hands.transform.position, hands.transform.rotation, hands.transform);
        }
        
    }
    public void Unequip()
    {
        if(activeWeapon != null)
        {
            activeWeapon = null;
            Destroy(hands.transform.GetChild(0).gameObject);
            objectHeld = null;
        }
        
    }
    public bool Fire()
    {
        if (activeWeapon) 
        { 
            activeWeapon.GetComponent<RocketLaunch>().Attack();
            return true;
        }
        return false;
    }
}
