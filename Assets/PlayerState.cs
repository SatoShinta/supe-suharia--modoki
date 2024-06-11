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
    
    [SerializeField ,Header ("ヒットポイント")] private int hp = 0;
    [SerializeField] Text hpText;
    [SerializeField] GameObject itemBoxManager;
    [SerializeField, Header("クローン")] GameObject clone;


    public void Start()
    {
       Vector3 clonePos = GetComponent<Transform>().position;
    }



    private void Update()
    {
        hpText.GetComponent<Text>().text = "HP : " + hp.ToString();


        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ヤラレチャッタ");
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
                    break;
                case 1:
                    if(cloneCounter == 0)
                    {
                        Instantiate(clone, new Vector3(transform.position.x + 3, transform.position.y, -4.66f), Quaternion.identity, transform.parent);
                        Instantiate(clone, new Vector3(transform.position.x - 3, transform.position.y, -4.66f), Quaternion.identity, transform.parent); 
                        cloneCounter++;
                    }
                    break;
                case 2:
                    if(cloneCounter2 == 0)
                    {
                        Instantiate(clone, new Vector3(transform.position.x , transform.position.y +2, -4.66f), Quaternion.identity, transform.parent);
                        Instantiate(clone, new Vector3(transform.position.x , transform.position.y -3 , -4.66f), Quaternion.identity, transform.parent);
                        cloneCounter2++;
                    }
                    break;
                case 3:
                    GetComponent<EnemyDestroy>().counter = 1;
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
    

