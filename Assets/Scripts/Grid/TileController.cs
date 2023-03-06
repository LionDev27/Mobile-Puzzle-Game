using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tileContainer;
    private Tilemap _pathMap;

    private void Awake()
    {
        _pathMap = GetComponent<Tilemap>();
    }

    private void Start()
    {
        InitializeTiles();
    }

    private void InitializeTiles()
    {
        //Obtenemos los limites del tilemap.
        BoundsInt tileBounds = _pathMap.cellBounds;

        //Obtenemos la posicion de cada celda del Grid.
        foreach (var position in tileBounds.allPositionsWithin)
        {
            //Si hay un tile en esa posicion.
            if (_pathMap.HasTile(position))
            {
                //Lo pasamos a posicion de mundo.
                Vector3 pos = _pathMap.CellToWorld(position);
                Vector3 cellSize = _pathMap.transform.localScale / 2;
                //Ajustamos la posición teniendo en cuenta el tamaño de la celda.
                pos = new Vector3(pos.x + (cellSize.x / 2f), pos.y + (cellSize.y / 2f), pos.z);

                //Instanciamos nuestro propio tile de funcionamiento. Se puede cambiar a Object Pooling.
                GameObject tempTile = Instantiate(_tilePrefab, pos, quaternion.identity, _tileContainer);
                //Cambiamos la escala del tile propio a la del Grid para que tenga el mismo tamaño.
                tempTile.transform.localScale = cellSize;
            }
        }

        //Destruimos el tilemap.
        Destroy(gameObject);
    }
}
