using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour, IMovementDirectionGenerator
{
    [SerializeField] private Vector3 m_spawnDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GenerateDirectionVector()
    {
        throw new System.NotImplementedException();
    }
}

public interface IMovementDirectionGenerator
{
    Vector3 GenerateDirectionVector();
}
