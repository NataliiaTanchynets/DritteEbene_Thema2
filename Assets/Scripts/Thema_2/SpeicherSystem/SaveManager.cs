using UnityEngine;
using System.IO;
using System.Collections.Generic;


public class SaveManager : MonoBehaviour
{
    private string path;
    private Player _player;

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }


    public void Save()
    {
        path = Application.persistentDataPath + "/DritteEbene_Thema_2_VPInfo.txt";

        string jsonString = JsonUtility.ToJson(_player);

        if (!File.Exists(path))
        {

            using (StreamWriter streamWriter = File.CreateText(path))
            {

                streamWriter.WriteLine(jsonString);
            }
            //var Person = new Player();
            // File.AppendAllText(path, player.myStats.ToString());

        }


        using (StreamWriter streamWriter = File.AppendText(path))
        {

            streamWriter.WriteLine(jsonString);
        }

    }
}


