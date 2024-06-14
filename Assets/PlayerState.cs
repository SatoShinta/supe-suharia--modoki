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

    [SerializeField ,Header ("�q�b�g�|�C���g")] private int hp = 0;
    [SerializeField] Text hpText;
    [SerializeField] GameObject itemBoxManager;
    [SerializeField, Header("�N���[��")] GameObject clone;

    

    public void Start()
    {
      
    }



    private void Update()
    {
        //��ʂɕ\������HP�̒l
        hpText.GetComponent<Text>().text = "HP : " + hp.ToString();

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

        if (cloneCounter3 == 1)
        {
            //timer2�̃J�E���g�i�������ԁj�𑝂₵�Ă���
            timer3 += Time.deltaTime;
        }


        //hp�̒l��0���
        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("�������`���b�^");
        }

        if (timer >= 10f)
        {
            Destroy(instantiatedClone);
            Destroy(instantiatedClone2);
            cloneCounter = 0;
        }
        if(timer2 >= 10f)
        {
            Destroy(instantiatedClone3);
            Destroy(instantiatedClone4);
            cloneCounter2 = 0;
        }
        if(timer3 >= 10f)
        {
            Destroy(instantiatedClone3);
            Destroy(instantiatedClone4);
            cloneCounter3 = 0;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ( "Item"))
        {
            switch (collision.gameObject.GetComponent<ItemManager>().itemNo)
            {
                case 0:
                    hp++;
                    Destroy(collision.gameObject);
                    break;
                case 1:
                    if(cloneCounter == 0)
                    {
                        instantiatedClone = Instantiate(clone, new Vector3(transform.position.x + 3, transform.position.y, -4.66f), Quaternion.identity, transform.parent);
                        instantiatedClone2 = Instantiate(clone, new Vector3(transform.position.x - 3, transform.position.y, -4.66f), Quaternion.identity, transform.parent);
                        Destroy(collision.gameObject);
                        cloneCounter++;
                    }
                    break;
                case 2:
                    if(cloneCounter2 == 0)
                    {
                        instantiatedClone3 = Instantiate(clone, new Vector3(transform.position.x , transform.position.y +2, -4.66f), Quaternion.identity, transform.parent);
                        instantiatedClone4 = Instantiate(clone, new Vector3(transform.position.x , transform.position.y -3 , -4.66f), Quaternion.identity, transform.parent);
                        Destroy(collision.gameObject);
                        cloneCounter2++;
                    }
                    break;
                case 3:
                    if(cloneCounter3 == 0)
                    {
                        GetComponent<EnemyDestroy>().counter = 1;
                        Destroy(collision.gameObject);
                        cloneCounter3++;
                    }
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
    

