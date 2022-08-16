using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellGrid
{
    public List<GameObject> sprites;
    public readonly Vector2 coordinate;
    public bool collapsed;

    public CellGrid(GameObject[] sprites, Vector2 coordinate)
    {
        this.sprites = sprites.ToList();
        this.coordinate = coordinate;
    }

    public void RemoveOption(GameObject element)
    {
        if (!sprites.Contains(element)) return;

        sprites.Remove(element);
    }
}
