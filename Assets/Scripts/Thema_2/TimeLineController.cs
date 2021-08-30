using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{

    public List<PlayableDirector> playabledirectors;
   
   public void Play()
    {
        print("Ich bin in TimeLineController");
        foreach(PlayableDirector playabledirector in playabledirectors)
        {
            playabledirector.Play();
        }
    }

    public void Pause()
    {

        foreach (PlayableDirector playabledirector in playabledirectors)
        {
            playabledirector.Pause();
        }
    }
    public void Resume()
    {

        foreach (PlayableDirector playabledirector in playabledirectors)
        {
            playabledirector.Resume();
        }
    }

}
