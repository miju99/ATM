using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; } //�̱���

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

    public UIInventory Inventory => uiInventory; //������ (�б⸸ ����)
    public UIStatus Status => uiStatus;
    public UIMainMenu MainMenu => uiMainMenu;

    /*[SerializeField]
    private GameObject UIMainStatus; //���� ȭ���� Status ��ư
    [SerializeField]
    private GameObject UIMainInventory; //���� ȭ���� Inventory ��ư

    [SerializeField]
    private GameObject StatusPopUp; //Status ȭ��(ĳ���� ����) �˾�
    [SerializeField]
    private GameObject InventoryPopUp; //Inventory ȭ�� �˾�

    public void Status() //Status ��ư�� ������ �� Status ȭ������ ������
    {
        UIMainStatus.SetActive(false); //Status/Inventory ��ư�� ���ϴ�.
        UIMainInventory.SetActive(false);

        StatusPopUp.SetActive(true); //ĳ���� ���� �˾��� �մϴ�.
    }

    public void UnStatus() //Status ��ư���� �ڷΰ��� �� ��� (���� ȭ������ �̵�)
    {
        UIMainStatus.SetActive(true); //Status/Inventory ��ư�� �մϴ�.
        UIMainInventory.SetActive(true);

        StatusPopUp.SetActive(false); //ĳ���� ���� �˾��� ���ϴ�.
    }

    public void Inventory() //Inventory ��ư�� ������ �� Inventory ȭ������ ������
    {
        UIMainInventory.SetActive(false); //Status/Inventory ��ư�� ���ϴ�.
        UIMainStatus.SetActive(false);

        InventoryPopUp.SetActive(true); //�κ��丮 �˾��� �մϴ�.
    }

    public void UnInventory()
    {
        UIMainStatus.SetActive(true); //Status/Inventory ��ư�� �մϴ�.
        UIMainInventory.SetActive(true);

        InventoryPopUp.SetActive(false); //�κ��丮 �˾��� ���ϴ�.
    }*/
}