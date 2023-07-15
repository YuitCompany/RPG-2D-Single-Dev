using Property;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    InputControls _input_controls;

    [Header("Connect Scrpit")]
    [SerializeField] Movement movement;
    [SerializeField] FollowMouse follow;

    [Header("Movement Status")]
    [SerializeField] Vector2 _direction;

    [Header("Weapon Slot")]
    [SerializeField] List<GameObject> _list_slot = new List<GameObject>();
    [SerializeField] int _cur_slot;

    private void Awake()
    {
        _input_controls = new InputControls();

        movement = GetComponentInParent<Movement>();
        follow = GetComponentInParent<FollowMouse>();
    }

    private void Start()
    {
        _input_controls.Inventory.SwapWeapon.performed += slot => ActiveWeaponSlot((int)slot.ReadValue<float>() -1);
    }

    private void Update()
    {
        _direction = _input_controls.Movement.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movement.PlayerMove(_direction, Character.Instance.Get_CurrentProperty(EProperty.Move_Speed));
        follow.FollowMousePos();
    }

    private void OnEnable()
    {
        _input_controls.Enable();
    }

    private void ActiveWeaponSlot(int index)
    {
        if (index >= _list_slot.Count) return;

        foreach(GameObject slot in _list_slot)
        {
            slot.SetActive(false);
        }
        _list_slot[index].SetActive(true);
        _cur_slot = index;
    }
}
