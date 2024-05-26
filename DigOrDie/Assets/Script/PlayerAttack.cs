
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private int Damage = 1;

    [SerializeField]
    public AttackArea _attackArea;

    private PlayerInput playerInput;

    private void Awake()
    {
                playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Attack"].performed += ctx => OnAttack();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Hit()
    {
        Debug.Log("Hit");
        yield return new WaitForSeconds(0.5f);
        foreach (var attackAreaDamageable in _attackArea.Damageables)
        {
            Debug.Log("Damage "+ attackAreaDamageable);
            attackAreaDamageable.Damage(Damage);
        }
    }
    public void OnAttack()
    {

            Debug.Log("OnAttack");

            StartCoroutine("Hit");
        
    }
}
