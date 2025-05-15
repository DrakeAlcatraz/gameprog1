using NUnit.Framework;
using UnityEngine;

public class ShooterCheck : PlayerStats

{
    PlayerStats playerLevel= new PlayerStats();
    [SerializeField] public int requiredLvl;

    public void ShooterLevelReq(){
       if(playerLevel.level<requiredLvl){
        gameObject.SetActive(false);
       }else if(playerLevel.level >= requiredLvl){
        gameObject.SetActive(true);
       }
    }
  
   

}



