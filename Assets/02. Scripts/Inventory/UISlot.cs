using TMPro;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    [SerializeField]
    public GameObject itemImage; //아이템 이미지
    [SerializeField]
    private TextMeshProUGUI itemnameText; //아이템 이름

    private Item itemdata;

    public void SetItem(Item item)
    {
        itemdata = item;
        if(item != null)
        {
            itemnameText.text = item.name;
        }
        else
        {
            itemnameText.text = "";
        }
    }

    private void RefreshUI()
    {

    }
}
