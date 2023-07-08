using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] IHealthBar _health;

    private void Awake()
    {
        _health = GetComponentInParent<IHealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade blade = collision.gameObject.GetComponent<Blade>();
        Arrow arrow = collision.gameObject.GetComponent<Arrow>();

        if(arrow || blade)
        {
            _health.SetHealth(5);
        }
    }
}
