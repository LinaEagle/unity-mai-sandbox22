using System.Collections;
using System.Collections.Generic;
using System.IO;
using Billiards;
using UnityEngine;

public class UserSettings : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private bool _loadOnStart = true;
    private static string _path;

    private const string ballKey = "BallKey";
    private const string ballDataKey = "BallDataKey";
    
    void Start()
    {
        if (_loadOnStart)
        {
            Load();
        }
        
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Debug.Log("Load");
        var isBallActive = PlayerPrefs.GetInt(ballKey, 1) == 1;
        _ball.transform.gameObject.SetActive(isBallActive);
    }

    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log("Save");
    }
    
    public static void SaveBallActivation(bool isActive)
    {
        PlayerPrefs.SetInt(ballKey, isActive ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void SaveBall(CueBall.Data data)
    {
        var text = JsonUtility.ToJson(data, true);
        /*PlayerPrefs.SetString(ballDataKey, text);
        PlayerPrefs.Save();*/
        _path = Application.persistentDataPath + "data.json";
        File.WriteAllText(_path, text);
        Debug.Log(_path);
    }

    public static CueBall.Data LoadBall()
    {
        if (PlayerPrefs.HasKey(ballDataKey))
        {
            /*var text = PlayerPrefs.GetString(ballDataKey);*/
            var text = File.ReadAllText(_path);
            var data = JsonUtility.FromJson<CueBall.Data>(text);
            return data;
        }
        else
        {
            return new CueBall.Data();
        }
    }
}
