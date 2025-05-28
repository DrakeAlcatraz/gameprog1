using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
public class DaggerLogic : Weapons
{
    [SerializeField] private PlayerStats AtkBonus;
   

    
     public float AdjustedAtk;
    public Animator animator;
    private HashSet<GameObject> enemiesHit = new HashSet<GameObject>();
    BoxCollider2D Box;


    void Start()
    {
          Box = gameObject.GetComponent<BoxCollider2D>();
        AdjustedAtk = stats[weaponLevel].baseAttack + (AtkBonus.attack / 2);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            if (enemiesHit.Contains(other.gameObject)) return;

            enemiesHit.Add(other.gameObject);

            EnemyHItLogic enemy = other.GetComponent<EnemyHItLogic>();
            if (enemy != null)
            {
                enemy.TakeDamage(AdjustedAtk);
                Debug.Log($"Dagger hit for {AdjustedAtk} damage");
            }



        }

        else if (other.CompareTag("BigEnemy"))
        {

            if (enemiesHit.Contains(other.gameObject)) return;

            enemiesHit.Add(other.gameObject);

            BIggerEnemyLogic Bigenemy = other.GetComponent<BIggerEnemyLogic>();
            if (Bigenemy != null)
            {
                Bigenemy.bigTakeDamage(AdjustedAtk);
                Debug.Log($"Dagger hit for {AdjustedAtk} damage");
            }



        }
            
              stats[1].pierceCount--;

                if (stats[weaponLevel].pierceCount-- <= 0)
                {
         
                    Box.enabled = false;
                    StartCoroutine(destroyProjectile());
                }
    }

    private IEnumerator destroyProjectile()
    {
        Playershoot.Instance.instantiatedProjectile.linearVelocity = new Vector2(0, 0);
        animator.Play("Destroy", 0, 0);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
