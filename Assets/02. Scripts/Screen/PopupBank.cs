using TMPro;
using UnityEngine;
using System.IO;
using System;

public class PopupBank : MonoBehaviour
{
    public GameObject popUpWithdrawal; //�Ա� â
    public GameObject popUpDesposit; //��� â
    public GameObject popupBank; //���� â ��/��� ���� ��ư
    public GameObject popUpPay; //�۱� â

    public TMP_InputField DepositInput; //��� â �ݾ� �Է� field
    public TMP_InputField WithdrawalInput; //�Ա� â �ݾ� �Է� field

    public GameObject PopUp; //�ܾ� ���� �˾�

    public GameObject Login; //�α��� �˾�
    public GameObject BasicUI; //�⺻ ȭ�� �ܾ� �˾�

    public string inputID;
    public string inputPassword;

    [SerializeField]
    private TMP_InputField IdInputField; //�α��� �˾� ID �Է� field

    [SerializeField]
    private TMP_InputField passwordInputField; //�α��� �˾� PS �Է� field

    [SerializeField]
    private TMP_InputField signUpName; //ȸ������ �̸�
    [SerializeField]
    private TMP_InputField signUpId; //ȸ������ ���̵�
    [SerializeField]
    private TMP_InputField signUpPassword; //ȸ������ ��й�ȣ
    [SerializeField]
    private TMP_InputField signUpPasswordCheck; //ȸ������ ��й�ȣ 2�� Ȯ��

    public GameObject signUpPopUp; //ȸ������ �˾�
    public GameObject duplicationSignUp; //ȸ������ �ߺ� �˾�

    [SerializeField]
    private GameObject warningName; //�̸� ��ĭ ���
    [SerializeField]
    private GameObject warningId; //���̵� ��ĭ ���
    [SerializeField]
    private GameObject warningPassword; //��й�ȣ ��ĭ ���
    [SerializeField]
    private GameObject warningPasswordConfirn; //��й�ȣ 2�� Ȯ�� ��ĭ ���

    public GameObject loginError; //�α��� ����â

    public TMP_InputField receiverIdInput; //�۱ݺ��� ���̵�(����)
    public TMP_InputField receiverCountInput; //�۱� ���� �ݾ�
    public GameObject payError; //�۱� ����â

    private void Awake() //������ �� 
    {
        Login.SetActive(true); //�α��� ȭ���� ���ϴ�.
    }

    public void Deposit() //���â
    {
        popUpDesposit.SetActive(true); //���â�� ���ϴ�.
        popupBank.SetActive(false); //����â�� ���ϴ�.
    }

    public void Withdrawlal() //�Ա�â
    {
        popUpWithdrawal.SetActive(true); //�Ա�â�� ���ϴ�.
        popupBank.SetActive(false); //����â�� ���ϴ�.
    }

    public void Pay() //�۱�â
    {
        popUpPay.SetActive(true);
        popupBank.SetActive(false);
    }

    public void Close() //����â���� ���ƿ� ��
    {
        popupBank.SetActive(true); //���� â�� ���ϴ�.
        popUpDesposit.SetActive(false); //���â�� ���ϴ�.
        popUpWithdrawal.SetActive(false); //�Ա�â�� ���ϴ�.
        popUpPay.SetActive(false); //�۱�â�� ���ϴ�.
    }

    public void DepositMoney(int value) //��� ���
    {
        if (GameManager.Instance.userData.balance >= value) //�ܾ��� �����ִٸ�
        {
            GameManager.Instance.userData.cash += value;
            GameManager.Instance.userData.balance -= value;
        }
        else
        {
            ShowPopUP(); //�ܾ� ���� ȭ���� ���ϴ�.
        }
    }

    public void WithdrawalMoney(int value) //�Ա� ���
    {
        if (GameManager.Instance.userData.cash >= value) //������ �����ִٸ�
        {
            GameManager.Instance.userData.cash -= value;
            GameManager.Instance.userData.balance += value;
        }
        else
        {
            ShowPopUP(); //�ܾ� ���� ȭ���� ���ϴ�.
        }
    }

    public void InputMoney() //�������� �ٲߴϴ�.
    {
        if (int.TryParse(DepositInput.text, out int value)) //��� �Է�â field���� �Է��� ���� int������ �ٲߴϴ�
        {
            DepositMoney(value); //���
        }
        else
        {
            ShowPopUP(); //�ܾ� ���� ȭ���� ���ϴ�.
        }
    }

    public void OutputMoney() //�ܾ����� �ٲߴϴ�.
    {
        if (int.TryParse(WithdrawalInput.text, out int value)) //�Ա� �Է�â field���� �Է��� ���� int������ �ٲߴϴ�.
        {
            WithdrawalMoney(value); //�Ա�
        }
        else
        {
            ShowPopUP(); //�ܾ� ���� ȭ���� ���ϴ�.
        }
    }

