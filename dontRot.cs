using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontRot : MonoBehaviour
{
    public GameObject runner;
    public float farAw = 6;

    void Update()
    {
        
    }
    private void LateUpdate()
    {
        //transform.position = new Vector3(0, 10, 0);
        transform.rotation = Quaternion.identity;
        transform.position = runner.transform.position - transform.TransformDirection(Vector3.forward*farAw);
        transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        transform.LookAt(runner.transform);
    }
}
