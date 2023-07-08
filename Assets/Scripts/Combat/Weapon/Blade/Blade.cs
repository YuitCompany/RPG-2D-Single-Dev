using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] ActiveWeapon _weapon_pos;
    [SerializeField] Transform _slash_spawm_pos;
    [SerializeField] Animator _blade_anim;
    [SerializeField] GameObject _slash_perfabs;
    
    InputControls _input_controls;
    FollowMouse _follow;
    GameObject _slash;

    public bool IsAttack { get { return _is_attack; } }
    bool _is_attack;

    private void Awake()
    {
        _weapon_pos = GetComponentInParent<ActiveWeapon>();
        _blade_anim = GetComponentInParent<Animator>();
        _follow = GetComponentInParent<FollowMouse>();
        _input_controls = new InputControls();
    }

    private void Start()
    {
        _input_controls.Combat.Attack.started += _ => Attack();
    }

    private void Update()
    {
        BladeFollowPos();
    }

    private void OnEnable()
    {
        _input_controls.Enable();
    }

    private void BladeFollowPos()
    {
        if(_follow.IsFacingLeft)
        {
            _weapon_pos.transform.rotation = Quaternion.Euler(0, 180, 0);
            return;
        }

        _weapon_pos.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Attack()
    {
        _is_attack = true;
        _blade_anim.SetTrigger("Attack");
    }

    public void SpawmSlashEvent()
    {
        _slash = Instantiate(_slash_perfabs, _slash_spawm_pos.position, _slash_spawm_pos.rotation, _slash_spawm_pos);
    }

    public void Start_AttackEvent()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
    public void Stop_AttackEvent()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void FlipUp_SlashAnimEvent()
    {
        if(_follow.IsFacingLeft && _slash != null)
            _slash.GetComponent<SpriteRenderer>().flipX = true;

        _slash_spawm_pos.transform.rotation = Quaternion.Euler(180, 0, 0);
    }
    public void FlipDown_SlashAnimEvent()
    {
        if (_follow.IsFacingLeft && _slash != null)
            _slash.GetComponent<SpriteRenderer>().flipX = true;

        _slash_spawm_pos.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
