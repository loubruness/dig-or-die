using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public GameObject player; // Assign the player prefab in the Inspector
    public GameObject target; // Assign the target prefab in the Inspector

    public void TakeDamage()
    {  
        Debug.Log("TakeDamage");
        var health = player.transform.GetComponentInChildren<Health>().health;
        if (health > 0)
        {
            player.transform.GetComponentInChildren<Health>().health -= 1;
        }

    }
    public void DealDamage(GameObject target)
    {
        Debug.Log("Target : " + target);
        var atm = target.transform.GetComponentInChildren<AttributesManager>();
        if (atm != null)
        {
            //Debug.Log("DealDamage " + target);
            atm.TakeDamage();
        }
    }
}
