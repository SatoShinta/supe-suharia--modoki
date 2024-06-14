using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.LogWarning("‹…‚ª“–‚½‚è‚Ü‚µ‚½");
            counter++;
        }

        if (counter >= 4)
        {
            Destroy(gameObject);
        }
    }
}
