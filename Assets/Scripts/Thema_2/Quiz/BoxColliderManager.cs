using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxColliderManager : MonoBehaviour
{
    public static bool quizinteraktiv1=false;
    public static bool quizinteraktiv2 = false;

    void Update()
    {
        if (quizinteraktiv1 == true & quizinteraktiv2 == true)
        {

            GetComponent<Collider>().enabled = true;
            GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
        }
    }
}
