using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] PlantData info;
    SetPlantInfo spi;

    void Start()
    {
        spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    public PlantData GetInfo()
    {
        return info;
    }

    void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.plantName.text = info.GetPlantName();
        spi.threatLevel.text = info.GetPlantThreat().ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = info.GetIcon();
    }
}
