using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    public GameObject pointer;
    public KorrekturRotation rotation;
    // Start is called before the first frame update
    void Awake()
    {
        print("Awake funktioniert");
        pointer.SetActive(false);
        rotation.erstePositionBestimmt = false;
        rotation.durchgeführt = false;
    }


}
