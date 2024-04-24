using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponController : MonoBehaviour
{
    public GameObject sword;
    public bool canAttack = true;
    [FormerlySerializedAs("SwordAttackCd")] public float swordAttackCd = 3;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                SwordAttack();
            }
        }
    }

    void SwordAttack()
    {
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(resetSwordAttackCd());
    }

    IEnumerator resetSwordAttackCd()
    {
        yield return new WaitForSeconds(swordAttackCd);
        canAttack = true;
    }
}
