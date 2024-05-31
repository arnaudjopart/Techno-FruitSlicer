using System.Collections;
using EzySlice;
using UnityEngine;
using UnityEngine.UIElements;

internal class FruitController : CollidableBase
{
    private bool m_allowSlice;
    [SerializeField] private int m_score=1;
    public Material m_defaultMaterial;

    public void SetupHull(GameObject _hull)
    {
        var lowerCollider = _hull.AddComponent<MeshCollider>();
        lowerCollider.enabled = true;
        lowerCollider.convex = true;
        var rigidBody = _hull.AddComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.AddExplosionForce(300,rigidBody.position,5,0f);
        _hull.layer = 6;
        rigidBody.AddTorque(new Vector3(0,10,1));
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        var script = _hull.AddComponent<FruitController>();
        script.m_container = m_container;
        script.m_defaultMaterial = m_defaultMaterial;
        script.m_gameManager = m_gameManager;
        _hull.transform.parent = m_container;

    }
    
    public override void Slice(Vector3 _position, Vector3 _normal)
    {
        base.Slice(_position, _normal);

        m_gameManager.AddScore(m_score);

        var gameObjectToBeSlice = gameObject;
        var sliceHullData = gameObjectToBeSlice.Slice(_position, _normal);

        GameObject lowerHull = sliceHullData.CreateLowerHull(gameObjectToBeSlice,m_defaultMaterial);
        GameObject upperHull = sliceHullData.CreateUpperHull(gameObjectToBeSlice,m_defaultMaterial);
            
        SetupHull(lowerHull);
        SetupHull(upperHull);
        
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (transform.position.y < -30)
        {
            gameObject.SetActive(false);
        }
    }

    public override void SaySomething()
    {
        //base.SaySomething();
        Debug.Log("I'm a Fruit");
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.2f);
        m_allowSlice = true;
    }

    public override bool AllowsSlice()
    {
        return m_allowSlice;
    }
}
