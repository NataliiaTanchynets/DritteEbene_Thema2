using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorrekturRotation : MonoBehaviour
{
    
    public GameObject pointer;
    public bool durchgeführt=false;
    public float actualRotation;
    public bool erstePositionBestimmt = false;
    public float erstePosition;
    
    public void Start ()
    {

        pointer.SetActive(false);
    } 
  public void Update()
    {
        actualRotation = transform.eulerAngles.y;
        //print("Rotation beträgt" +actualRotation);
        
        if ((actualRotation>erstePosition+30f | actualRotation < erstePosition-30f) && durchgeführt==false && erstePositionBestimmt==true)
        {
            print("Rotation beträgt" +actualRotation);
            pointer.SetActive(true);
            durchgeführt = true;
        }
        else
        {
            //pointer.SetActive(false);
        }
    
    }
    public void ErstePositionBestimmen()
    {
        if (erstePositionBestimmt == false)
        {
            pointer.SetActive(false);
            erstePositionBestimmt = true;
            erstePosition= transform.eulerAngles.y;
            print("Erste Position beträgt" + erstePosition);
        }

    }

    public void InforamtionLöschen()
    {
        pointer.SetActive(false);
        erstePositionBestimmt = false;
        durchgeführt = false;

    }

}
