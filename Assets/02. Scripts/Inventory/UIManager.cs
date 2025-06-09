using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UIMainStatus; //���� ȭ���� Status ��ư
    public GameObject UIMainInventory; //���� ȭ���� Inventory ��ư

    public GameObject StatusPopUp; //Status ȭ��(ĳ���� ����) �˾�
    public GameObject InventoryPopUp; //Inventory ȭ�� �˾�

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
    }
}
