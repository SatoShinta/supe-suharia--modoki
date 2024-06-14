using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Header("“G‚ÌƒvƒŒƒnƒu")] GameObject enemy;
    [SerializeField, Header("’e‚ð”­ŽË‚·‚é“G‚ÌƒvƒŒƒnƒu")] GameObject enemy2;
    [SerializeField,Header("–Ø‚ÌƒvƒŒƒnƒu")] GameObject tree;
    [SerializeField, Header("¶¬ŠÔŠu")] float generateInterval;
    [SerializeField, Header("¶¬ŠÔŠu2")] float generateInterval2;
    [SerializeField, Header("¶¬ŠÔŠu3")] float generateInterval3;
    [SerializeField, Header("–Ø‚Ì¶¬ŠÔŠu")] float treeGenerateInterval;
    [SerializeField, Header("¶¬I—¹ŽžŠÔ")] float stopTime;
    [SerializeField, Header("¶¬I—¹ŽžŠÔ")] float stopTime2;
    [SerializeField, Header("–Ø‚Ì¶¬I—¹ŽžŠÔ")] float treeStopTime;

    float numEnemy1 = 0;
    float numEnemy12 = 0;
    float numTree = 0;
    float numEnemy2 = 0;
    float elapsedTime = 0;

    bool isGenerate = true;
    bool isGenerate2 = true;
    bool isTreeGenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numEnemy1 += Time.deltaTime;
        numEnemy12 += Time.deltaTime;
        numTree += Time.deltaTime;
        numEnemy2 += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (isTreeGenerate)
        {
            if (numTree >= treeGenerateInterval && elapsedTime >= stopTime)
            {
                TreeGenerater();
                numTree = 0;
            }
        }
       

        if (isGenerate)
        {
            if (numEnemy1 >= generateInterval)
            {
                EnemyGenerater1();
                numEnemy1 = 0;
            }

            if (numEnemy12 >= generateInterval2)
            {
                EnemyGenerater2();
                numEnemy12 = 0;
            }
        }

        if (isGenerate2 == true)
            if(numEnemy2 >= generateInterval3 && elapsedTime >= treeStopTime + 2)
        {
            EnemyGenerater3();
            numEnemy2 = 0;
        }
       
        
        if (elapsedTime >= stopTime)
        {
            isGenerate = false;
            if (elapsedTime >= treeStopTime)
            {
                isTreeGenerate = false;
            }
            if(elapsedTime >= stopTime2)
            {
                isGenerate2 = false;
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
        Instantiate(enemy, new Vector3(0, 5, 80), Quaternion.identity);
        Instantiate(enemy, new Vector3(-7, 4, 80), Quaternion.identity);
    }

    void EnemyGenerater3()
    {
        Instantiate(enemy2, new Vector3(-7, 8, 8), Quaternion.identity);
        Instantiate(enemy2, new Vector3(0, 8, 8), Quaternion.identity);
        Instantiate(enemy2, new Vector3(7, 8, 8), Quaternion.identity);
        Instantiate(enemy2, new Vector3(5, 6, 6), Quaternion.identity);
        Instantiate(enemy2, new Vector3(2, 6, 6), Quaternion.identity);
        Instantiate(enemy2, new Vector3(-5, 6, 6), Quaternion.identity);
        Instantiate(enemy2, new Vector3(2, 4, 4), Quaternion.identity);
        Instantiate(enemy2, new Vector3(5, 4, 4), Quaternion.identity);
        Instantiate(enemy2, new Vector3(-2, 4, 4), Quaternion.identity);
        Instantiate(enemy2, new Vector3(10, 2, 2), Quaternion.identity);
        Instantiate(enemy2, new Vector3(-10, 2, 2), Quaternion.identity);
        Instantiate(enemy2, new Vector3(-10, 9, 2), Quaternion.identity);
        Instantiate(enemy2, new Vector3(-10, 9, 2), Quaternion.identity);
    }

    void TreeGenerater()
    {
        Instantiate(tree, new Vector3(0, 1, 80), Quaternion.identity); ;
    }

}
