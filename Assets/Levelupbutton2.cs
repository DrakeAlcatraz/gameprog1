using UnityEngine;
using TMPro;
public class Levelupbutton2 : MonoBehaviour
{
  
    public TMP_Text weaponDescription;

    private Weapons shooter;

    public void ActivateButton(Weapons ActiveShooter)
    {
        weaponDescription.text = ActiveShooter.ShooterStats[ActiveShooter.shooterLevel].weaponDescription;
        shooter = ActiveShooter;
    }

    public void SelectedUpgrade()
    {
        if (shooter.shooterLevel >= shooter.ShooterStats.Count-2)
        {
            shooter.ShooterLevelUP();
            gameObject.SetActive(false);
            PanelController.instance.closeLevelUpPanel();
        }
        else
        {
           shooter.ShooterLevelUP();
            PanelController.instance.closeLevelUpPanel();
        }
    }


}
