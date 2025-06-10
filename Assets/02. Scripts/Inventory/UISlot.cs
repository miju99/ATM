using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image itemImage; //아이템 이미지

    public Button equipButton;

    private Item item;

    public GameObject Emotion;

    /*[SerializeField]
    private TextMeshProUGUI itemnameText; //아이템 이름*/

    //private Item itemdata;

    private void Start()
    {
        equipButton.onClick.AddListener(OnClickEquip);
    }

    private void OnClickEquip()
    {
        //InventoryGameManager.Instance.Player.Equip(item);

        if(InventoryGameManager.Instance.Player.EquippedItem == item)
        {
            InventoryGameManager.Instance.Player.UnEquip();
        }
        else
        {
            InventoryGameManager.Instance.Player.Equip(item);
        }

        if (Emotion != null)
        {
            Emotion.SetActive(!Emotion.activeSelf);
        }
    }

    public void SetItem(Item item)
    {        
        //Debug.Log($"=== SetItem 호출: {(item != null ? item.ItemName : "null")} ===");
        if (item != null)
        {
            this.item = item;
            //itemdata = item;
            //itemnameText.text = item.ItemName;
            Debug.Log($"아이템 이름: {item.ItemName}");
            Debug.Log($"아이콘 존재 여부: {(item.Icon != null ? "있음" : "없음")}");
            if (item.Icon != null)
            {
                itemImage.sprite = item.Icon;
                itemImage.gameObject.SetActive(true);
                Debug.Log("이미지 활성화 완료");
            }
            else
            {
                itemImage.gameObject.SetActive(false);
                Debug.Log("아이콘이 null - 이미지 비활성화");
            }
        }
        else
        {
            //itemnameText.text = "";
            itemImage.gameObject.SetActive(false);
        }
    }

    private void RefreshUI()
    {

    }
}
