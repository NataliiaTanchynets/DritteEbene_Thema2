using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class ZurückKnopfTakt : MonoBehaviour
{
    // public GameObject pointer;
    private Outline[] outline;
    public GameObject UnterMenueCanvas;
    private float startZeit = 0f;
    private float realeZeit;
    public ErscheinenVerschwindenTakt boolean;
    public WeiterspielenAnimTakt weiterspielenAnimTakt;
    public PauseAnimationTakt pauseAnimationTakt;


    public GameObject progressKreis;
    float ZeitBar = 4f;
    float Zeit;


    void Start()
    {
        Zeit = ZeitBar;
        progressKreis.SetActive(false);
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;
            Debug.Log(o.name);

            Debug.Log("Kollider funktioniert");
        }

    }

    //private void OnTriggerEnter(Collider coll){


    //if (coll.gameObject.CompareTag("Zurück")) {
    public void OnTriggerEnter(Collider other)
    {
        weiterspielenAnimTakt.UnaktivSetzen();
        pauseAnimationTakt.UnaktivSetzen();
        //rend.material.SetFloat("_OutlineWidth", 0.5f);
        GetComponent<TextMeshProUGUI>().fontSize = 0.55f;
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = true;

            Debug.Log("Kollider funktioniert");
        }
    }

    //public void OnTriggerStay(Collider coll){
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pointer"))
        {

            progressKreis.SetActive(true);
            Zeit -= Time.deltaTime;
            progressKreis.GetComponent<Image>().fillAmount = Zeit / ZeitBar;
            realeZeit += Time.deltaTime;
            if (realeZeit > 4f)
            {
                BoxColliderManager.quizinteraktiv1 = true;
                SceneManager.LoadScene(0);
                boolean.taktMenue = false;
                // KnopfKontrolle.disabledModellMenue = true;
                // KnopfKontrolle.disabledHauptMenue = false;
                // boolean.updatestop = true;
            }
        }


    }
    void OnTriggerExit(Collider other)
    {
        realeZeit = startZeit;
        progressKreis.SetActive(false);
        GetComponent<TextMeshProUGUI>().fontSize = 0.4f;
        realeZeit = startZeit;
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
    }
    public void UnaktivSetzen()
    {
        realeZeit = startZeit;
        progressKreis.SetActive(false);
        GetComponent<TextMeshProUGUI>().fontSize = 0.4f;
        realeZeit = startZeit;
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
    }
}
