using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    public int _speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 15, 30) * Time.deltaTime * _speed);
    }

    public void SpeedUp()
    {
        _speed++;
    }
}
