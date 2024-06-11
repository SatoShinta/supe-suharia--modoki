using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Header("�G�̃v���n�u")] GameObject enemy;
    [SerializeField,Header("�؂̃v���n�u")] GameObject tree;
    [SerializeField, Header("�����Ԋu")] float generateInterval;
    [SerializeField, Header("�����Ԋu2")] float generateInterval2;
    [SerializeField, Header("�؂̐����Ԋu")] float treeGenerateInterval;
    [SerializeField, Header("�����I������")] float stopTime;
    [SerializeField, Header("�؂̐����I������")] float treeStopTime;
    float num = 0;
    float num2 = 0;
    float num3 = 0;
    float elapsedTime = 0;
    bool isGenerate = true;
    bool isTreeGenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num += Time.deltaTime;
        num2 += Time.deltaTime;
        num3 += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (isTreeGenerate)
        {
            if (num3 >= treeGenerateInterval && elapsedTime >= stopTime)
            {
                TreeGenerater();
                num3 = 0;
            }
        }
       

        if (isGenerate)
        {
            if (num >= generateInterval)
            {
                EnemyGenerater1();
                num = 0;
            }

            if (num2 >= generateInterval2)
            {
                EnemyGenerater2();
                num2 = 0;
            }
        }
       
        
        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            if (elapsedTime >= treeStopTime)
            {
                isTreeGenerate = false;
            }
        }


     
    }


    void EnemyGenerater1()
    {
        Instantiate(enemy, new Vector3(5, 2, 80), Quaternion.identity);
        Instantiate(enemy, new Vector3(0, 2, 80), Quaternion.identity);
        Instantiate(enemy, new Vector3(-5, 2, 80), Quaternion.identity);
    }

    void EnemyGenerater2()
    {
        Instantiate(enemy, new Vector3(7, 4, 80), Quaternion.identity);
        Instantiate(enemy, new Vector3(0, 1, 80), Quaternion.identity);
        Instantiate(enemy, new Vector3(-7, 4, 80), Quaternion.identity);
    }

    void TreeGenerater()
    {
        Instantiate(tree, new Vector3(0, 1, 80), Quaternion.identity); ;
    }

}
