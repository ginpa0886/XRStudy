using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public static ObjectManager Instance = null;

    public GameObject[] m_bulletPool;

    public GameObject m_bulletPrefab;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_bulletPool = new GameObject[100];

        for(int i= 0; i < m_bulletPool.Length; i++) // bullet 오브젝트 풀 생성
        {
            m_bulletPool[i] = Instantiate(m_bulletPrefab, transform);
            m_bulletPool[i].SetActive(false);
        }
    }

    public GameObject GetPoolObject(string obj)
    {
        GameObject m_obj = null;
        switch (obj)
        {
            case "bullet":
                for(int i = 0; i < m_bulletPool.Length; i++)
                {
                    if (!m_bulletPool[i].activeSelf)
                    {
                        m_bulletPool[i].SetActive(true);
                        m_obj = m_bulletPool[i];
                        break;
                    }                        
                }
                break;
        }

        return m_obj;
    }
}
