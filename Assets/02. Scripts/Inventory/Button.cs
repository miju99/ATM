using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject StatusButton; //���� ȭ���� Status ��ư
    public GameObject InventoryButton; //���� ȭ���� Inventory ��ư

    public GameObject StatusPopUp; //Status ȭ��(ĳ���� ����) �˾�

    public void Status() //Status ��ư�� ������ �� Status ȭ������ ������
    {
        StatusButton.SetActive(false); //StatusButton�� ���ϴ�.
        InventoryButton.SetActive(false); //InventoryButton�� ���ϴ�.

        StatusPopUp.SetActive(true); //ĳ���� ���� �˾��� �մϴ�.
    }

    public void UnStatus() //Status ��ư���� �ڷΰ��� �� ��� (���� ȭ������ �̵�)
    {
        StatusButton.SetActive(true);
        InventoryButton.SetActive(true);

        StatusPopUp.SetActive(false);
    }
}
