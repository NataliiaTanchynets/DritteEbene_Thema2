using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaktKnopfHighlight : MonoBehaviour
{
    public GameObject progressKreis;
    float ZeitBar = 4f;
    float Zeit;

    public KorrekturRotation rotation;

    private float startZeit = 0f;
    private float realeZeit;

    public ErscheinenVerschwindenTakt abfrage;
    public GameObject TaktMenue;
    public AnimationPlayTakt animationStop;

    public ModelleKnopf modelleKnopf;
    public QuizKnopfHighlight quizknopfHighlight;

    //public float outlineDicke = 0.5f;
    //public float outlineDickeStart;
    //public Renderer rend;
    private Outline[] outline;
    public GameObject canvas;
    public TimeLineController controller;
    public GameObject sphere;
    public GameObject model;


    void Start()
    {
        sphere.SetActive(false);
        Zeit = ZeitBar;
        progressKreis.SetActive(false);
        //rend = GetComponentInChildren<Renderer>();
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;
            Debug.Log(o.name);


        }
        //GetComponent<Text>().text = varianteA[0];
    }

    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        modelleKnopf.UnaktivSetzen();
        quizknopfHighlight.UnaktivSetzen();
        //rend.material.SetFloat("_OutlineWidth", 0.5f);
        GetComponent<TextMeshProUGUI>().fontSize = 0.6f;
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pointer"))
        {
            progressKreis.SetActive(true);
            Zeit -= Time.deltaTime;
            progressKreis.GetComponentInChildren<Image>().fillAmount = Zeit / ZeitBar;
            realeZeit += Time.deltaTime;
            if (realeZeit > 4f)
            {
                model.SetActive(false);
                sphere.SetActive(true);
                abfrage.updatestop = false;
                TaktMenue.SetActive(true);
                //animationStop.PlayAnimTakt();
                //controller.Play();
                abfrage.taktMenue = true;
                rotation.erstePositionBestimmt = false;
                rotation.durchgeführt = false;
                rotation.ErstePositionBestimmen();
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        realeZeit = startZeit;
        progressKreis.SetActive(false);
        Zeit = ZeitBar;
        GetComponent<TextMeshProUGUI>().fontSize = 0.5f;

        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }

    }
    public void UnaktivSetzen()
    {
        realeZeit = startZeit;
        progressKreis.SetActive(false);
        Zeit = ZeitBar;
        GetComponent<TextMeshProUGUI>().fontSize = 0.5f;

        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
    }
}
