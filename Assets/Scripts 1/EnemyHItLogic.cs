
using UnityEngine;

public class EnemyHItLogic : MonoBehaviour
{
  public EnemyStats Expyield;

 
 

    void OnCollisionEnter2D(Collision2D collision){
          if(collision.gameObject.tag=="PlayerAttack")
          {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GainXP(Expyield.ExpYield);
          Destroy(gameObject);
        }
     }
            
    }

