using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerHealth
{
    public static event Action<int> healthChanged;
    private static int _health = 5;

    public static int GetHealth()
    {
        return _health;
    }

    public static void SetHealth(int health)
    {
        if (_health == health)
        {
            return;
        }
        _health = health;
        healthChanged?.Invoke(health);
    }

    public static void Damage()
    {
        SetHealth(_health - 1);
    }
}
