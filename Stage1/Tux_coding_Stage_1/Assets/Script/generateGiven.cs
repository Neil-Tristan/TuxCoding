using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class generateGiven : MonoBehaviour
{
    public GameObject displayGiven;
    public GameObject materials;
    public GameObject backgroundTv;
    public GameObject[] platforms = new GameObject[5];
    private string fullPath = Directory.GetCurrentDirectory() + "\\Assets\\Data";
    private List<Action> list = new List<Action>();
    private Dictionary<String, Material> dict = new Dictionary<string, Material>();
    private string[] keyDict = {"bool", "string", "char", "int", "float" };

    private void Start()
    {
        list.Add(() => generateBool());
        list.Add(() => generateString());
        list.Add(() => generateChar());
        list.Add(() => generateInt());
        list.Add(() => generateFloat());

        initDict();

        StartCoroutine(gen());
    }

    private IEnumerator gen() 
    {
        for (int a = 0; a < 10; a++) 
        {
            //Generate a given
            int size = list.Count;
            int rand = UnityEngine.Random.Range(0, size);
            for (int i = 0; i < size; i++)
            {
                if (rand == i)
                {
                    list[i]();
                    int randColor = UnityEngine.Random.Range(0, size);
                    while (randColor == i)
                    {
                        randColor = UnityEngine.Random.Range(0, size);
                    }
                    Material fakeMat = dict[keyDict[randColor]];
                    backgroundTv.GetComponent<Renderer>().material = fakeMat;
                }
            }
            yield return new WaitForSeconds(4f);
        }
    }

    private void initDict() 
    {
        for (int i = 0; i < platforms.Length; i++) 
        {
            dict.Add(platforms[i].GetComponent<stage_script>().value, materials.GetComponent<SetBackgroundColor>().getMaterial(platforms[i].GetComponent<stage_script>().value));
        }
    }

    private void generateChar() 
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        int r = UnityEngine.Random.Range(0, chars.Length);
        displayGiven.GetComponent<TextMeshPro>().text = "'" + chars[r] + "'";
    }

    private void generateBool() 
    {
        int r = UnityEngine.Random.Range(0, 2);
        Debug.Log(r);
        if (r == 0) 
        {
            displayGiven.GetComponent<TextMeshPro>().text = "TRUE";
        }
        else
        {
            displayGiven.GetComponent<TextMeshPro>().text = "FALSE";
        }
    }

    private void generateFloat() 
    {
        displayGiven.GetComponent<TextMeshPro>().text = UnityEngine.Random.Range(float.MinValue, float.MaxValue).ToString();
    }

    private void generateInt() 
    {
        displayGiven.GetComponent<TextMeshPro>().text = UnityEngine.Random.Range(int.MinValue, int.MaxValue).ToString();
    }

    private void generateString() 
    {
        string[] text = System.IO.File.ReadAllLines(fullPath + "\\string.txt");
        int randomLine = UnityEngine.Random.Range(0, text.Length);
        string myRandomString = text[randomLine];
        while (myRandomString.Length < 10)
        {
            randomLine = UnityEngine.Random.Range(0, text.Length);
            myRandomString = text[randomLine];
        }
        myRandomString = removeSpecial(myRandomString);
        string[] splitedStr = myRandomString.Split(' ');
        int maxSize = 19;
        int maxSpaces = countTheSpaces(text[randomLine]);
        int randomSpaceIndex = UnityEngine.Random.Range(0, maxSpaces);
        string myNewStr = "";
        for (int i = randomSpaceIndex; i < maxSpaces; i++)
        {
            string temp = myNewStr;
            myNewStr += splitedStr[i] + " ";
            if (myNewStr.Length > maxSize)
            {
                myNewStr = temp;
            }

        }
        displayGiven.GetComponent<TextMeshPro>().text = "\"" + myNewStr + "\"";
    }

    private int countTheSpaces(string text) 
    {
        int spaces = 0;
        char[] ar = text.ToCharArray();
        for (int i = 0; i < ar.Length; i++) 
        {
            if(ar[i] == ' ')
            {
                spaces++;
            }
        }
        return spaces;
    }

    private int[] getSpacesIndex(int spacesSize, string text) 
    {
        int[] spacesIndex = new int[spacesSize];
        int startP = 0;
        char[] ar = text.ToCharArray();
        for (int i = 0; i < ar.Length; i++) 
        {
            if (ar[i] == ' ')
            {
                spacesIndex[startP] = i;
                startP++;
            }
        }
        return spacesIndex;
    }

    private string removeSpecial(string text) 
    {
        string str = "";
        char[] ar = text.ToCharArray();
        for (int i = 0; i < ar.Length; i++) 
        {
            if (ar[i] != '"');
            {
                str += ar[i].ToString();
            }
        }
        return str;
    }
}
