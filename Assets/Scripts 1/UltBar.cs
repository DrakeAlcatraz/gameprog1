
using UnityEngine;

public class UltBar: MonoBehaviour
{
    private float ULTtoCharge;
    public float width, height;
    public RectTransform Barsize;

    void Awake()
    {
        Barsize = GetComponent<RectTransform>();
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
    }

   public void SetUltCharge(float Ulttocharge)
    {
       
        ULTtoCharge = Ulttocharge;
    }

   public void SetUltBarsize(float ultcharge)
    {
        
        float ratio = ultcharge / ULTtoCharge;
        ratio = Mathf.Clamp01(ratio);

        float newWidth = ratio * width;
        Barsize.sizeDelta = new Vector2(newWidth, height);
    }
}
