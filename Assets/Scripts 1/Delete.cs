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


    void Awake()
    {
        weaponLevel = 0;
    }
    void Start()
    {
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

         stats[1].pierceCount--;

            if ( stats[weaponLevel].pierceCount--<=0)
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
