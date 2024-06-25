using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Header("敵のプレハブ")] GameObject enemy;
    [SerializeField, Header("敵のプレハブ2")] GameObject enemy2;
    [SerializeField, Header("弾を発射する敵のプレハブ")] GameObject bulletEnemy;
    [SerializeField, Header("ボスのプレハブ")] GameObject bossEnemy;
    [SerializeField,Header("木のプレハブ")] GameObject tree;
    [SerializeField, Header("生成間隔")] float generateInterval;
    [SerializeField, Header("生成間隔2")] float generateInterval2;
    [SerializeField, Header("生成間隔3")] float generateInterval3;
    [SerializeField, Header("木の生成間隔")] float treeGenerateInterval;
    [SerializeField, Header("生成終了時間")] float stopTime;
    [SerializeField, Header("生成終了時間")] float stopTime2;
    [SerializeField, Header("木の生成終了時間")] float treeStopTime;
    [SerializeField, Header("木の生成終了時間2")] float treeStopTime2;
    [SerializeField, Header("木の生成終了時間3")] float treeStopTime3;
    [SerializeField, Header("木の生成終了時間4")] float treeStopTime4;
    [SerializeField, Header("木の生成終了時間5")] float treeStopTime5;


    float numEnemy01 = 0;
    float numEnemy02 = 0;
    float numTree = 0;
    float numEnemy2 = 0;
    float elapsedTime = 0;
    int counter = 0;

    bool isGenerate = true;
    bool isGenerate2 = true;
    bool isGenerateBulletEnemy = false;
    bool isGenerateBulletEnemy2 = false;
    bool isGenerateBossEnemy = true;

    bool isTreeGenerate = true;
    bool isTreeTreeGenerate2;
    bool isTreeTreeGenerate3;
    bool isTreeTreeGenerate4;
    bool isTreeTreeGenerate5;


    private void Start()
    {
        numEnemy01 = 0;
        numEnemy02 = 0;
        numTree = 0;
        numEnemy2 = 0;
        elapsedTime = 0;
        counter = 0;
        isGenerate = true;
        isGenerate2 = true;
        isGenerateBulletEnemy = false;
        isGenerateBulletEnemy2 = false;
        isGenerateBossEnemy = true;
       
       
    }


    // Update is called once per frame
    void Update()
    {
        numEnemy01 += Time.deltaTime;
        numEnemy02 += Time.deltaTime;
        numTree += Time.deltaTime;
        numEnemy2 += Time.deltaTime;
        elapsedTime += Time.deltaTime;


        //ゲーム内の経過時間で動くプログラムを作る
        if(elapsedTime > 36 && elapsedTime <= treeStopTime2)
        {
            isTreeTreeGenerate2 = true;

            if (isTreeTreeGenerate2 == true && numTree >= treeGenerateInterval)
            {
                TreeGenerater2();
                numTree = 0;
            }
        }

        if (isTreeTreeGenerate3 == true && numTree >= treeGenerateInterval)
        {
            TreeGenerater3();
            numTree = 0;
        }

        if(isTreeTreeGenerate4 == true && numTree >= treeGenerateInterval)
        {
            TreeGenerater4();
            numTree = 0;
        }

        if(isTreeTreeGenerate5 == true && numTree >= treeGenerateInterval)
        {
            TreeGenerater5();
            numTree = 0;
        }

        if(elapsedTime > 44  && isGenerateBulletEnemy == false)
        {
           BulletEnemyGenerater();
           
        } 
        
        if(elapsedTime > 52  && isGenerateBulletEnemy2 == false)
        {
           BulletEnemyGenerater2();
           
        } 

        if(isGenerateBossEnemy == true && elapsedTime >= 64) 
        {
            BossEnemy();
            counter = 1;
            if(counter == 1)
            {
                isGenerateBossEnemy = false;
            }
        }








        //頑張って作った処理

            //isTreeGenerateがfalseの時
            if (isTreeGenerate)
        {
            //numTree が treeGenerateInterval より大きくなるか、elapsedTime が  stopTime を上回った時
            if (numTree >= treeGenerateInterval && elapsedTime >= stopTime)
            {
                //TreeGeneraterメソッドを呼び出し、numTreeの値を0にする
                TreeGenerater();
                numTree = 0;
            }
        }


        //isGenerateがfalseの時
        if (isGenerate)
        {
            //numEnemy1 が generateIntervalを上回った時
            if (numEnemy01 >= generateInterval)
            {
                //EnemyGenerater1を呼び出し、numEnemyに0を代入する
                EnemyGenerater1();
                numEnemy01 = 0;
            }

            //numEnemy12 が generateInterval2 を上回った時
            if (numEnemy02 >= generateInterval2)
            {
                //EnemyGenerater2　を呼び出し、 numEnemy12 に0を代入する
                EnemyGenerater2();
                numEnemy02 = 0;
            }
        }

        //isGenerate2 がtureで、 numEnemy2 が generateInterval3 を上回り、 elapsedTime が treeStopTimeに2を足した数を上回った時
        if (isGenerate2 == true)
            if(numEnemy2 >= generateInterval3 && elapsedTime >= treeStopTime + 2)
        {
                //EnemyGenerater3 を呼び出し、 numEnemy2に0を代入する
                EnemyGenerater3();
            numEnemy2 = 0;
        }


        //elapsedTime が　stopTime を上回った時
        if (elapsedTime >= stopTime)
        {
            //isGanarateフラグをfalseにする
            isGenerate = false;

            //elapsedTime　が　treeStopTime　を上回った時
            if (elapsedTime >= treeStopTime)
            {
                //isTreeGenerateフラグをfalseにする
                isTreeGenerate = false;
            }

            //elapsedTime　が　stopTime2　を上回った時
            if (elapsedTime >= stopTime2)
            {
                //isGanarate2フラグをfalseにする
                isGenerate2 = false;
            }

            //elapsedTime が treeStopTime2 を上回った時
            if (elapsedTime >= treeStopTime2)
            {
                //isTreeTreeGenerate3 をtureにし、 isTreeTreeGenerate2 をfalseにする
                isTreeTreeGenerate3 = true;
                isTreeTreeGenerate2 = false;
            }
            
            //elapsedTime が treeStopTime3 を上回った時
            if (elapsedTime >= treeStopTime3)
            {
                //isTreeTreeGenerate4 をtureにし、 isTreeTreeGenerate3 をfalseにする
                isTreeTreeGenerate4 = true;
                isTreeTreeGenerate3 = false;
                if(elapsedTime >= treeStopTime3 + 1)
                {
                    isGenerateBulletEnemy = true;
                }
            }

            //elapsedTime が treeStopTime4 を上回った時
            if (elapsedTime >= treeStopTime4 + 1)
            {
                //isTreeTreeGenerate4 をtureにし、 isTreeTreeGenerate3 をfalseにする
                isTreeTreeGenerate5 = true;
                isTreeTreeGenerate4 = false;
                if(elapsedTime>=treeStopTime4 + 2)
                {
                    isGenerateBulletEnemy2 = true;
                }
            }
            
            //elapsedTime が treeStopTime5 を上回った時
            if (elapsedTime >= treeStopTime5)
            {
                //isTreeTreeGenerate5 をfalseにする
                isTreeTreeGenerate5 = false;
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

    void BulletEnemyGenerater()
    {
        Instantiate(bulletEnemy, new Vector3(-6,6,15), Quaternion.identity);
        Instantiate(bulletEnemy, new Vector3(0,6,15), Quaternion.identity);
        Instantiate(bulletEnemy, new Vector3(6,6,15), Quaternion.identity);
    } 
    
    void BulletEnemyGenerater2()
    {
        Instantiate(bulletEnemy, new Vector3(-7,1,15), Quaternion.identity);
        Instantiate(bulletEnemy, new Vector3(0,1,15), Quaternion.identity);
        Instantiate(bulletEnemy, new Vector3(7,1,15), Quaternion.identity);
    }

    void BossEnemy()
    {
        Instantiate(bossEnemy, new Vector3(0, 1, 70), Quaternion.identity);
    }




    void TreeGenerater()
    {
        Instantiate(tree, new Vector3(0, 1, 80), Quaternion.identity); 
    }

    void TreeGenerater2()
    {
        Instantiate(tree, new Vector3(-7, 1, 70), Quaternion.identity) ;
        Instantiate(tree, new Vector3(0, 1, 70), Quaternion.identity) ;
        Instantiate(tree, new Vector3(7, 1, 70), Quaternion.identity) ;
    }

    void TreeGenerater3()
    {
        Instantiate(tree, new Vector3(-4, 1, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(4, 1, 70), Quaternion.identity);
    }

    void TreeGenerater4()
    {
        Instantiate(tree, new Vector3(-7, -4, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(-4, -4, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(-2, -4, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(0, -4, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(2, -4, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(4, -4, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(7, -4, 70), Quaternion.identity);
    }
    
    void TreeGenerater5()
    {
        Instantiate(tree, new Vector3(-7, 8, 70), Quaternion.Euler(0,0,180));
        Instantiate(tree, new Vector3(-4, 8, 70), Quaternion.Euler(0, 0, 180));
        Instantiate(tree, new Vector3(-2, 8, 70), Quaternion.Euler(0, 0, 180));
        Instantiate(tree, new Vector3(0, 8, 70), Quaternion.Euler(0, 0, 180));
        Instantiate(tree, new Vector3(2, 8, 70), Quaternion.Euler(0, 0, 180));
        Instantiate(tree, new Vector3(4, 8, 70), Quaternion.Euler(0, 0, 180));
        Instantiate(tree, new Vector3(7, 8, 70), Quaternion.Euler(0, 0, 180));
    }

}
