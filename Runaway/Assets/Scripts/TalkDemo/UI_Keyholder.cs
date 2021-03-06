using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Keyholder : MonoBehaviour
{



    [SerializeField] private KeyHolder keyHolder;

    private Transform container;
    private Transform keyTemplate;



    private void Awake()
    {
        container = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }


    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e){

        UpdateVisual();  
        
    }


    private void UpdateVisual(){
        //old keys
        foreach(Transform child in container){
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        } 
        //Instantiate current keys  
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i=0; i < keyList.Count; i++) {
            Key.KeyType keyType = keyList[i];
           Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image KeyImage = keyTransform.Find("image").GetComponent<Image>(); 
            switch (keyType){
                default:
                case Key.KeyType.Red: KeyImage.color = Color.red;       break;
                case Key.KeyType.Green: KeyImage.color = Color.green;   break;
                case Key.KeyType.Blue :KeyImage.color = Color.blue;     break;
            }
        }
            
    }



}
