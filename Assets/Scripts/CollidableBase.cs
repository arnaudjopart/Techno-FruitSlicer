using UnityEngine;

public class CollidableBase : MonoBehaviour
{
    public Transform m_container;
    public GameManager m_gameManager;

    public virtual bool AllowsSlice() {
        return false;
    }

    public virtual void Slice(Vector3 _position, Vector3 _normalVector)
    {
        Debug.Log("Slicing");
    }

    public virtual void SaySomething()
    {
        Debug.Log("Hello, I'm a CollidableBase");
    }
}