using UnityEngine;

public class ExpbarUI: MonoBehaviour
{
    public float width, height;
    private float xptonextLVL;
     [SerializeField] private RectTransform BarSize;


    void Awake()
    {
        BarSize = GetComponent<RectTransform>();
        width = GetComponent<RectTransform>().rect.width;
        height= GetComponent<RectTransform>().rect.height;
    }

   
    public void SetXPtonextLVl(float XPtonextLVL)
    {
   
        Debug.Log("setting EXP");
        xptonextLVL = XPtonextLVL;
    }

    public void SetXPBarSize(float xp)
    {
     
        Debug.Log("Setting Bar size");
        float ratio = (float)xp / xptonextLVL;
          ratio = Mathf.Clamp01(ratio);

                float newWidth = ratio * width;
        BarSize.sizeDelta = new Vector2(newWidth, height);
    }
}
