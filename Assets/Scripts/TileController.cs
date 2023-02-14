using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
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
                //Ajustamos la posición teniendo en cuenta el tamaño de la celda.
                pos = new Vector3(pos.x + (_pathMap.cellSize.x / 2f), pos.y + (_pathMap.cellSize.y / 2f), pos.z);

                //Si modificamos la escala del Grid de alguna manera, no funciona. Hay que ver como arreglarlo.
                #region GridScale

                // //Obtenemos el tamaño de las celdas en el Grid.
                // Vector2 cellSize = _pathMap.layoutGrid.cellSize;
                // //Si ha cambiado el tamaño de las celdas, ajustamos la posición.
                // if (cellSize != Vector2.one)
                // {
                //     // pos = new Vector3(pos.x - cellSize.x, pos.y - cellSize.y, pos.z);
                // }

                #endregion
                
                //Instanciamos nuestro propio tile de funcionamiento. Se puede cambiar a Object Pooling.
                GameObject tempTile = Instantiate(_tilePrefab, pos, quaternion.identity);
                //Cambiamos la escala del tile propio a la del Grid para que tenga el mismo tamaño.
                tempTile.transform.localScale = _pathMap.layoutGrid.cellSize;
            }
        }
        
        //Destruimos el tilemap.
    }
}
