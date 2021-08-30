using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseAnimationTakt : MonoBehaviour
{
    public AnimationPlayTakt animationStop;
    private Outline[] outline;
    public GameObject canvas;
    public WeiterspielenAnimTakt weiterspielenAnimTakt;
    public ZurückKnopfTakt zurückKnopfTakt;

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
        weiterspielenAnimTakt.UnaktivSetzen();
        zurückKnopfTakt.UnaktivSetzen();

        //rend.material.SetFloat("_OutlineWidth", 0.5f);
        GetComponent<TextMeshProUGUI>().fontSize = 0.55f;
        outline = canvas.GetComponentsInChildren<Outline>();
        foreach (Outline o in outline)
        {
            o.enabled = true;
        }

        animationStop.PauseAnimTakt();
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
