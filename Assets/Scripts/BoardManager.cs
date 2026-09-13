using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class BoardManager : MonoBehaviour
{

    public class CellData
    {
        public bool Passable;
        public CellObject ContainedObject;
    }


    private CellData[,] m_BoardData;
    private Tilemap m_Tilemap;
    private Grid m_Grid;
    private List<Vector2Int> m_EmptyCellsList;



    public int Width;
    public int Height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;
    public PlayerController Player;
    public FoodObject FoodPrefab;
    public WallObject WallPrefab;




    // Start is called before the first frame update
    public void Init()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();
        m_Grid = GetComponentInChildren<Grid>();
        // Initialize the list
        m_EmptyCellsList = new List<Vector2Int>();

        m_BoardData = new CellData[Width, Height];

        for (int y = 0; y < Height; ++y)
        {
            for (int x = 0; x < Width; ++x)
            {
                Tile tile;
                m_BoardData[x, y] = new CellData();

                if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    m_BoardData[x, y].Passable = false;
                }
                else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                    m_BoardData[x, y].Passable = true;
                    m_EmptyCellsList.Add(new Vector2Int(x, y)); // Add to empty cells list
                }

                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
        //remove the starting point of the player! It's not empty, the player is there
        m_EmptyCellsList.Remove(new Vector2Int(1, 1));
        GenerateFood();
        GenerateWall();
    }

    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x >= Width || cellIndex.y < 0 || cellIndex.y >= Height)
        {
            return null;
        }
        return m_BoardData[cellIndex.x, cellIndex.y];
    }

    public void setCelltile(Vector2Int cellIndex, Tile tile)
    {
        m_Tilemap.SetTile(new Vector3Int(cellIndex.x, cellIndex.y, 0), tile);
    }

    void GenerateFood()
    {
        int foodCount = 5;
        for (int i = 0; i < foodCount; i++)
        {
            int randomIndex = Random.Range(0, m_EmptyCellsList.Count);
            Vector2Int coord = m_EmptyCellsList[randomIndex];

            m_EmptyCellsList.RemoveAt(randomIndex); // Remove the cell from the list to avoid placing food there again
            CellData data = m_BoardData[coord.x, coord.y];
            FoodObject newFood = Instantiate(FoodPrefab);

            newFood.transform.position = CellToWorld(coord);

            data.ContainedObject = newFood;
        }
    }
    void GenerateWall()
    {
        int wallCount = Random.Range(6, 10);
        for (int i = 0; i < wallCount; i++)
        {
            int randomIndex = Random.Range(0, m_EmptyCellsList.Count);
            Vector2Int coord = m_EmptyCellsList[randomIndex];

            m_EmptyCellsList.RemoveAt(randomIndex); 
            CellData data = m_BoardData[coord.x, coord.y];
            WallObject newWall = Instantiate(WallPrefab);

            //init the wall
            newWall.Init(coord);

            newWall.transform.position = CellToWorld(coord);

            data.ContainedObject = newWall;
            data.Passable = false; // Mark the cell as not passable since it now contains a wall
        }
    }

}