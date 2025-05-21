using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  public List<Dagger> stats;
}

[System.Serializable]
public class Dagger()
{
  public float baseAttack = 2;
  public float pierceCount = 2;
  public int SkillLevel;
  
}