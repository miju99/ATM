using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI CashCount;
    public TextMeshProUGUI BalanceCount;

    public TextMeshProUGUI IDInfo;
    public TextMeshProUGUI PasswordInfo;

    public string userName;
    public int cash; //= 100000;
    public int balance; //= 50000;
    /*public string id;
    public string password;*/

    string FormatCount(int value)
    {
        return value.ToString("N0");
    }

    private void Start()
    {
        userName = GameManager.Instance.userData.name;
        cash = GameManager.Instance.userData.cash;
        balance = GameManager.Instance.userData.balance;
        /*id = GameManager.Instance.userData.ID;
        password = GameManager.Instance.userData.Password;*/
    }

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        Name.text = GameManager.Instance.userData.name;
        CashCount.text = FormatCount(GameManager.Instance.userData.cash);
        BalanceCount.text = FormatCount(GameManager.Instance.userData.balance);
        /*IDInfo.text = GameManager.Instance.userData.ID;
        PasswordInfo.text = GameManager.Instance.userData.Password;*/
    }
}