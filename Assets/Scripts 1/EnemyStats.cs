using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float Health = 1000;
    public float Speed;
    public float ExpYield;
    public float attack;

    public float UltChargeYield = 100;
    public float adjustedHP;

    public void Reset()
    {
        Health = 1000;
        attack = 20;
    } 
}
