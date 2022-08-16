using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunctionCollapse : MonoBehaviour
{
    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;
    
    [SerializeField] GameObject[] sprites;

    [SerializeField] List<CellGrid> grids = new();

    void Start()
    {
        MakeGrid();
        SortStartingPoint();
    }

    void MakeGrid()
    {
        for (int i = 0; i < gridHeight; i++)
        {
            for(int k = 0; k < gridWidth; k++)
            {
                CellGrid cg = new CellGrid(sprites, Vector2.right * k + Vector2.up * i);
                grids.Add(cg);
            }
        }
    }

    void SortStartingPoint()
    {
        int randPoint = Random.Range(0, gridWidth);
        Collapse(grids[randPoint]);
    }

    void Collapse(CellGrid gridInfo)
    {
        int rs = Random.Range(0, gridInfo.sprites.Count);
        Instantiate(gridInfo.sprites[rs], gridInfo.coordinate, Quaternion.identity);

        gridInfo.collapsed = true;
    }

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = new Color(1, 0, 0, 0.5f);
    //     for(int i = 0; i < gridHeight; i++)
    //     {
    //         for(int k = 0; k < gridWidth; k++)
    //         {
    //             Gizmos.DrawCube(Vector2.right * k + Vector2.up * i, new Vector2(1, 1));
    //         }
    //     }
    // }

}
