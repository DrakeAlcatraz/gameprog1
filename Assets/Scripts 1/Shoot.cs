
using Unity.Mathematics;

using UnityEngine;

public class Playershoot : Weapons

{
  public static Playershoot Instance;
    public Rigidbody2D Projectile;
   public int speed = 40;
  
    public GameObject origin;
    public Rigidbody2D  instantiatedProjectile;

  public float cooldown = 1;
    public float defaultFireDelay;

    void Awake() { Instance = this; }

    void Start()
    {
   
      defaultFireDelay = ShooterStats[shooterLevel].nextfire;
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
       cooldown = ShooterStats[shooterLevel].nextfire;
        
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





   
    
