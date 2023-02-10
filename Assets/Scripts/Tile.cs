using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : TileBase
{
    public SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        spriteRenderer = new SpriteRenderer();
    }
}
