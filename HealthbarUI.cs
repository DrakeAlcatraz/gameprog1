using UnityEngine;

public class HealthbarUI : MonoBehaviour
{
    public float width, height;
    private float maxhealth;

    [SerializeField] private RectTransform BarSize;

    public void SetMaxHealth(float Maxhealth)
    {
        maxhealth = Maxhealth;
    }

    public void SetHealthBarSize(int currentHealth)
    {
        float newWidth = ((float)currentHealth / maxhealth) * width;
        BarSize.sizeDelta = new Vector2(newWidth, height);
    }
}
