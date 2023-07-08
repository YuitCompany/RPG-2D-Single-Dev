using UnityEngine;

public class Controller : MonoBehaviour
{
    InputControls _input_controls;

    [Header("Connect Scrpit")]
    [SerializeField] Movement movement;
    [SerializeField] FollowMouse follow;

    [Header("Movement Status")]
    [SerializeField] float _speed = 5;
    [SerializeField] Vector2 _direction;

    private void Awake()
    {
        _input_controls = new InputControls();

        movement = GetComponentInParent<Movement>();
        follow = GetComponentInParent<FollowMouse>();
    }


    private void Update()
    {
        _direction = _input_controls.Movement.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movement.PlayerMove(_direction, _speed);
        follow.FollowMousePos();
    }

    private void OnEnable()
    {
        _input_controls.Enable();
    }
}