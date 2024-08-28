using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    [SerializeField] Slider healthSlider;

    private void Awake()
    {
        instance = this;
    }

    public void Repaint(int health, int maxHealth)
    {
        // Set the slider's value based on the current health
        healthSlider.value = (float)health / maxHealth;
    }
}
