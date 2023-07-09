

public interface IHealthBar
{
    public float Get_HealthPoint();
    public float Get_HealthPointMax();
    public void Set_TakeDamage(float value);
    public void Set_TakeHeal(float value);
}