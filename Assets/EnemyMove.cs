using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")] float enemySpeed;

    float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.5)
        {
            MoveBack();
        } 
    }


    private void MoveBack()
    {
        transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
    }
}
