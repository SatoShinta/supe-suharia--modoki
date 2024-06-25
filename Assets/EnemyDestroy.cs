using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] public float counter = 0;
    float timer = 0;
    public GameObject effectPrefab;
    public AudioClip sound;

    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //���̃I�u�W�F�N�g��z���̈ʒu���]10�Ɉȉ��ɂȂ�����
        if (transform.position.z <= -20 || timer >= 8f)
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

        //counter��4�ȏ�ɂȂ�����
        if (counter >= 3)
        {
            //�j�󂷂�
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
