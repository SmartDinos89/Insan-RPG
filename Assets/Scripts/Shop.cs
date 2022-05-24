using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Transform ShopItemHolder;
    public DialogueUi dialogueUi;
        private void Awake() {
            dialogueUi = GameObject.FindGameObjectWithTag("Canvas").GetComponent<DialogueUi>();
        }
        public void CloseShop(){
        gameObject.SetActive(false);
        for (int i = 0; i <= ShopItemHolder.childCount - 1; i++)
        {
            GameObject.Destroy(ShopItemHolder.GetChild(i).gameObject);
        }
        dialogueUi.isOpen = false;
    }
}
