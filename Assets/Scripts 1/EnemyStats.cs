using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float Health = 100;
    public float Speed;
    public float ExpYield;

    public float UltChargeYield = 100;

    public void Reset()
    {
        Health = 100;
    } 
}
