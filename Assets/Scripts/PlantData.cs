using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantdata", menuName = "Plant Data", order = 51)]
public class PlantData : ScriptableObject
{
    public enum THREAT { None, Low, Moderate, High}

    [SerializeField] string plantName;
    [SerializeField] THREAT plantThreat;
    [SerializeField] Texture icon;

    public string GetPlantName()
    {
        return plantName;
    }

    public THREAT GetPlantThreat()
    {
        return plantThreat;
    }

    public Texture GetIcon()
    {
        return icon;
    }
}
