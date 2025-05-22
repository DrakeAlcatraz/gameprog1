using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterTiming : Playershoot


{
  [SerializeField] Weapons ThisShooterLevel;
  public int thisLevel;
  public float AdjustedNextfire;
  public float customFireDelay;
  public float customDefault;

void Awake()
{
    if (ThisShooterLevel != null)
    {
        ThisShooterLevel.RegisterShooter(this);
    }
}

    void OnEnable()
    {
         UpdateAdjustedNextfire();
    }
    void Start()
  {
   
    thisLevel = ThisShooterLevel.shooterLevel;
    AdjustedNextfire = Instance.ShooterStats[thisLevel].nextfire + customFireDelay;
    customDefault = AdjustedNextfire;
  }


  public override void ShootLogic()
  {

    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 direction = mousePos - transform.position;
    direction = direction.normalized;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;




    instantiatedProjectile = Instantiate(Projectile, origin.transform.position, quaternion.identity);
    instantiatedProjectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    instantiatedProjectile.linearVelocity = direction * speed;
    cooldown = AdjustedNextfire;


  }
    
 public void UpdateAdjustedNextfire()
    {
        thisLevel = ThisShooterLevel.shooterLevel;
        AdjustedNextfire = ThisShooterLevel.ShooterStats[thisLevel].nextfire + customFireDelay;
        customDefault = AdjustedNextfire;
    }

}
