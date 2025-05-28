using UnityEngine;

[CreateAssetMenu(fileName = "StrongerEnemyStats", menuName = "Scriptable Objects/StrongerEnemyStats")]
public class StrongerEnemyStats : ScriptableObject
{

    public float bigHealth;
    public float bigSpeed;
    public float bigExpYield;
    public float bigattack;

    public float bigUltChargeYield = 100;
    public float bigadjustedHP;

    public void setbigStats()
    {
        setBigBaseStats();
        bigHealth += bigHealth * (Timer.instance.getTimePassed() / 60);
        bigExpYield += bigExpYield * (Timer.instance.getTimePassed() / 60);
        bigattack += bigattack * (Timer.instance.getTimePassed() / 60);
    }

    public void setBigBaseStats()
    {
        bigHealth = 70f;
        bigSpeed = 3f;
        bigExpYield = 30f;
        bigUltChargeYield = 30f;
        bigattack = 20f;

   }
   
}
