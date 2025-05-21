using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DaggerLogic : Weapon
{
    [SerializeField] private PlayerStats AtkBonus;
   

   
     public float AdjustedAtk;
    public Animator animator;
    private HashSet<GameObject> enemiesHit = new HashSet<GameObject>();

    void Start()
    {
        Debug.Log(AdjustedAtk);
        AdjustedAtk = stats[0].baseAttack + (AtkBonus.attack / 2);
        Debug.Log(AdjustedAtk);
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

            stats[1].pierceCount--;

            if (  stats[1].pierceCount-- <= 0)
            {

                StartCoroutine(destroyProjectile());
            }
        }
    }

    private IEnumerator destroyProjectile()
    {
        animator.Play("Destroy", 0,0);
        yield return new WaitForSeconds(0.2f);
     Destroy(gameObject);
    }
}
