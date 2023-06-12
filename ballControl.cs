using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballControl: MonoBehaviour
{
    public float move;
    bool gravInv = false;
    float t;
    float td;

    void Start()
    {
        t = 0f;
        td = 1f;
    }

    void Update()
    {
        if (transform.position.y <= -5 || transform.position.y >= 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        t = t + 1f * Time.deltaTime;

        gameObject.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * move * .75f);
        float HorizontalMovement = Input.GetAxis("Horizontal");
       

        Vector3 keyMove = new Vector3(HorizontalMovement, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow) && gravInv == false)
        {
            transform.Translate(Vector3.up * move * Time.deltaTime * 2, Space.World);
        }
        if (Input.GetKey(KeyCode.UpArrow) && gravInv == true)
        {
            transform.Translate(Vector3.down * move * Time.deltaTime * 2, Space.World);
        }

        if (t >= td)
        {

            if (Input.GetKeyDown(KeyCode.Space) && gravInv == false)
            {
                gravInv = true;
                t = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && gravInv == true)
            {
                gravInv = false;
                t = 0;
            }
        }


        if (gravInv == true)
        {
            Physics.gravity = new Vector3(0, 40.81f, 0);
        }
        if (gravInv == false)
        {
            Physics.gravity = new Vector3(0, -40.81f, 0);
        }


        gameObject.transform.GetComponent<Rigidbody>().AddForce(keyMove * move*2);

        
    }

    void OnCollisionEnter(Collision targetObj)
    {
        if (targetObj.gameObject.tag == "Upper")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }






}