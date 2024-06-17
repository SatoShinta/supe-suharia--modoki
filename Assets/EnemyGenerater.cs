using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Header("敵のプレハブ")] GameObject enemy;
    [SerializeField, Header("弾を発射する敵のプレハブ")] GameObject enemy2;
    [SerializeField,Header("木のプレハブ")] GameObject tree;
    [SerializeField, Header("生成間隔")] float generateInterval;
    [SerializeField, Header("生成間隔2")] float generateInterval2;
    [SerializeField, Header("生成間隔3")] float generateInterval3;
    [SerializeField, Header("木の生成間隔")] float treeGenerateInterval;
    [SerializeField, Header("生成終了時間")] float stopTime;
    [SerializeField, Header("生成終了時間")] float stopTime2;
    [SerializeField, Header("木の生成終了時間")] float treeStopTime;
    [SerializeField, Header("木の生成終了時間2")] float treeStopTime2;

    float numEnemy01 = 0;
    float numEnemy02 = 0;
    float numTree = 0;
    float numEnemy2 = 0;
    float elapsedTime = 0;

    bool isGenerate = true;
    bool isGenerate2 = true;
    bool isTreeGenerate = true;
   public bool isTreeTreeGenerate2;
    bool isTreeTreeGenerate3;

   

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
        Instantiate(tree, new Vector3(0, 1, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(4, 1, 70), Quaternion.identity);
    }

    void TreeGenerater4()
    {
        Instantiate(tree, new Vector3(-7, -2, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(-4, -2, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(-2, -2, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(0, -2, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(2, -2, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(4, -2, 70), Quaternion.identity);
        Instantiate(tree, new Vector3(7, -2, 70), Quaternion.identity);
    }

}
