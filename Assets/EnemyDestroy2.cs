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
        //��b���Ƃ�timer�ɐ��l�����Ă���
        timer = Time.deltaTime;

        //�������̃I�u�W�F�N�g�̈ʒu�iz���j���|10������O�ɗ��邩�Atimer��8���傫���Ȃ����Ƃ�
    if (transform.position.z <= -10 || timer >= 8)
    {
        //�j�󂷂�
        Destroy(gameObject);
    }
    //counter��5���傫���Ȃ����Ƃ�
    if (counter >= 4)
    {
        //�j�󂷂�
        Destroy(gameObject);
    }
}


private void OnCollisionEnter(Collision collision)
{
        //Bullet�^�O���������I�u�W�F�N�g�ɓ���������
    if (collision.gameObject.tag == "Bullet")
    {
            //counter��1���₷
        Debug.LogWarning("����������܂���");
        counter++;
    }


        }
}
