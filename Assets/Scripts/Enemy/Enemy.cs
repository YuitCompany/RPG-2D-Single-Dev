using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthBar
{
    [SerializeField] int _health;

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int health)
    {
        _health -= health;
    }
}
