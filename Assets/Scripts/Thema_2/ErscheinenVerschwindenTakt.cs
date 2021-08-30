using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErscheinenVerschwindenTakt : MonoBehaviour
{
    public GameObject GO_MarkerMenue;
    public GameObject GO_Merkmalbasiert;

    private bool MarkerMenue_1;
    private bool Merkmalbasiert_1;
    public KorrekturRotation rotation;

    public GameObject bildMarker;

    public GameObject Pfeil;
    public GameObject RundesMenue;
    public GameObject TaktMenue;
    public bool updatestop;
    public bool taktMenue;


    void Start()
    {
        TaktMenue.SetActive(false);
        KnopfKontrolle.disabledModellMenue = true;
        KnopfKontrolle.disabledHauptMenue = true;

    }
    public void Update()
    {
        //Abfrage, ob der Marker von der Kamera gerade erkannt wird
        MarkerMenue_1 = GO_MarkerMenue.GetComponent<MeshRenderer>().enabled;
        Merkmalbasiert_1 = GO_Merkmalbasiert.GetComponent<MeshRenderer>().enabled;
       
        if (Merkmalbasiert_1 & !MarkerMenue_1)
        {
            bildMarker.SetActive(true);

        }
        else
        {
            bildMarker.SetActive(false);
        }
        if (Merkmalbasiert_1 & MarkerMenue_1)
        {
            Pfeil.SetActive(true);
        }
        else
        {
            Pfeil.SetActive(false);
        }

        if (Merkmalbasiert_1 & MarkerMenue_1 & updatestop)
        {
            KnopfKontrolle.disabledHauptMenue = false;
            rotation.ErstePositionBestimmen();
            RundesMenue.SetActive(true);
        }

        else
        {

            RundesMenue.SetActive(false);

        }
        if (Merkmalbasiert_1 & MarkerMenue_1 & taktMenue)
        {
            rotation.ErstePositionBestimmen();
            TaktMenue.SetActive(true);
        }

        else
        {

            TaktMenue.SetActive(false);

        }
    }

}
