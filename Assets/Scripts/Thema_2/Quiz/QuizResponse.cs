using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizResponse : MonoBehaviour
{

    public bool gesehenModelle;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("timer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }
    void Start()
    {
          gesehenModelle = false;
    
    }

}
