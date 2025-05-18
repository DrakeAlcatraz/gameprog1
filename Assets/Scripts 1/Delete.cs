using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DaggerLogic : MonoBehaviour
{
    public float baseAttack=2;
    public float pierceCount = 2;
    [SerializeField] private PlayerStats AtkBonus;
    float AdjustedAtk;
   private HashSet<GameObject> enemiesHit = new HashSet<GameObject>();

    void Start()
    {
        Debug.Log(AdjustedAtk);
        AdjustedAtk = baseAttack + (AtkBonus.attack / 2);
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

        pierceCount--;

        if (pierceCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}

}
