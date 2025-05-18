
using UnityEngine;

public class EnemyHItLogic : MonoBehaviour
{
  public EnemyStats stats;


    void Start()
    {
    stats.Reset();
    }


    public void TakeDamage(float damage)
  {
    stats.Health -= damage;
    Debug.Log("Enemy took damage! Remaining HP: " + stats.Health);

    if (stats.Health <= 0)
    {
      Die();
    }
  }

  public void Die()
  {
    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GainXP(stats.ExpYield);
    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChargeUlt(stats.UltChargeYield);
    Destroy(gameObject);
  }
    
    
     }
            
            
    

