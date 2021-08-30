using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
       private float startTime;

       public static bool keepTiming;
       public static float timer;
        public static float t;
        public static string platzhalterGesamteZeit;
        public bool gesehenModelle = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("timer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        StartTimer();
    }
    void Start()
        {
            
        }
    

        void UpdateTime()
        {
         
            
        }

    public void StopTimer()
        {
            keepTiming = false;
        TimeToString();
        Debug.Log("Die gesamte Zeit im Spiel beträgt " + platzhalterGesamteZeit);
            
        }

       public  void ResumeTimer()
        {
            keepTiming = true;
            startTime = Time.time - timer;
        }

       public  void StartTimer()
        {
            keepTiming = true;
            startTime = Time.time;
        }

    public void TimeToString()
        {   
            t= Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            platzhalterGesamteZeit = minutes + ":" + seconds;
        MapValuesToPlayer();
        }
    void MapValuesToPlayer()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        player.myStats.gesamteZeit = platzhalterGesamteZeit;
    }
}

