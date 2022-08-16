using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunctionCollapse : MonoBehaviour
{
    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;

    [SerializeField] GameObject[] sprites;

    [SerializeField] List<CellGrid> cells = new();

    List<CellGrid> lowEntropyGrids = new();

    void Start()
    {
        MakeGrid();
        SortStartingPoint();
    }

    void MakeGrid()
    {
        for (int i = 0; i < gridHeight; i++)
        {
            for (int k = 0; k < gridWidth; k++)
            {
                CellGrid cg = new CellGrid(sprites, Vector2.right * k + Vector2.up * i);
                cells.Add(cg);
            }
        }
    }

    void SortStartingPoint()
    {
        int randPoint = Random.Range(0, gridWidth);
        Collapse(cells[randPoint]);
    }

    void Collapse(CellGrid cell)
    {
        int rs = Random.Range(0, cell.sprites.Count);
        Instantiate(cell.sprites[rs], cell.coordinate, Quaternion.identity);

        cell.collapsed = true;
        CalculeCellPossibilities(cell);
    }

    void CalculeCellPossibilities(CellGrid cell)
    {
        int index = cells.IndexOf(cell);
        int upperCellID = index + 1 * gridWidth;
        int downCellID = index - 1 * gridWidth;



        if (upperCellID < cells.Count)
        {
            CellGrid upCell = cells[upperCellID];
            Instantiate(upCell.sprites[0], upCell.coordinate, Quaternion.identity);
        }
            
        if (downCellID > 0)
        {   
            CellGrid downCell = cells[downCellID];
            Instantiate(downCell.sprites[0], downCell.coordinate, Quaternion.identity);
        }
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
