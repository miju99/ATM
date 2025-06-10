using TMPro;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    [SerializeField]
    public GameObject itemImage; //������ �̹���
    [SerializeField]
    private TextMeshProUGUI itemnameText; //������ �̸�

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
