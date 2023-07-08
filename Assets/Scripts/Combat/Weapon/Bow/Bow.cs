using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] ActiveWeapon _weapon_pos;
    [SerializeField] Transform _arrow_spawm_pos;
    [SerializeField] Animator _bow_anim;
    [SerializeField] GameObject _arrow_prefabs;

    bool _is_drag;
    float _bow_power;
    InputControls _input_controls;
    GameObject _arrow;

    private void Awake()
    {
        _bow_power = 500;
        _weapon_pos = GetComponentInParent<ActiveWeapon>();
        _bow_anim = GetComponentInParent<Animator>();
        _input_controls = new InputControls();
    }

    private void Start()
    {
        _input_controls.Combat.Attack.started += _ => BowDrag();
        _input_controls.Combat.Attack.canceled += _ => BowDrop();
    }

    private void FixedUpdate()
    {
        BowFollowPos();
    }

    private void OnEnable()
    {
        _input_controls.Enable();
    }

    private void BowFollowPos()
    {
        _weapon_pos.transform.rotation = Quaternion.Euler(0, 0, GetAngleMousePos());
    }

    private void BowDrag()
    {
        if (_is_drag) return;

        _is_drag = true;
        _bow_anim.SetBool("IsDrag", _is_drag);
    }

    private void BowDrop()
    {
        if (!_is_drag) return;

        _is_drag = false;
        _bow_anim.SetBool("IsDrag", _is_drag);
    }

    public void SpawmArrowEvent()
    {
        _arrow = Instantiate(_arrow_prefabs, _arrow_spawm_pos.position, _arrow_spawm_pos.rotation);
        _arrow.GetComponent<Rigidbody2D>().AddForce(_arrow_spawm_pos.transform.right * _bow_power);
        _arrow.GetComponent<Arrow>().Angle = GetAngleMousePos();
    }

    private float GetAngleMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);

        return Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x) * Mathf.Rad2Deg;
    }
}
