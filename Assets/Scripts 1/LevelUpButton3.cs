using UnityEngine;
using TMPro;
public class LevelUpbutton3 : MonoBehaviour
{
   public TMP_Text Description;

    private Weapons ultimate;

    public PlayerStats player;
    public void ActivateButton(Weapons Overdrive)
    {
        Description.text = Overdrive.overdriveStats[Overdrive.ultimateLvl].description;
        ultimate = Overdrive;
    }
public void SelectedUpgrade()
{
    if (ultimate.ultimateLvl < ultimate.overdriveStats.Count - 1)
    {
        ultimate.UltimateLevelUp();
    }

    gameObject.SetActive(false);
    PanelController.instance.closeLevelUpPanel();
}

}
