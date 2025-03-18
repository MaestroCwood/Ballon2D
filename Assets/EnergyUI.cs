using UnityEngine;

using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void UpdateFillAmount(float value)
    {
        image.fillAmount = value;
    }

    public void SetColor(Color color)
    {
        image.color = new Color(color.r, color.g, color.b, 100f /255); 
        
      
    }

}
