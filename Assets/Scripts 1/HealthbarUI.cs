using UnityEngine;

public class HealthbarUI : MonoBehaviour
{
    public float width, height;
    private float maxhealth;

    void Start()
    {
         width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
    }

    [SerializeField] private RectTransform BarSize;

    public void SetMaxHealth(float Maxhealth)
    {
        maxhealth = Maxhealth;
    }

    public void SetHealthBarSize(float currentHealth)
    {
        float newWidth = currentHealth / maxhealth * width;
        BarSize.sizeDelta = new Vector2(newWidth, height);
    }
}
