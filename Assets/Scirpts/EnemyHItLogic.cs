
using UnityEngine;

public class EnemyHItLogic : MonoBehaviour
{

    void OnCollisionStay2D(Collision2D collision){
          if(collision.gameObject.tag=="PlayerAttack")
          {
          Destroy(gameObject);
        }
     }
            
    }

