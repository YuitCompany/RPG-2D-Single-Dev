using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool IsFacingLeft { get { return _isFacingLeft; } private set { _isFacingLeft = value; } }
    bool _isFacingLeft;

    [SerializeField] SpriteRenderer _player_sprite;

    private void Awake()
    {
        _player_sprite = GetComponentInParent<SpriteRenderer>();
    }

    public void FollowMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (mousePos.x > playerPos.x)
        {
            IsFacingLeft = false;
        } else
        {
            IsFacingLeft = true;
        }

        _player_sprite.flipX = IsFacingLeft;
    }
}
