using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Image[] potionImages;
    private void OnEnable()
    {
        PlayerHealth.healthChanged += OnHealthChanged;
        OnHealthChanged(PlayerHealth.GetHealth());
    }

    private void OnDisable()
    {
        PlayerHealth.healthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        for (int i = 0; i < potionImages.Length; i++)
        {

        }
    }

}
