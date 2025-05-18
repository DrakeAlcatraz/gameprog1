using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float Maxhealth = 100;
    public float currentHealth;
    public float attack = 10;

    public int level = 1;
    public float xp = 0;
    public float xpToNextLevel = 100;
    public float damagetaken = 20;

    public int speed = 5;
    public float UltCharge = 0f;
    public float UltChargeMax = 200f;
    public float UltDuration = 5f;
    public float Ultatkspeedchange = 0.5f;

    public void ResetStats()

    {
        Maxhealth = 100;
        attack = 10;
        level = 1;
        xp = 0;
        xpToNextLevel = 100;
        damagetaken = 20;
        speed = 5;
        currentHealth = Maxhealth;
        UltCharge = 0;
        UltChargeMax = 200f;
        UltDuration = 5f;
        Ultatkspeedchange = 0.5f;
    }

    public float passiveUltGain()
    {
        float UltPerSec=UltChargeMax/120;
          
        return UltPerSec;
    }

}


