using NUnit.Framework;
using UnityEngine;

public class Delete : MonoBehaviour
{
    void OnBecameInvisible()
   {
           Destroy(gameObject);
   }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Destroy(gameObject);
        }

    
    }
}
