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

    [SerializeField ,Header ("ヒットポイント")] private int hp = 0;
    [SerializeField] Text hpText;
    [SerializeField] GameObject itemBoxManager;
    [SerializeField, Header("クローン")] GameObject clone;

    

    public void Start()
    {
      
    }



    private void Update()
    {
        //画面に表示するHPの値
        hpText.GetComponent<Text>().text = "HP : " + hp.ToString();

        //cloneCounterの値が1の時
        if (cloneCounter == 1)
        {
            //timerのカウント（現実時間）を増やしていく
            timer += Time.deltaTime;
        }

        //cloneCounter2の値が1の時
        if (cloneCounter2 == 1)
        {
            //timer2のカウント（現実時間）を増やしていく
            timer2 += Time.deltaTime;
        }

        if (cloneCounter3 == 1)
        {
            //timer2のカウント（現実時間）を増やしていく
            timer3 += Time.deltaTime;
        }


        //hpの値が0より
        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ヤラレチャッタ");
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
                Debug.Log("敵に当たった");
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
            //レンダラーコンポーネントの有効、無効を切り替える
            renderer.enabled = !renderer.enabled;
            //0.3秒ずつ
            yield return new WaitForSeconds(0.3f);
            tenmetuCounter++;
        }
        renderer.enabled = true ;
        coloutinOK = false;

    }

}
    

