using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; } //싱글톤

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField]
    private UIMainMenu uiMainMenu;
    [SerializeField]
    private UIStatus uiStatus;
    [SerializeField]
    private UIInventory uiInventory;

    public UIInventory Inventory => uiInventory; //접근자 (읽기만 가능)
    public UIStatus Status => uiStatus;
    public UIMainMenu MainMenu => uiMainMenu;

    /*[SerializeField]
    private GameObject UIMainStatus; //메인 화면의 Status 버튼
    [SerializeField]
    private GameObject UIMainInventory; //메인 화면의 Inventory 버튼

    [SerializeField]
    private GameObject StatusPopUp; //Status 화면(캐릭터 정보) 팝업
    [SerializeField]
    private GameObject InventoryPopUp; //Inventory 화면 팝업

    public void Status() //Status 버튼을 눌렀을 때 Status 화면으로 들어가도록
    {
        UIMainStatus.SetActive(false); //Status/Inventory 버튼을 끕니다.
        UIMainInventory.SetActive(false);

        StatusPopUp.SetActive(true); //캐릭터 정보 팝업을 켭니다.
    }

    public void UnStatus() //Status 버튼에서 뒤로가기 한 경우 (메인 화면으로 이동)
    {
        UIMainStatus.SetActive(true); //Status/Inventory 버튼을 켭니다.
        UIMainInventory.SetActive(true);

        StatusPopUp.SetActive(false); //캐릭터 정보 팝업을 끕니다.
    }

    public void Inventory() //Inventory 버튼을 눌렀을 때 Inventory 화면으로 들어가도록
    {
        UIMainInventory.SetActive(false); //Status/Inventory 버튼을 끕니다.
        UIMainStatus.SetActive(false);

        InventoryPopUp.SetActive(true); //인벤토리 팝업을 켭니다.
    }

    public void UnInventory()
    {
        UIMainStatus.SetActive(true); //Status/Inventory 버튼을 켭니다.
        UIMainInventory.SetActive(true);

        InventoryPopUp.SetActive(false); //인벤토리 팝업을 끕니다.
    }*/
}