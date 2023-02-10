using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    private Tilemap _pathMap;

    private void Awake()
    {
        _pathMap = GetComponent<Tilemap>();
    }

    private void OnMouseEnter()
    {
        Vector3 mousePos = Input.mousePosition;
        TileBase tile = _pathMap.GetTile(Vector3Int.FloorToInt(mousePos));
    }
}
