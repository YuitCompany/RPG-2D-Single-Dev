using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _player;
    [SerializeField] Animator _move_anim;

    private void Awake()
    {
        _player = GetComponentInParent<Rigidbody2D>();
        _move_anim = GetComponentInParent<Animator>();
    }

    public void PlayerMove(Vector2 direction, float speed)
    {
        _player.MovePosition(_player.position + direction * speed * Time.fixedDeltaTime);

        _move_anim.SetFloat("MoveX", direction.x);
        _move_anim.SetFloat("MoveY", direction.y);
    }
}
