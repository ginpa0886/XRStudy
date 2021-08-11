using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    Rigidbody rigid;
    public float _speed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    public void Fire(Vector3 dir, Transform trans)
    {
        transform.position = trans.position;
        rigid.AddForce(dir * _speed, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("enemy hit!");
            Destroy(this.gameObject);
        }
    }
}
