using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button StatusButton; //메인화면의 스테이터스 버튼
    [SerializeField]
    private Button InventoryButtton; //메인화면의 인벤토리 버튼

    [SerializeField]
    private TextMeshProUGUI idText; //플레이어 아이디
    [SerializeField]
    private TextMeshProUGUI moneyText; //플레이어 자금
    [SerializeField]
    private TextMeshProUGUI lvText; //플레이어 레벨

    public void Start()
    {
        StatusButton.onClick.AddListener(OpenStatus);
        InventoryButtton.onClick.AddListener(OpenInventory);
    }

    public void OpenMainMenu() //메인화면으로 이동
    {
        UIManager.Instance.MainMenu.gameObject.SetActive(true);
        UIManager.Instance.Status.gameObject.SetActive(false);
        UIManager.Instance.Inventory.gameObject.SetActive(false);
    }

    public void OpenStatus() //스테이터스로 이동
    {
        UIManager.Instance.MainMenu.gameObject.SetActive(false);
        UIManager.Instance.Status.gameObject.SetActive(true);
    }

    public void OpenInventory() //인벤토리로 이동
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
