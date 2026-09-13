using UnityEngine;

public class CellObject : MonoBehaviour
{
    protected Vector2Int m_cell;
    public virtual void Init(Vector2Int cell)
    {
        m_cell = cell;
    }

    public virtual bool PlayerWantsToEnter()
    {
        return true;
    }

    public virtual void PlayerEntered()
    {

    }
}
