using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    Transform m_camer;
    Animator m_ani;

    public float m_distance;
    public float m_down_distance;

    void Awake()
    {
        m_camer = GameObject.Find("AR Session Origin").transform;
        transform.position = m_camer.position + Vector3.forward * m_distance + Vector3.down * m_down_distance;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
