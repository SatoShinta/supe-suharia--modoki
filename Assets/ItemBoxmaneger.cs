using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxmaneger : MonoBehaviour
{



    [SerializeField] ItemSO itemSO;
    public int getItem;
    private int[] itemQtyAry;//�e�A�C�e���̏��������i�[����z��


    // Start is called before the first frame update
    void Start()
    {
        itemQtyAry = new int[itemSO.itemList.Count];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
