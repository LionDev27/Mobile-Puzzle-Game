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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnter();
        }
    }

    private void ChangeSpriteColor(Color newColor)
    {
        _spriteRenderer.color = newColor;
    }

    protected virtual void OnPlayerEnter()
    {
        ChangeSpriteColor(_playerOnTileColor);
    }
}
