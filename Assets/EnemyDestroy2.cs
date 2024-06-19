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
        //一秒ごとにtimerに数値を入れていく
        timer = Time.deltaTime;

        //もしこのオブジェクトの位置（z軸）が－10よりも手前に来るか、timerが8より大きくなったとき
    if (transform.position.z <= -10 || timer >= 8)
    {
        //破壊する
        Destroy(gameObject);
    }
    //counterが5より大きくなったとき
    if (counter >= 4)
    {
        //破壊する
        Destroy(gameObject);
    }
}


private void OnCollisionEnter(Collision collision)
{
        //Bulletタグを持ったオブジェクトに当たった時
    if (collision.gameObject.tag == "Bullet")
    {
            //counterを1増やす
        Debug.LogWarning("球が当たりました");
        counter++;
    }


        }
}
