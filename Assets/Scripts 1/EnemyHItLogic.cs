
using UnityEngine;

public class EnemyHItLogic : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision){
          if(collision.gameObject.tag=="PlayerAttack")
          {
          Destroy(gameObject);
        }
     }
            
    }

