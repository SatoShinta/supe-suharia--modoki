using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
        }
    }
}
