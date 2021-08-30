using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModelleKnopf : MonoBehaviour
{
    public GameObject pointer;
    private Outline[] outline;
    public GameObject Model;
    public GameObject UnterMenueCanvas;
    public TaktKnopfHighlight taktKnopfHighlight;
    public QuizKnopfHighlight quizknopfHighlight;
    // Start is called before the first frame update
    void Start()
    {
        Model.SetActive(false);
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;
            Debug.Log(o.name);


        }

    }

    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        taktKnopfHighlight.UnaktivSetzen();
        quizknopfHighlight.UnaktivSetzen();
        //rend.material.SetFloat("_OutlineWidth", 0.5f);
        GetComponent<TextMeshProUGUI>().fontSize = 0.55f;
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = true;
        }

        Model.SetActive(true);
        BoxColliderManager.quizinteraktiv2 = true;

    }
    public void OnTriggerExit(Collider other)
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.5f;
        Model.SetActive(false);
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }

    }
    public void UnaktivSetzen()
    {
        GetComponent<TextMeshProUGUI>().fontSize = 0.5f;
        Model.SetActive(false);
        outline = UnterMenueCanvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = false;

        }
    }

}
