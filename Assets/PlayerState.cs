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

    [SerializeField ,Header ("ヒットポイント")] private int hp = 0;
    [SerializeField] Text hpText;
    [SerializeField] GameObject itemBoxManager;
    [SerializeField, Header("クローン")] GameObject clone;

    

    public void Start()
    {
        //変数objにEnemyタグを持ったobjectの情報を取得する
        GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
        //enemyDestroyCounterにEnemyタグを持ったobjectのEnemyDestroyコンポーネントを取得する
        enemyDestroyCounter = obj.GetComponent<EnemyDestroy>();
    }



    private void Update()
    {
        //画面に表示するHPの値
        hpText.GetComponent<Text>().text = "HP : " + hp.ToString();
        Debug.Log(Time.time);

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



        //hpの値が0より小さくなったら(HPが０になったら)
        if (hp <= 0)
        {
            //このscriptをアタッチしているobjectを破壊する
            Destroy(gameObject);
            Debug.Log("ヤラレチャッタ");
        }

        //timerの値が10よりも大きくなったら
        if (timer >= 10f)
        {
            //playerの横にスポーンさせたCloneを破壊する
            Destroy(instantiatedClone);
            Destroy(instantiatedClone2);
            //そしてcloneCounterの値をリセットする
            cloneCounter = 0;
        }

        //timer2の値が10よりも大きくなったら
        if(timer2 >= 10f)
        {
            //playerの縦にスポーンしたCloneを破壊する
            Destroy(instantiatedClone3);
            Destroy(instantiatedClone4);
            //そしてcloneCounter2の値をリセットする
            cloneCounter2 = 0;
        }
      
    }



    private void OnCollisionEnter(Collision collision)
    {
        //Itemタグを持ったobjectに当たったとき
        if (collision.gameObject.CompareTag ( "Item"))
        {
            //相手のItemManagerコンポーネントの中にあるitemNoを取得し、
            switch (collision.gameObject.GetComponent<ItemManager>().itemNo)
            {
                //それが0だったら
                case 0:
                    //hpを1増やし、当たったobjectを破壊する
                    hp++;
                    Destroy(collision.gameObject);
                    break;
                //それが1だったら
                case 1:
                    //cloneCounterの値が0の時
                    if(cloneCounter == 0)
                    {
                        //横方向にcloneを2体発生させ、当たったobjectを破壊し、cloneCounterの値を1増やす
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
    

