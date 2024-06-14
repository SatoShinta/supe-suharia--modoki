using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyDestroy2 : MonoBehaviour

{ 
 [SerializeField] public float counter;
    private float timer;

// Start is called before the first frame update
void Start()
{

}

// Update is called once per frame
void Update()
{
        timer = Time.deltaTime;
    if (transform.position.z <= -10 || timer >= 8)
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

    if (counter >= 5)
    {
        Destroy(gameObject);
    }
}
}
