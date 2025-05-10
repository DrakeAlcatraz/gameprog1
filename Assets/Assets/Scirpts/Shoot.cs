using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PLayershoot : MonoBehaviour
{
    public Rigidbody2D Projectile;
    int speed = 40;
    float nextfire = 1f;
    public GameObject Player;
     Rigidbody2D  instantiatedProjectile;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
      direction =direction.normalized;
          float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if(nextfire<=0){
         instantiatedProjectile = Instantiate(Projectile, Player.transform.position , quaternion.identity );
        instantiatedProjectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        instantiatedProjectile.linearVelocity= direction*speed;
        nextfire=2;
        }else{
            nextfire -= Time.deltaTime;
        }

        
    }
 
  

   }
    
