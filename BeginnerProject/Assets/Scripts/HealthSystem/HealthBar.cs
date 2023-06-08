using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillerHealthBar;
    [SerializeField] private Text _textValueHealhtBar;
    [SerializeField] private PlayerHealth _playerHealth;
    private const float _rate = 100f;

    public void SetValue(int value)
    {
        _fillerHealthBar.fillAmount = value/_rate;
        _textValueHealhtBar.text = $"{value} ";
    }

    private void OnEnable()
    {
        _playerHealth.OnHealthChanged += SetValue;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= SetValue;
    }
}
