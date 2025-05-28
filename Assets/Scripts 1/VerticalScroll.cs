using UnityEngine;
using System.Linq;

public class VerticalScrollLoop : MonoBehaviour
{
    public float scrollSpeed = 100f;
    private RectTransform[] layers;
    private float imageHeight;

    void Start()
{
    layers = GetComponentsInChildren<RectTransform>()
                 .Where(t => t != this.GetComponent<RectTransform>())
                 .ToArray();

    imageHeight = layers.Max(l => l.sizeDelta.y);

   
    for (int i = 0; i < layers.Length; i++)
    {
        layers[i].anchoredPosition = new Vector2(0, -i * imageHeight);
    }
}

    void Update()
    {
        foreach (var layer in layers)
        {
            layer.anchoredPosition -= new Vector2(0, scrollSpeed * Time.deltaTime);

            if (layer.anchoredPosition.y <= -imageHeight)
            {
                float highestY = GetHighestY();
                layer.anchoredPosition = new Vector2(layer.anchoredPosition.x, highestY + imageHeight);
            }
        }
    }

    float GetHighestY()
    {
        return layers.Max(l => l.anchoredPosition.y);
    }
}
