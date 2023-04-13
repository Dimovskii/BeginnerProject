using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider _healtSlider;

   public void SetMaxHealth(int health)
   {
        _healtSlider.maxValue = health;
        _healtSlider.value = health;
   }

   public void SetHelthAmount(int health)
   {
        _healtSlider.value = health;
   }
}
