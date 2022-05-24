using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopUI;
    public Transform ShopItemHolder;
    public DialogueUi dialogueUi;
        private void Awake() {
            dialogueUi = GameObject.FindGameObjectWithTag("Canvas").GetComponent<DialogueUi>();
        }
        public void CloseShop(){
        ShopUI.SetActive(false);
        for (int i = 0; i <= ShopItemHolder.childCount - 1; i++)
        {
            GameObject.Destroy(ShopItemHolder.GetChild(i).gameObject);
        }
        dialogueUi.isOpen = false;
    }
}
