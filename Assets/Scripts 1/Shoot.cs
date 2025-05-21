
using Unity.Mathematics;

using UnityEngine;

public class Playershoot : MonoBehaviour

{
    public GameObject  ShooterToCheck;
    public Rigidbody2D Projectile;
   public int speed = 40;
    public float cooldown;
    public float nextfire = 1f;

    public float defaultFireDelay;
      
    public float FireRate = 1;
    public GameObject origin;
    public Rigidbody2D  instantiatedProjectile;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        defaultFireDelay = nextfire;
        origin = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown<=0){ ShootLogic();}
       
    }

    void FixedUpdate(){
        rotateShooter();
    }

    public virtual void ShootLogic()
    {

          Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 direction = mousePos - transform.position;
          direction =direction.normalized;
          float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


     
                instantiatedProjectile = Instantiate(Projectile, origin.transform.position, quaternion.identity);
                instantiatedProjectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                instantiatedProjectile.transform.Translate(0.5f, -0.5f, 0);
                instantiatedProjectile.linearVelocity = direction * speed;
        cooldown = nextfire;
        
    }


    void rotateShooter()
    {
           Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           Vector2 direction = mousePos - transform.position;
           direction =direction.normalized;
           float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
 

}





   
    
