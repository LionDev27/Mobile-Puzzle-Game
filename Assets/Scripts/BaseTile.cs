using UnityEngine;

public class BaseTile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _playerOnTileColor;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ChangeSpriteColor(_baseColor);
    }

    private void OnMouseEnter()
    {
        ChangeSpriteColor(_playerOnTileColor);
    }

    private void OnMouseExit()
    {
        ChangeSpriteColor(_baseColor);
    }

    private void ChangeSpriteColor(Color newColor)
    {
        _spriteRenderer.color = newColor;
    }
}
