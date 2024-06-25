using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Header("�G�̃v���n�u")] GameObject enemy;
    [SerializeField, Header("�G�̃v���n�u2")] GameObject enemy2;
    [SerializeField, Header("�e�𔭎˂���G�̃v���n�u")] GameObject bulletEnemy;
    [SerializeField, Header("�{�X�̃v���n�u")] GameObject bossEnemy;
    [SerializeField,Header("�؂̃v���n�u")] GameObject tree;
    [SerializeField, Header("�����Ԋu")] float generateInterval;
    [SerializeField, Header("�����Ԋu2")] float generateInterval2;
    [SerializeField, Header("�����Ԋu3")] float generateInterval3;
    [SerializeField, Header("�؂̐����Ԋu")] float treeGenerateInterval;
    [SerializeField, Header("�����I������")] float stopTime;
    [SerializeField, Header("�����I������")] float stopTime2;
    [SerializeField, Header("�؂̐����I������")] float treeStopTime;
    [SerializeField, Header("�؂̐����I������2")] float treeStopTime2;
    [SerializeField, Header("�؂̐����I������3")] float treeStopTime3;
    [SerializeField, Header("�؂̐����I������4")] float treeStopTime4;
    [SerializeField, Header("�؂̐����I������5")] float treeStopTime5;


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


        //�Q�[�����̌o�ߎ��Ԃœ����v���O���������
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








        //�撣���č��������

            //isTreeGenerate��false�̎�
            if (isTreeGenerate)
        {
            //numTree �� treeGenerateInterval ���傫���Ȃ邩�AelapsedTime ��  stopTime ����������
            if (numTree >= treeGenerateInterval && elapsedTime >= stopTime)
            {
                //TreeGenerater���\�b�h���Ăяo���AnumTree�̒l��0�ɂ���
                TreeGenerater();
                numTree = 0;
            }
        }


        //isGenerate��false�̎�
        if (isGenerate)
        {
            //numEnemy1 �� generateInterval����������
            if (numEnemy01 >= generateInterval)
            {
                //EnemyGenerater1���Ăяo���AnumEnemy��0��������
                EnemyGenerater1();
                numEnemy01 = 0;
            }

            //numEnemy12 �� generateInterval2 ����������
            if (numEnemy02 >= generateInterval2)
            {
                //EnemyGenerater2�@���Ăяo���A numEnemy12 ��0��������
                EnemyGenerater2();
                numEnemy02 = 0;
            }
        }

        //isGenerate2 ��ture�ŁA numEnemy2 �� generateInterval3 ������A elapsedTime �� treeStopTime��2�𑫂���������������
        if (isGenerate2 == true)
            if(numEnemy2 >= generateInterval3 && elapsedTime >= treeStopTime + 2)
        {
                //EnemyGenerater3 ���Ăяo���A numEnemy2��0��������
                EnemyGenerater3();
            numEnemy2 = 0;
        }


        //elapsedTime ���@stopTime ����������
        if (elapsedTime >= stopTime)
        {
            //isGanarate�t���O��false�ɂ���
            isGenerate = false;

            //elapsedTime�@���@treeStopTime�@����������
            if (elapsedTime >= treeStopTime)
            {
                //isTreeGenerate�t���O��false�ɂ���
                isTreeGenerate = false;
            }

            //elapsedTime�@���@stopTime2�@����������
            if (elapsedTime >= stopTime2)
            {
                //isGanarate2�t���O��false�ɂ���
                isGenerate2 = false;
            }

            //elapsedTime �� treeStopTime2 ����������
            if (elapsedTime >= treeStopTime2)
            {
                //isTreeTreeGenerate3 ��ture�ɂ��A isTreeTreeGenerate2 ��false�ɂ���
                isTreeTreeGenerate3 = true;
                isTreeTreeGenerate2 = false;
            }
            
            //elapsedTime �� treeStopTime3 ����������
            if (elapsedTime >= treeStopTime3)
            {
                //isTreeTreeGenerate4 ��ture�ɂ��A isTreeTreeGenerate3 ��false�ɂ���
                isTreeTreeGenerate4 = true;
                isTreeTreeGenerate3 = false;
                if(elapsedTime >= treeStopTime3 + 1)
                {
                    isGenerateBulletEnemy = true;
                }
            }

            //elapsedTime �� treeStopTime4 ����������
            if (elapsedTime >= treeStopTime4 + 1)
            {
                //isTreeTreeGenerate4 ��ture�ɂ��A isTreeTreeGenerate3 ��false�ɂ���
                isTreeTreeGenerate5 = true;
                isTreeTreeGenerate4 = false;
                if(elapsedTime>=treeStopTime4 + 2)
                {
                    isGenerateBulletEnemy2 = true;
                }
            }
            
            //elapsedTime �� treeStopTime5 ����������
            if (elapsedTime >= treeStopTime5)
            {
                //isTreeTreeGenerate5 ��false�ɂ���
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
