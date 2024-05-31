using UnityEngine;

public class BombController : CollidableBase
{
    [SerializeField] private int m_damage;

    public override void Slice(Vector3 _position, Vector3 _normalVector)
    {
        base.Slice(_position, _normalVector);
        m_gameManager.TakeDamage(m_damage);
        gameObject.SetActive(false);
    }

    public override bool AllowsSlice()
    {
        return true;
    }
}