using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundColor : MonoBehaviour
{
    public Material[] colors = new Material[5];
    

    public Material getBoolMaterial()
    {
        return colors[0];
    }
    public Material getCharMaterial()
    {
        return colors[1];
    }
    public Material getFloatMaterial()
    {
        return colors[2];
    }
    public Material getIntMaterial()
    {
        return colors[3];
    }
    public Material getStringMaterial()
    {
        return colors[4];
    }
    
    public Material getMaterial(string mat)
    {
        switch (mat) 
        {
            case "string": return getStringMaterial();
            case "float": return getFloatMaterial();
            case "int": return getIntMaterial();
            case "char": return getCharMaterial();
            case "bool": return getBoolMaterial();
            default: return getCharMaterial();
        }
    }

}
