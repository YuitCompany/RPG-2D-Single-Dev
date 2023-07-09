using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Rigidbody2D _arrow;
    [SerializeField] Animator _arrow_anim;

    bool _isFall = false;
    float _fly_time = .5f;
    float _alive_time = 5f;

    public float Damage { get { return _damage; } set { _damage = value; } }
    float _damage;
    public float Angle { get { return _fly_angle; } set { _fly_angle = value; } }
    float _fly_angle;

    private void Awake()
    {
        _arrow = GetComponentInParent<Rigidbody2D>();
        _arrow_anim = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(ArrowFlyingRoutine(_fly_time));
    }

    private IEnumerator ArrowFlyingRoutine(float flyTime)
    {
        // Before Load Time Code
        transform.rotation = Quaternion.Euler(0, 0, Angle - 45);

        while (flyTime >= 0)
        {
            flyTime -= Time.deltaTime;
            // While Load Time Code
            if (_isFall) break;
            yield return null;
        }
        // After Load Time Code
        StartCoroutine(ArrowFallingRoutine(_alive_time));
    }

    private IEnumerator ArrowFallingRoutine(float aliveTime)
    {
        // Before Delay Time Code
        ArrowFallenEvent();
        _arrow_anim.SetTrigger("Collision");

        yield return new WaitForSeconds(aliveTime);
        // After Delay Time Code
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy)
        {
            StartCoroutine(ArrowFallingRoutine(_alive_time));
        }
    }

    public void ArrowFallenEvent()
    {
        _isFall = true;
        _arrow.isKinematic = true;
        _arrow.velocity = Vector3.zero;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
