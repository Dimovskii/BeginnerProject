using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillerHealthBar;
    [SerializeField] private Text _textValueHealhtBar;
    private const float _rate = 100f;
    private IPlayerHealth _playerHealth;

    public void Init(IPlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
        Subscribe();
    }
    private void Subscribe()
    {
        _playerHealth.OnHealthChanged += SetValue;
    }

    public void SetValue(int value)
    {
        _fillerHealthBar.fillAmount = value/_rate;
        _textValueHealhtBar.text = $"{value} ";
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= SetValue;
    }
}
