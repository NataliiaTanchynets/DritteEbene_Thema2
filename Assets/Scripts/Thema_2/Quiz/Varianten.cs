using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Varianten : MonoBehaviour
{
    public GameObject[] knopfHighlights;
    public bool wiederholen= false;
    private float realeZeit;
    public QuizGame QuizGame;
    private float Startzeit= 0;
    public int currentIndex;
    public int ind;
    private Outline[] outline;
    public GameObject canvas;
    public GameObject progressKreis;
    float ZeitBar = 4f;
    float Zeit;
    void Start()
    {
        Zeit = ZeitBar;
        progressKreis.SetActive(false);
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;
            Debug.Log(o.name);

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        foreach (GameObject knopf in knopfHighlights)
        {
            knopf.GetComponent<Varianten>().UnaktivSetzen();

        }
        //rend.material.SetFloat("_OutlineWidth", 0.5f);

        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.5f;
        Debug.Log("Ich bin OnTriggerStay");
        if (other.gameObject.CompareTag("pointer"))
        {


        }
        progressKreis.SetActive(true);
        Zeit -= Time.deltaTime;
        progressKreis.GetComponentInChildren<Image>().fillAmount = Zeit / ZeitBar;
        Debug.Log("Pointer zeigt auf etwas anderes");
        realeZeit += Time.deltaTime;
        if (realeZeit > 4f & wiederholen == false)
        {
            for (int i = 0; i < QuizGame.boxCollider.Length; i++)
            {
                if (GetComponent<Collider> () == QuizGame.boxCollider[i])
                {
                    ind = i;
                    print("Die Index lauetet " + ind);
                }
            }

            Debug.Log("Das funktioniert");

            QuizGame.Prüfung(ind);
            wiederholen = true;
            //realeZeit = Startzeit;


        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.4f;
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
        wiederholen = false;
        realeZeit = Startzeit;
        progressKreis.SetActive(false);
        Zeit = ZeitBar;
    }
    public void UnaktivSetzen()
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.4f;
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
        wiederholen = false;
        realeZeit = Startzeit;
        progressKreis.SetActive(false);
        Zeit = ZeitBar;
    }
}
 //& wiederholen == false