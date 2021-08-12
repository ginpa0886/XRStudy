using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Text m_BulletCount;
    [SerializeField] Image m_ReloadCenter;
    public int m_totalBullet;

    public int m_curBullet;
    Animator m_animator;

    [Header("== Camera ==")]
    CameraController m_mainCamera;

    void Awake()
    {
        m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        m_animator = GetComponent<Animator>();

        m_curBullet = 10;
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
        if(m_curBullet == 0) { return; }
        m_curBullet--;
        m_BulletCount.text = m_totalBullet.ToString() + " / " + m_curBullet.ToString();

        if(m_curBullet == 0)    // ���� �Ѿ��� 0�� ���
        {
            Reload();
            return;
        }

        m_animator.SetTrigger("fired");
        //bullet _bullet = Instantiate(m_bullet).GetComponent<bullet>();
        // object manager���� �Ѿ��� �ҷ��ͼ� ������
        bullet _bullet = ObjectManager.Instance.GetPoolObject("bullet").GetComponent<bullet>();
        _bullet.Fire(m_dir, m_firePos);

        

        m_mainCamera.GunRebound();
    }

    void Reload()
    {
        Debug.Log("����!");
        m_ReloadCenter.fillAmount = 0;
        m_ReloadCenter.gameObject.SetActive(true);
        StartCoroutine(reload());
    }

    IEnumerator reload()
    {
        while (m_ReloadCenter.fillAmount != 1)
        {
            yield return new WaitForEndOfFrame();
            m_ReloadCenter.fillAmount += 0.02f;
        }
        m_curBullet = 10;
        m_ReloadCenter.gameObject.SetActive(false);
    }
}
