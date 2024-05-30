using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform m_slicerTransform;

    private Camera m_camera;

    // Start is called before the first frame update
    private void Awake()
    {
        m_camera = Camera.main;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePositionOnScreenInPixel = Input.mousePosition;
        var mousePositionInWorldSpace = m_camera.ScreenToWorldPoint(mousePositionOnScreenInPixel);
        mousePositionInWorldSpace.z = 0;
        m_slicerTransform.position = mousePositionInWorldSpace;
    }
}
