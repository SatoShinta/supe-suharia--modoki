using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField,Header("�G�̃v���n�u")] GameObject enemy;
    [SerializeField, Header("�e�𔭎˂���G�̃v���n�u")] GameObject enemy2;
    [SerializeField,Header("�؂̃v���n�u")] GameObject tree;
    [SerializeField, Header("�����Ԋu")] float generateInterval;
    [SerializeField, Header("�����Ԋu2")] float generateInterval2;
    [SerializeField, Header("�����Ԋu3")] float generateInterval3;
    [SerializeField, Header("�؂̐����Ԋu")] float treeGenerateInterval;
    [SerializeField, Header("�����I������")] float stopTime;
    [SerializeField, Header("�����I������")] float stopTime2;
    [SerializeField, Header("�؂̐����I������")] float treeStopTime;
    [SerializeField, Header("�؂̐����I������2")] float treeStopTime2;

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
