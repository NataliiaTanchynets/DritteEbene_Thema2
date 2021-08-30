using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnopfKontrolle : MonoBehaviour
{
    public GameObject Menue;
    public GameObject ModellMenue;
    public static bool disabledHauptMenue = false;
    public static bool disabledModellMenue = false;
  
    public void Update()
    {
        if (disabledHauptMenue) {
            
          Menue.SetActive(false);
        }
        else { 
            
        Menue.SetActive(true);
    }
        if (disabledModellMenue)
        {
            ModellMenue.SetActive(false);

        }
        else
        {
            ModellMenue.SetActive(true);
        }
    }
}
