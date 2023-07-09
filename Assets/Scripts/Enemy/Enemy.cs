using UnityEngine;

public class Enemy : MonoBehaviour, IHealthBar
{
    [SerializeField] float _health;
    [SerializeField] float _health_Max;

    public float Get_HealthPoint()
    {
        return _health;
    }
    public float Get_HealthPointMax()
    {
        return _health_Max;
    }

    public void Set_TakeDamage(float value)
    {
        _health -= value;
    }
    public void Set_TakeHeal(float value)
    {
        _health += value;
    }
}
