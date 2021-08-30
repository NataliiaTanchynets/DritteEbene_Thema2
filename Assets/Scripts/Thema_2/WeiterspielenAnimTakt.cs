using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class WeiterspielenAnimTakt : MonoBehaviour
{
    public Animator anim;
    public PlayableDirector playableDirector;
    public GameObject animierteObjekte;
    public AnimationPlayTakt animationStop;
    public TimeLineController timeLineController;
    private Outline[] outline;
    public GameObject canvas;
    //public TimeLineController controller;
    public ZurückKnopfTakt zurückKnopfTakt;
    public PauseAnimationTakt pauseAnimationTakt;

    public bool animAnfang = false;

    void Start()
    {
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;
            Debug.Log(o.name);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        pauseAnimationTakt.UnaktivSetzen();
        zurückKnopfTakt.UnaktivSetzen();
        //rend.material.SetFloat("_OutlineWidth", 0.5f);
        GetComponent<TextMeshProUGUI>().fontSize = 0.55f;
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = true;
        }
        if (animAnfang == false)
        {
            anim.enabled = true;
            playableDirector.enabled = true;
            timeLineController.Play();
            animAnfang = true;
            animierteObjekte.SetActive(true);
        }
        else if (animAnfang == true)
        {
            animationStop.ResumeAnimTakt();
            timeLineController.Resume();
        }

        //animationStop.ResumeAnimTakt();
       
    }
    public void OnTriggerExit(Collider other)
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.4f;

        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }

    }
    public void UnaktivSetzen()
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.4f;

        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
    }
}
