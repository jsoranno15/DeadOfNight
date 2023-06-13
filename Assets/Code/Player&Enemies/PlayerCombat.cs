using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }
    }

    void Attack()
    {
        //Play animation
        anim.SetTrigger("Melee");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("hit");
            enemy.GetComponent<Enemy1>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected(){
        if (attackPoint != null){
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
