using Unity.Mathematics;

using UnityEngine;

public class ShooterTiming : Playershoot
{
    public float customFireRate = 1.5f;

    public override void ShootLogic()
    {
        if (nextfire <= 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - transform.position;
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            instantiatedProjectile = Instantiate(Projectile, origin.transform.position, quaternion.identity);
            instantiatedProjectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            instantiatedProjectile.linearVelocity = direction * speed;

            nextfire = customFireRate;
        }
        else
        {
            nextfire -= Time.deltaTime;
        }
    }
}
