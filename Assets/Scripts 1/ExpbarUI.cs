using UnityEngine;

public class ExpbarUI: MonoBehaviour
{
    public float width, height;
    private int xptonextLVL;

    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        height= GetComponent<RectTransform>().rect.height;
    }

    [SerializeField] private RectTransform BarSize;

    public void SetXPtonextLVl(int XPtonextLVL)
    {
        xptonextLVL = XPtonextLVL;
    }

    public void SetXPBarSize(int xp)
    {
        float ratio = (float)xp / xptonextLVL;
          ratio = Mathf.Clamp01(ratio);

                float newWidth = ratio * width;
        BarSize.sizeDelta = new Vector2(newWidth, height);
    }
}
