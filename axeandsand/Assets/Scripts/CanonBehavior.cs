using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehavior : MonoBehaviour
{
    public GameObject projectile;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 90);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 90);
        }
    }
}