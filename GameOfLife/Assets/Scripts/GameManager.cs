using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int gridWidth = 10;
    int gridHeight = 10;

    float cellDimension = 3.3f;
    float cellSpacing = 0.2f;

    public CellScript[,] grid;

    float generationRate = 1f;
    float generationTimer = 0f;

    int time = 0;
    bool nextAlive = false;

    // Start is called before the first frame update
    void Start()
    {

        grid = new CellScript[gridWidth, gridHeight];

        for (int x=0; x < gridWidth; x++){
            for (int y = 0; y < gridHeight; y++){

                GameObject cellObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                CellScript cs = cellObj.AddComponent<CellScript>();

                cs.x = x;
                cs.y = y;
                cs.alive = (Random.value > 0.5f) ? true : false;
                cs.updateColor();
                grid[x, y] = cs;
         
                
                cellObj.AddComponent<CellScript>();

                Vector3 pos = new Vector3(x * (cellDimension + cellSpacing),0, y * (cellDimension + cellSpacing));
                cellObj.transform.position = pos;
                cellObj.transform.localScale = new Vector3(cellDimension, cellDimension, cellDimension);
                    
            }

        }

        generationTimer = generationRate;

    }

    // Update is called once per frame
    private void Update()
    {

        generationTimer -= Time.deltaTime;
        if (generationTimer < 0)
        {
            //generate new state
            generate();

            //reset the timer
            generationTimer = generationRate;

        }
        
    }

    void generate()
    {
        time++;

        for (int x = 0; x<gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                List<CellScript> neighbors = gatherLiveNeighbors(x, y);
                if (grid[x,y].alive && gatherLiveNeighbors.Count < 2)
                {
                    grid
                }
            }
        }
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y].alive = grid[x, y].nextAlive;
            }
        }
    }
    List<CellScript> gatherLiveNeighbors(int x,int y)
    {

        List<CellScript> neighbors = new List<CellScript>();

        for (int i = Mathf.Max(0, x - 1); i < Mathf.Min(gridWidth - 1, x + 1); i++)
        {
            for (int j = Mathf.Max(0, y - 1); j < Mathf.Min(gridWidth - 1, y + 1); j++)
            {
                if (grid[i, j].alive)
                {
                    neighbors.Add(grid[i, j]);
                }
            }
        }
        return neighbors;
    }
}
