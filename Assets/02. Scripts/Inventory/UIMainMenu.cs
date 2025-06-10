using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button StatusButton; //����ȭ���� �������ͽ� ��ư
    [SerializeField]
    private Button InventoryButtton; //����ȭ���� �κ��丮 ��ư

    [SerializeField]
    private TextMeshProUGUI idText; //�÷��̾� ���̵�
    [SerializeField]
    private TextMeshProUGUI moneyText; //�÷��̾� �ڱ�
    [SerializeField]
    private TextMeshProUGUI lvText; //�÷��̾� ����

    public void Start()
    {
        StatusButton.onClick.AddListener(OpenStatus);
        InventoryButtton.onClick.AddListener(OpenInventory);
    }

    public void OpenMainMenu() //����ȭ������ �̵�
    {
        UIManager.Instance.MainMenu.gameObject.SetActive(true);
        UIManager.Instance.Status.gameObject.SetActive(false);
        UIManager.Instance.Inventory.gameObject.SetActive(false);
    }

    public void OpenStatus() //�������ͽ��� �̵�
    {
        UIManager.Instance.MainMenu.gameObject.SetActive(false);
        UIManager.Instance.Status.gameObject.SetActive(true);
    }

    public void OpenInventory() //�κ��丮�� �̵�
    {
        UIManager.Instance.MainMenu.gameObject.SetActive(false);
        UIManager.Instance.Inventory.gameObject.SetActive(true);
    }

    public void SetCharacterInfo(Character character)
    {
        idText.text = $"{character.CharacterID}";
        lvText.text = $"Lv : {character.level}";
        moneyText.text = character.money.ToString();
    }
}
