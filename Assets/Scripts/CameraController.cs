using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float m_boundPower;

    public float _recoverRate;
    float _rotationX;
    Quaternion m_curPos;
    public void GunRebound()    // 총기 반동 함수
    {
        StopCoroutine(coroutineRecover());
        m_curPos = transform.rotation;
        
        transform.Rotate(Vector3.left * m_boundPower);
        //_rotationX = Vector3.left.x * m_boundPower;
        RecoverBound();
    }   

    void RecoverBound()         // 총기 반동 커버 함수
    {
        StartCoroutine(coroutineRecover());
    }

    IEnumerator coroutineRecover()
    {
        while (transform.rotation.x < m_curPos.x)
        {
            yield return new WaitForSeconds(0.1f);
            _rotationX = Vector3.right.x * _recoverRate;
            transform.Rotate(_rotationX, 0, 0);
        }
    }
}
