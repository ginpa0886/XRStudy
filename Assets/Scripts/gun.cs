using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [Header("== Aim Parameter ==")]
    [SerializeField] Transform m_firePos;            // �Ѿ� ���� ����
    [SerializeField] Transform m_backPos;
    public Vector3 m_targetVector;  // ������ ���� Vector3
    Vector3 m_dir;
    public float m_rayDistance;

    [Header("== Bullet ==")]
    public GameObject m_bullet;
    Animator m_animator;

    [Header("== Camera ==")]
    CameraController m_mainCamera;

    void Awake()
    {
        m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_dir = m_firePos.position - m_backPos.position;
        //Vector3.forward * 10 + m_targetVector
        Debug.DrawRay(m_backPos.position, m_dir * 10, Color.green);        
    }

    public void Fire()  // �Ѿ� ���� �� �߻� �Լ�
    {
        bullet _bullet = Instantiate(m_bullet).GetComponent<bullet>();
        _bullet.Fire(m_dir, m_firePos);

        m_mainCamera.GunRebound();
    }
}
