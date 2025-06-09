using TMPro;
using UnityEngine;
using System.IO;
using System;

public class PopupBank : MonoBehaviour
{
    public GameObject popUpWithdrawal; //입금 창
    public GameObject popUpDesposit; //출금 창
    public GameObject popupBank; //메인 창 입/출금 선택 버튼
    public GameObject popUpPay; //송금 창

    public TMP_InputField DepositInput; //출금 창 금액 입력 field
    public TMP_InputField WithdrawalInput; //입금 창 금액 입력 field

    public GameObject PopUp; //잔액 부족 팝업

    public GameObject Login; //로그인 팝업
    public GameObject BasicUI; //기본 화면 잔액 팝업

    public string inputID;
    public string inputPassword;

    [SerializeField]
    private TMP_InputField IdInputField; //로그인 팝업 ID 입력 field

    [SerializeField]
    private TMP_InputField passwordInputField; //로그인 팝업 PS 입력 field

    [SerializeField]
    private TMP_InputField signUpName; //회원가입 이름
    [SerializeField]
    private TMP_InputField signUpId; //회원가입 아이디
    [SerializeField]
    private TMP_InputField signUpPassword; //회원가입 비밀번호
    [SerializeField]
    private TMP_InputField signUpPasswordCheck; //회원가입 비밀번호 2차 확인

    public GameObject signUpPopUp; //회원가입 팝업
    public GameObject duplicationSignUp; //회원가입 중복 팝업

    [SerializeField]
    private GameObject warningName; //이름 빈칸 경고
    [SerializeField]
    private GameObject warningId; //아이디 빈칸 경고
    [SerializeField]
    private GameObject warningPassword; //비밀번호 빈칸 경고
    [SerializeField]
    private GameObject warningPasswordConfirn; //비밀번호 2차 확인 빈칸 경고

    public GameObject loginError; //로그인 에러창

    public TMP_InputField receiverIdInput; //송금보낼 아이디(상대방)
    public TMP_InputField receiverCountInput; //송금 보낼 금액
    public GameObject payError; //송금 에러창

    private void Awake() //시작할 때 
    {
        Login.SetActive(true); //로그인 화면을 띄웁니다.
    }

    public void Deposit() //출금창
    {
        popUpDesposit.SetActive(true); //출금창을 띄웁니다.
        popupBank.SetActive(false); //메인창을 끕니다.
    }

    public void Withdrawlal() //입금창
    {
        popUpWithdrawal.SetActive(true); //입금창을 띄웁니다.
        popupBank.SetActive(false); //메인창을 끕니다.
    }

    public void Pay() //송금창
    {
        popUpPay.SetActive(true);
        popupBank.SetActive(false);
    }

    public void Close() //메인창으로 돌아올 때
    {
        popupBank.SetActive(true); //메인 창을 띄웁니다.
        popUpDesposit.SetActive(false); //출금창을 끕니다.
        popUpWithdrawal.SetActive(false); //입금창을 끕니다.
        popUpPay.SetActive(false); //송금창을 끕니다.
    }

    public void DepositMoney(int value) //출금 계산
    {
        if (GameManager.Instance.userData.balance >= value) //잔액이 남아있다면
        {
            GameManager.Instance.userData.cash += value;
            GameManager.Instance.userData.balance -= value;
        }
        else
        {
            ShowPopUP(); //잔액 부족 화면을 띄웁니다.
        }
    }

    public void WithdrawalMoney(int value) //입금 계산
    {
        if (GameManager.Instance.userData.cash >= value) //현금이 남아있다면
        {
            GameManager.Instance.userData.cash -= value;
            GameManager.Instance.userData.balance += value;
        }
        else
        {
            ShowPopUP(); //잔액 부족 화면을 띄웁니다.
        }
    }

    public void InputMoney() //현금으로 바꿉니다.
    {
        if (int.TryParse(DepositInput.text, out int value)) //출금 입력창 field에서 입력한 값을 int값으로 바꿉니다
        {
            DepositMoney(value); //출금
        }
        else
        {
            ShowPopUP(); //잔액 부족 화면을 띄웁니다.
        }
    }

