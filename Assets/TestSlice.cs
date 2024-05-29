using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine;
using Plane = EzySlice.Plane;

public class TestSlice : MonoBehaviour
{
    [SerializeField] private GameObject m_gameObjectToSlice;

    [SerializeField] private Vector3 m_planeWorldPosition;
    [SerializeField] private Vector3 m_planeWorldDirection;
    [SerializeField] private Material m_material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var sliceHull = m_gameObjectToSlice.Slice(m_planeWorldPosition, m_planeWorldDirection);
            GameObject lowerHull = sliceHull.CreateLowerHull();
            lowerHull.transform.position = m_gameObjectToSlice.transform.position;
            lowerHull.transform.rotation = m_gameObjectToSlice.transform.rotation;
            lowerHull.GetComponent<MeshRenderer>().material = m_material;

            GameObject upperHull = sliceHull.CreateUpperHull();
            
            upperHull.transform.position = m_gameObjectToSlice.transform.position;
            upperHull.transform.rotation = m_gameObjectToSlice.transform.rotation;
            
            lowerHull.GetComponent<MeshRenderer>().material = m_material;
            var lowerCollider = lowerHull.AddComponent<MeshCollider>();
            lowerCollider.sharedMesh = sliceHull.lowerHull;
            lowerCollider.convex = true;
            var rigidBody = lowerHull.AddComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            

            upperHull.GetComponent<MeshRenderer>().material = m_material;
            upperHull.AddComponent<Rigidbody>();
            var collider = upperHull.AddComponent<MeshCollider>();
            collider.sharedMesh = sliceHull.upperHull;
            collider.convex = true;
            
            m_gameObjectToSlice.SetActive(false);
            
        }
        
    }
    
    
}
