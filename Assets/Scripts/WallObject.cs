using UnityEngine;
using UnityEngine.Tilemaps;

public class WallObject : CellObject
{
    public Tile ObstacleTile;
    public int MaxHealth = 3;

    private int m_HealthPoint;
    private Tile m_OriginalTile;

    public override void Init(Vector2Int cell)
    {
        base.Init(cell);
        m_HealthPoint = MaxHealth;
        m_OriginalTile = GameManager.Instance.BoardManager.getCellTile(cell);
        GameManager.Instance.BoardManager.setCelltile(cell, ObstacleTile);
    }

    public override bool PlayerWantsToEnter()
    {
        m_HealthPoint -= 1;

        if(m_HealthPoint > 0)
        {
            return false;
        }
        GameManager.Instance.BoardManager.setCelltile(m_cell, m_OriginalTile);
        Destroy(gameObject);
        return true;
    }
}