    public void OutputMoney() //잔액으로 바꿉니다.
    {
        if (int.TryParse(WithdrawalInput.text, out int value)) //입금 입력창 field에서 입력한 값을 int값으로 바꿉니다.
        {
            WithdrawalMoney(value); //입금
        }
        else
        {
            ShowPopUP(); //잔액 부족 화면을 띄웁니다.
        }
    }

    public void ShowPopUP() //잔액 부족 화면 띄울 때
    {
        PopUp.SetActive(true); //잔액 부족 팝업
    }
    public void HidePopUP() //잔액 부족 화면 끌 때
    {
        PopUp.SetActive(false); //잔액 부족 팝업
    }

    public void GetInputId() //사용자가 입력한 아이디 값을 아이디변수에 넣습니다.
    {
        inputID = IdInputField.text; //로그인 Input field의 입력 글을 inputID에 넣습니다.
    }
    public void GetInputPassword() //사용자가 입력한 비밀번호 값을 비밀번호변수에 넣습니다.
    {
        inputPassword = passwordInputField.text; //로그인 input field의 입력 글을 inputPassword에 넣습니다.
    }

    public void UnShowLogin()
    {
        GetInputId(); //사용자가 입력한 아이디 값을 아이디 변수에 넣습니다.
        GetInputPassword(); //사용자가 입력한 비밀번호 값을 비밀번호 변수에 넣습니다.

        Debug.Log("UnShowLogin 호출. 입력 ID : " + inputID);
        UserData loadData = GameManager.Instance.LoadUserInfo(inputID); //inputId라는 문자열을 인자로 갖는 GameManager의 LoadUserInfo()함수를 호출하고, Userdata 객체를 loadData에 저장.

        if (loadData == null)
        {
            Debug.Log("loadData Null");
            return;
        }
        if (inputID == loadData.ID && inputPassword == loadData.Password) //만약 아이디와 비밀번호가 일치하다면,
        {
            Debug.Log("아이디와 비밀번호가 일치합니다.");
            GameManager.Instance.userData = loadData; //GameManager의 userdata에 loadData를 저장

            Login.SetActive(false); //로그인 팝업 끄고,
            popupBank.SetActive(true); //메인 창 버튼 켜고,
            BasicUI.SetActive(true); //기본 화면 잔액 팝업 켜고,
            popUpDesposit.SetActive(false); //출금 창 끄고,
            popUpWithdrawal.SetActive(false); //입금 창 끄고,
            PopUp.SetActive(false); //잔액 부족 팝업을 끕니다.
        }
        else
        {
            Debug.Log("아이디 비밀번호가 불일치합니다.");
            loginError.SetActive(true);
        }
    }

    public void OnClickSignUp()//회원가입 함수
    {

        string name = signUpName.text;
        string id = signUpId.text;
        string password = signUpPassword.text;
        string passwordCheck = signUpPasswordCheck.text;

        warningId.SetActive(false); //아이디 경고 창 끄기
        warningPassword.SetActive(false); //비밀번호 경고 창 끄기
        warningPasswordConfirn.SetActive(false); //비밀번호 2차 확인 경고 창 끄기
        warningName.SetActive(false); //이름 경고 창 끄기

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
            Debug.Log("이미 존재하는 ID입니당");

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

        Debug.Log("회원가입 되었습니당 " + id);

        signUpPopUp.SetActive(false);
    }

    public void OnClickTransfer()
    {
        string receiverId = receiverIdInput.text;
        string amountText = receiverCountInput.text;

        if(string.IsNullOrEmpty(receiverId) || string.IsNullOrEmpty(amountText)) //빈칸이 있는 경우
        {
            payError.SetActive(true); //에러 창을 띄웁니다.
        }

        if(!int.TryParse(amountText, out int amount) || amount <= 0) //송금액이 0이하인 경우
        {
            payError.SetActive(true); //에러창을 띄웁니다.
        }

        if(receiverId == GameManager.Instance.userData.ID)
        {
            payError.SetActive(true);
        }

        bool success = GameManager.Instance.TransferMoney(receiverId, amount);

        if (success)
        {
            Debug.Log("송금 완료~");
        }
        else
        {
            Debug.Log("송금 실패ㅠㅠ");
        }
    }
}