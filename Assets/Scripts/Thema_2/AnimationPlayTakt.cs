using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class AnimationPlayTakt : MonoBehaviour
{
    Animator anim;
    public Transform takt;

    public TimeLineController controller;
    // Start is called before the first frame update
    void Start()
    {
        anim = takt.GetComponent<Animator>();
    }

    public void PlayAnimTakt()
    {

        anim.Play("TaktMotor", -1, 0f);
        print("Animation soll anfagen zu spielen");
    }

    public void PauseAnimTakt()
    {
        anim.speed = 0;
        controller.Pause();
    }

    public void ResumeAnimTakt()
    {
        anim.speed = 1;
        controller.Resume();
    }
}
