using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float Health ;
    public float Speed;
    public float ExpYield;
    public float attack;

    public float UltChargeYield = 10;
    public float adjustedHP;

    public void setstats()
    {
        setbaseStats();
        Health += Health * (Timer.instance.getTimePassed() / 60);
        ExpYield += ExpYield * (Timer.instance.getTimePassed() / 60);
        attack += attack * (Timer.instance.getTimePassed() / 60);
    }

    public void setbaseStats()
    {
        Health = 10;
        Speed = 4.5f;
        ExpYield = 10;
        attack = 10f;
    }
}
