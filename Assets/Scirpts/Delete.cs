using UnityEngine;

public class Delete : MonoBehaviour
{
    void OnBecameInvisible()
   {
           Destroy(gameObject);
   }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Destroy(gameObject);
        }
    }
}
