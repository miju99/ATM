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

    public GameObject loginError; //�α��� ����(������ ���� ���)â
    public GameObject payError; //�۱� ����â

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
            userData = new UserData("����", 3000, 30000, "qwer", "1234");
        }
    }

    private string SavePath => Application.persistentDataPath + "/saves/";// ���
    
    public void SaveUserInfo(string saveFileName)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
            Debug.Log("����� ������ ���� �����ϱ� ����Կ�");
        }
        string json = JsonUtility.ToJson(userData); //Json���Ͽ� userData�� ���ٴ� ��!

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
            Debug.Log("����� ������ ã�� ���߾��");
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

        if (!File.Exists(targetPath) || userData.balance < amount) //�۱� ������� ������ ���ų�, �ܾ��� ������ ���
        {
            Debug.Log("�˾�â ���ϴ�");
            payError.SetActive(true); //���â�� ���ϴ�.
            return false;
        }

        //������ �����͸� �����ɴϴ�.
        string targetJson = File.ReadAllText(targetPath);
        UserData targetData = JsonUtility.FromJson<UserData>(targetJson);

        userData.balance -= amount; //�� �� ����
        targetData.balance += amount; //���� �� ����

        SaveUserInfo(userData.ID); //����� �ܾ� ����
        string updatedTargetJson = JsonUtility.ToJson(targetData);
        File.WriteAllText(targetPath, updatedTargetJson);

        Debug.Log($"���������� {targetID}���� {amount}���� �۱��߽��ϴ�~");
   
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
        string Name = PlayerPrefs.GetString("Name", "����");
        int Balance = PlayerPrefs.GetInt("Balance", 3000);
        int Cash = PlayerPrefs.GetInt("Cash", 30000);

        userData = new UserData(Name, Balance, Cash);
    }

    private void OnApplicationQuit()
    {
        SaveUserData();
    }*/
}