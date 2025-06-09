using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject StatusButton; //메인 화면의 Status 버튼
    public GameObject InventoryButton; //메인 화면의 Inventory 버튼

    public GameObject StatusPopUp; //Status 화면(캐릭터 정보) 팝업

    public void Status() //Status 버튼을 눌렀을 때 Status 화면으로 들어가도록
    {
        StatusButton.SetActive(false); //StatusButton을 끕니다.
        InventoryButton.SetActive(false); //InventoryButton을 끕니다.

        StatusPopUp.SetActive(true); //캐릭터 정보 팝업을 켭니다.
    }

    public void UnStatus() //Status 버튼에서 뒤로가기 한 경우 (메인 화면으로 이동)
    {
        StatusButton.SetActive(true);
        InventoryButton.SetActive(true);

        StatusPopUp.SetActive(false);
    }
}
