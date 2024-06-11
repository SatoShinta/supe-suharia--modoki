using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -30)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.LogWarning("����������܂���");
            counter++;
        }

        if (counter >= 3)
        {
            Destroy(gameObject);
        }
    }
}
