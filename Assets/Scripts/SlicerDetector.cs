using System;
using System.Collections;
using EzySlice;
using UnityEngine;


public class SlicerDetector : MonoBehaviour
{
    private Vector3 m_previousPosition;
    private Vector3 m_normalVector;
    [SerializeField] private Material m_defaultMaterial;
    private bool m_isSlicing;
    [SerializeField] private GameObject m_slashSVFXPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            m_previousPosition = transform.position;
            yield return new WaitForSeconds(.05f);
            
            var currentPosition = transform.position; 
            var moveDirection = Vector3.Normalize(currentPosition - m_previousPosition);
            m_normalVector = Vector3.Cross(Vector3.back, moveDirection);
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(transform.position,transform.position+m_normalVector*10);
    }

    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("OnTriggerEnter");
        var gameObjectToBeSlice = _other.gameObject;
        var slicable = gameObjectToBeSlice.GetComponent<ISliceable>();
        
        if (slicable == null) return;
        if (slicable.AllowsSlice == false) return;
        try
        {
            slicable.Slice(transform.position,m_normalVector);
            

            slicable.Finish();
            var slash = Instantiate(m_slashSVFXPrefab, transform.position, Quaternion.identity);

        }
        catch (Exception _e)
        {
            Debug.LogWarning(_e.Message);
        }
    }
    
}