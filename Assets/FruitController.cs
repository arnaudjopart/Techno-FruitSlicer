using System;
using System.Collections;
using UnityEngine;

internal class FruitController : MonoBehaviour, ISliceable
{
    public bool AllowsSlice { get; private set; }
    public Transform m_countainer;
    public void SetupLowerHull(GameObject lowerHull)
    {
        var lowerCollider = lowerHull.AddComponent<MeshCollider>();
        lowerCollider.enabled = true;
        lowerCollider.convex = true;
        var rigidBody = lowerHull.AddComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.AddExplosionForce(300,rigidBody.position,5,0f);
        lowerHull.layer = 6;
        rigidBody.AddTorque(new Vector3(0,10,1));
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        var script = lowerHull.AddComponent<FruitController>();
        script.m_countainer = m_countainer;
        lowerHull.transform.parent = m_countainer;
    }

    public void SetupUpperHull(GameObject lowerHull)
    {
        var lowerCollider = lowerHull.AddComponent<MeshCollider>();
        lowerCollider.enabled = true;
        lowerCollider.convex = true;
        var rigidBody = lowerHull.AddComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.AddExplosionForce(300,rigidBody.position,5,0);
        lowerHull.layer = 6;
        rigidBody.AddTorque(new Vector3(0,10,1));
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        var script = lowerHull.AddComponent<FruitController>();
        script.m_countainer = m_countainer;
        lowerHull.transform.parent = m_countainer;
    }

    public void Finish()
    {
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

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.2f);
        AllowsSlice = true;
    }
}

internal interface ISliceable
{
    bool AllowsSlice { get; }
    void SetupLowerHull(GameObject lowerHull);
    void SetupUpperHull(GameObject lowerHull);
    void Finish();
}