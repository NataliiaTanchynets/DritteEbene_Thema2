using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizKnopfHighlight : MonoBehaviour
{
    public GameObject progressKreis;
    readonly float ZeitBar = 4f;
    float Zeit;
    public SceneLoaderScript sceneLoad;
    private readonly float startZeit = 0f;
    private float realeZeit;

    public ModelleKnopf modelleKnopf;
    public TaktKnopfHighlight taktKnopfHighlight;

    //public float outlineDicke = 0.5f;
    //public float outlineDickeStart;
    //public Renderer rend;
    private Outline[] outline;
    public GameObject canvas;

    public TimerQuiz timer;



    void Start()
    {
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
        taktKnopfHighlight.UnaktivSetzen();
        modelleKnopf.UnaktivSetzen();
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
                timer.StartTimer();
                SceneManager.LoadScene(1);
                // boolean.updatestop = false;
                //QuizMenue.SetActive(true);
                // KnopfKontrolle.disabledHauptMenue = true;
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
