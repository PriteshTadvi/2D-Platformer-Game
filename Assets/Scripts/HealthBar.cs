using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform greenHealth;

    private float maxWidth;

    void Start()
    {
        maxWidth = greenHealth.sizeDelta.x;
    }

    public void SetHealth(int currentHealth, int maxHealth)
    {
        float healthPercent = (float)currentHealth / maxHealth;

        greenHealth.sizeDelta = new Vector2(
            maxWidth * healthPercent,
            greenHealth.sizeDelta.y
        );
    }
}