using UnityEngine;
using System.IO;

[System.Serializable]
public class UserData
{
    public string name;
    public int balance;
    public int cash;
    public string ID;
    public string Password;

    public UserData(string _name, int _balance, int _cash, string _id, string _password)
    {
        name = _name;
        balance = _balance;
        cash = _cash;
        ID = _id;
        Password = _password;
    }
}

public class GameManager : MonoBehaviour
{

    public GameObject loginError; //로그인 에러(정보가 없는 경우)창
    public GameObject payError; //송금 에러창

    public static GameManager Instance { get; private set; }
    public UserData userData;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        //userData = new UserData(userData.name, userData.balance, userData.cash);
        //LoadUserData();
        //userData = LoadUserInfo();

        if(userData == null)
        {
            userData = new UserData("미주", 3000, 30000, "qwer", "1234");
        }
    }

    private string SavePath => Application.persistentDataPath + "/saves/";// 경로
    
    public void SaveUserInfo(string saveFileName)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
            Debug.Log("저장된 파일이 아직 없으니까 만들게용");
        }
        string json = JsonUtility.ToJson(userData); //Json파일에 userData를 쓴다는 뜻!

        string saveFilePath = SavePath + saveFileName + ".json";
        File.WriteAllText(saveFilePath, json);

        //PlayerPrefs.SetString(SaveKey, json);
        /*PlayerPrefs.SetString("ID/Name", json);
        PlayerPrefs.Save();*/
    }

    public UserData LoadUserInfo(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("저장된 파일을 찾지 못했어용");
            loginError.SetActive(true);
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        UserData userdata = JsonUtility.FromJson<UserData>(saveFile);
        return userdata;

            /*if (PlayerPrefs.HasKey(SaveKey))
            {
                string json = PlayerPrefs.GetString("ID/PassWord");
                return JsonUtility.FromJson<UserData>(json);
            }*/
            //return null;
    }

    public void OnApplicationQuit()
    {
        SaveUserInfo("UserData");
    }

    public bool TransferMoney(string targetID, int amount)
    {
        string targetPath = SavePath + targetID + ".json";

        if (!File.Exists(targetPath) || userData.balance < amount) //송금 대상자의 정보가 없거나, 잔액이 부족한 경우
        {
            Debug.Log("팝업창 띄웁니다");
            payError.SetActive(true); //경고창을 띄웁니다.
            return false;
        }

        //상대방의 데이터를 가져옵니다.
        string targetJson = File.ReadAllText(targetPath);
        UserData targetData = JsonUtility.FromJson<UserData>(targetJson);

        userData.balance -= amount; //내 돈 차감
        targetData.balance += amount; //상대방 돈 증가

        SaveUserInfo(userData.ID); //변경된 잔액 저장
        string updatedTargetJson = JsonUtility.ToJson(targetData);
        File.WriteAllText(targetPath, updatedTargetJson);

        Debug.Log($"성공적으로 {targetID}에게 {amount}원을 송금했습니당~");
   
        return true;
    }

    /*public void SaveUserData()
    {
        PlayerPrefs.SetString("Name", userData.name);
        PlayerPrefs.SetInt("Balance", userData.balance);
        PlayerPrefs.SetInt("Cash", userData.cash);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        string Name = PlayerPrefs.GetString("Name", "미주");
        int Balance = PlayerPrefs.GetInt("Balance", 3000);
        int Cash = PlayerPrefs.GetInt("Cash", 30000);

        userData = new UserData(Name, Balance, Cash);
    }

    private void OnApplicationQuit()
    {
        SaveUserData();
    }*/
}