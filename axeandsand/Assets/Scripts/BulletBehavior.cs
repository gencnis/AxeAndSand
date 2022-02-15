using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float onscreenDelay = 1f;

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