    public void ShowPopUP() //�ܾ� ���� ȭ�� ��� ��
    {
        PopUp.SetActive(true); //�ܾ� ���� �˾�
    }
    public void HidePopUP() //�ܾ� ���� ȭ�� �� ��
    {
        PopUp.SetActive(false); //�ܾ� ���� �˾�
    }

    public void GetInputId() //����ڰ� �Է��� ���̵� ���� ���̵𺯼��� �ֽ��ϴ�.
    {
        inputID = IdInputField.text; //�α��� Input field�� �Է� ���� inputID�� �ֽ��ϴ�.
    }
    public void GetInputPassword() //����ڰ� �Է��� ��й�ȣ ���� ��й�ȣ������ �ֽ��ϴ�.
    {
        inputPassword = passwordInputField.text; //�α��� input field�� �Է� ���� inputPassword�� �ֽ��ϴ�.
    }

    public void UnShowLogin()
    {
        GetInputId(); //����ڰ� �Է��� ���̵� ���� ���̵� ������ �ֽ��ϴ�.
        GetInputPassword(); //����ڰ� �Է��� ��й�ȣ ���� ��й�ȣ ������ �ֽ��ϴ�.

        Debug.Log("UnShowLogin ȣ��. �Է� ID : " + inputID);
        UserData loadData = GameManager.Instance.LoadUserInfo(inputID); //inputId��� ���ڿ��� ���ڷ� ���� GameManager�� LoadUserInfo()�Լ��� ȣ���ϰ�, Userdata ��ü�� loadData�� ����.

        if (loadData == null)
        {
            Debug.Log("loadData Null");
            return;
        }
        if (inputID == loadData.ID && inputPassword == loadData.Password) //���� ���̵�� ��й�ȣ�� ��ġ�ϴٸ�,
        {
            Debug.Log("���̵�� ��й�ȣ�� ��ġ�մϴ�.");
            GameManager.Instance.userData = loadData; //GameManager�� userdata�� loadData�� ����

            Login.SetActive(false); //�α��� �˾� ����,
            popupBank.SetActive(true); //���� â ��ư �Ѱ�,
            BasicUI.SetActive(true); //�⺻ ȭ�� �ܾ� �˾� �Ѱ�,
            popUpDesposit.SetActive(false); //��� â ����,
            popUpWithdrawal.SetActive(false); //�Ա� â ����,
            PopUp.SetActive(false); //�ܾ� ���� �˾��� ���ϴ�.
        }
        else
        {
            Debug.Log("���̵� ��й�ȣ�� ����ġ�մϴ�.");
            loginError.SetActive(true);
        }
    }

    public void OnClickSignUp()//ȸ������ �Լ�
    {

        string name = signUpName.text;
        string id = signUpId.text;
        string password = signUpPassword.text;
        string passwordCheck = signUpPasswordCheck.text;

        warningId.SetActive(false); //���̵� ��� â ����
        warningPassword.SetActive(false); //��й�ȣ ��� â ����
        warningPasswordConfirn.SetActive(false); //��й�ȣ 2�� Ȯ�� ��� â ����
        warningName.SetActive(false); //�̸� ��� â ����

        if (string.IsNullOrEmpty(id))
        {
            warningId.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(name))
        {
            warningName.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            warningPassword.SetActive(true);
            return;
        }
        if (string.IsNullOrEmpty(passwordCheck))
        {
            warningPasswordConfirn.SetActive(true);
            return;
        }
        string filePath = Application.persistentDataPath + "/saves/" + id + ".json";
        if (File.Exists(filePath))
        {
            Debug.Log("�̹� �����ϴ� ID�Դϴ�");

            /*if (string.IsNullOrWhiteSpace(name))
            {
                warningName.SetActive(true);
                return;
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                warningId.SetActive(true);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                warningPassword.SetActive(true);
                return;
            }
            if (string.IsNullOrWhiteSpace(passwordCheck))
            {
                warningPasswordConfirn.SetActive(true);
                return;
            }*/

            duplicationSignUp.SetActive(true);
            return;
        }
        GameManager.Instance.userData = new UserData(name, 100000, 50000, id, password);
        GameManager.Instance.SaveUserInfo(id);

        Debug.Log("ȸ������ �Ǿ����ϴ� " + id);

        signUpPopUp.SetActive(false);
    }

    public void OnClickTransfer()
    {
        string receiverId = receiverIdInput.text;
        string amountText = receiverCountInput.text;

        if(string.IsNullOrEmpty(receiverId) || string.IsNullOrEmpty(amountText)) //��ĭ�� �ִ� ���
        {
            payError.SetActive(true); //���� â�� ���ϴ�.
        }

        if(!int.TryParse(amountText, out int amount) || amount <= 0) //�۱ݾ��� 0������ ���
        {
            payError.SetActive(true); //����â�� ���ϴ�.
        }

        if(receiverId == GameManager.Instance.userData.ID)
        {
            payError.SetActive(true);
        }

        bool success = GameManager.Instance.TransferMoney(receiverId, amount);

        if (success)
        {
            Debug.Log("�۱� �Ϸ�~");
        }
        else
        {
            Debug.Log("�۱� ���ФФ�");
        }
    }
}