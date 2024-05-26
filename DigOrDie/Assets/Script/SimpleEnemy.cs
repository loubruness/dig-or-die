using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;
using static UnityEngine.GraphicsBuffer;

public class SimpleEnemy : MonoBehaviour, IDamageable
{
    public GameObject player;
    public void Damage(int damageAmount)
    {
        Debug.Log($"SimpleEnemy took {damageAmount} damage!");
        //player.GetComponent<Health>().health -= damageAmount;
        player.transform.GetComponentInChildren<Health>().health -= 1;
    }

}
