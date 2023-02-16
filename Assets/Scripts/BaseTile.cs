using UnityEngine;

public class BaseTile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _playerOnTileColor, _playerOutsideColor;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerExit();
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

    protected virtual void OnPlayerExit()
    {
        ChangeSpriteColor(_playerOutsideColor);
    }
}
