using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private bool isDamage = true;
    public bool coloutinOK = false;
    public int tenmetuCounter = 0;
    public int cloneCounter = 0;
    public int cloneCounter2 = 0;
    public int cloneCounter3 = 0;

    private float timer;
    private float timer2;
    private float timer3;

    private GameObject instantiatedClone;
    private GameObject instantiatedClone2;
    private GameObject instantiatedClone3;
    private GameObject instantiatedClone4;
    private EnemyDestroy enemyDestroyCounter;

    [SerializeField ,Header ("�q�b�g�|�C���g")] private int hp = 0;
    [SerializeField] Text hpText;
    [SerializeField] GameObject itemBoxManager;
    [SerializeField, Header("�N���[��")] GameObject clone;

    

    public void Start()
    {
        //�ϐ�obj��Enemy�^�O��������object�̏����擾����
        GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
        //enemyDestroyCounter��Enemy�^�O��������object��EnemyDestroy�R���|�[�l���g���擾����
        enemyDestroyCounter = obj.GetComponent<EnemyDestroy>();
    }



    private void Update()
    {
        //��ʂɕ\������HP�̒l
        hpText.GetComponent<Text>().text = "HP : " + hp.ToString();
        Debug.Log(Time.time);

        //cloneCounter�̒l��1�̎�
        if (cloneCounter == 1)
        {
            //timer�̃J�E���g�i�������ԁj�𑝂₵�Ă���
            timer += Time.deltaTime;
        }

        //cloneCounter2�̒l��1�̎�
        if (cloneCounter2 == 1)
        {
            //timer2�̃J�E���g�i�������ԁj�𑝂₵�Ă���
            timer2 += Time.deltaTime;
        }



        //hp�̒l��0��菬�����Ȃ�����(HP���O�ɂȂ�����)
        if (hp <= 0)
        {
            //����script���A�^�b�`���Ă���object��j�󂷂�
            Destroy(gameObject);
            Debug.Log("�������`���b�^");
        }

        //timer�̒l��10�����傫���Ȃ�����
        if (timer >= 10f)
        {
            //player�̉��ɃX�|�[��������Clone��j�󂷂�
            Destroy(instantiatedClone);
            Destroy(instantiatedClone2);
            //������cloneCounter�̒l�����Z�b�g����
            cloneCounter = 0;
        }

        //timer2�̒l��10�����傫���Ȃ�����
        if(timer2 >= 10f)
        {
            //player�̏c�ɃX�|�[������Clone��j�󂷂�
            Destroy(instantiatedClone3);
            Destroy(instantiatedClone4);
            //������cloneCounter2�̒l�����Z�b�g����
            cloneCounter2 = 0;
        }
      
    }



    private void OnCollisionEnter(Collision collision)
    {
        //Item�^�O��������object�ɓ��������Ƃ�
        if (collision.gameObject.CompareTag ( "Item"))
        {
            //�����ItemManager�R���|�[�l���g�̒��ɂ���itemNo���擾���A
            switch (collision.gameObject.GetComponent<ItemManager>().itemNo)
            {
                //���ꂪ0��������
                case 0:
                    //hp��1���₵�A��������object��j�󂷂�
                    hp++;
                    Destroy(collision.gameObject);
                    break;
                //���ꂪ1��������
                case 1:
                    //cloneCounter�̒l��0�̎�
                    if(cloneCounter == 0)
                    {
                        //��������clone��2�̔��������A��������object��j�󂵁AcloneCounter�̒l��1���₷
                        instantiatedClone = Instantiate(clone, new Vector3(transform.position.x + 3, transform.position.y, -4.66f), Quaternion.identity, transform.parent);
                        instantiatedClone2 = Instantiate(clone, new Vector3(transform.position.x - 3, transform.position.y, -4.66f), Quaternion.identity, transform.parent);
                        Destroy(collision.gameObject);
                        cloneCounter++;
                    }
                    break;
                case 2:
                    if(cloneCounter2 == 0)
                    {
                        instantiatedClone3 = Instantiate(clone, new Vector3(transform.position.x , transform.position.y +3 , -4.66f), Quaternion.identity, transform.parent);
                        instantiatedClone4 = Instantiate(clone, new Vector3(transform.position.x , transform.position.y -3 , -4.66f), Quaternion.identity, transform.parent);
                        Destroy(collision.gameObject);
                        cloneCounter2++;
                    }
                    break;
                case 3:
                    enemyDestroyCounter.counter++;
                    Destroy(collision.gameObject);
                    Debug.Log("aaaa");
                    break;
                    
            }
        }

        if (isDamage && !coloutinOK)
        {

            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Tree")
            {
                StartCoroutine(DamageCoroutin());
                Debug.Log("�G�ɓ�������");
                hp--;
            }
            
        }
    }


    private IEnumerator DamageCoroutin()
    {
        Renderer renderer = GetComponent<Renderer>();
        isDamage = true ;
        coloutinOK = true ;
        tenmetuCounter = 0;
        while (tenmetuCounter < 5)
        {
            //�����_���[�R���|�[�l���g�̗L���A������؂�ւ���
            renderer.enabled = !renderer.enabled;
            //0.3�b����
            yield return new WaitForSeconds(0.3f);
            tenmetuCounter++;
        }
        renderer.enabled = true ;
        coloutinOK = false;

    }

}
    

