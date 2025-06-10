using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image itemImage; //������ �̹���

    public Button equipButton;

    private Item item;

    public GameObject Emotion; //���� ǥ��
    private static GameObject currentEmotion; //Emotion�� �����ִ� �� Ȯ���ϴ� ����

    /*[SerializeField]
    private TextMeshProUGUI itemnameText; //������ �̸�*/

    //private Item itemdata;

    private void Start()
    {
        equipButton.onClick.AddListener(OnClickEquip);
    }

    private void OnClickEquip()
    {        
        //InventoryGameManager.Instance.Player.Equip(item);

        if (InventoryGameManager.Instance.Player.EquippedItem == item)
        {
            InventoryGameManager.Instance.Player.UnEquip();
        }
        else
        {
            InventoryGameManager.Instance.Player.Equip(item);
        }

        if (Emotion != null) //�ߺ� emotion�� ���� ����
        {
            if(currentEmotion != null && currentEmotion != Emotion)
            {
                currentEmotion.SetActive(false);
            }
            bool newActiveState = !Emotion.activeSelf;
            Emotion.SetActive(newActiveState);

            currentEmotion = newActiveState ? Emotion : null;
        }
    }

    public void SetItem(Item item)
    {        
        //Debug.Log($"=== SetItem ȣ��: {(item != null ? item.ItemName : "null")} ===");
        if (item != null)
        {
            this.item = item;
            //itemdata = item;
            //itemnameText.text = item.ItemName;
            Debug.Log($"������ �̸�: {item.ItemName}");
            Debug.Log($"������ ���� ����: {(item.Icon != null ? "����" : "����")}");
            if (item.Icon != null)
            {
                itemImage.sprite = item.Icon;
                itemImage.gameObject.SetActive(true);
                Debug.Log("�̹��� Ȱ��ȭ �Ϸ�");
            }
            else
            {
                itemImage.gameObject.SetActive(false);
                Debug.Log("�������� null - �̹��� ��Ȱ��ȭ");
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
