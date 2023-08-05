using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Incrimentor : MonoBehaviour
{
    public Text text;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

    public double val;
    public double add;
    public string eNum;

    public string finalString;
    int expo = 0;
    // Start is called before the first frame update
    void Start()
    {
        val = 0;
        add = 1;
    }

    // Update is called once per frame
    void Update()
    {
        val += add;
        eNum = val.ToString("0.00000E0");

        //RAW
        text.text = val.ToString();
        //SCIENTIFIC NOTATION
        text2.text = val.ToString("0.00000E0");

        grabExponential(val);
        FindSuffix(expo);

        text4.text = finalString;
    }
    void grabExponential(double rawVal)
    {
        //EXPONENTIAL
        //string subStrinA = eNum.Substring(8);
        int.TryParse(eNum.Substring(8), out expo);
        text3.text = expo.ToString();

        if ((expo % 3) + 1 == 1)
        {
            finalString = val.ToString("0.000e0");
        }
        else if((expo % 3) + 1 == 2)
        {
            finalString = val.ToString("00.000e0");
        }
        else if((expo % 3) + 1 == 3)
        {
            finalString = val.ToString("000.000e0");
        }
        finalString.Remove(finalString.IndexOf('e'));

        string testR = finalString.Remove(finalString.IndexOf('e'));
        finalString = testR;
    }



    string FindSuffix(int val)
    {
        double suff = Mathf.Floor(val / 3);

        string suffix;

        switch (suff)
        {
            case 0:
                suffix = "T";             
                break;
            case 1:
                suffix = "K";
                break;
            case 2:
                suffix = "M ";
                break;
            case 3:
                suffix = "B ";
                break;
            case 4:
                suffix = "T";
                break;
            case 5:
                suffix = "Qd";
                break;
            case 6:
                suffix = "Qn";
                break;
            case 7:
                suffix = "Sx";
                break;
            case 8:
                suffix = "Sp";
                break;
            case 9:
                suffix = "Oc";
                break;
            case 10:
                suffix = "No";
                break;
            case 11:
                suffix = "De ";
                break;
            case 12:
                suffix = "UDe ";
                break;
            case 13:
                suffix = "DDe ";
                break;
            case 14:
                suffix = "TDe ";
                break;
            case 15:
                suffix = "QdDe ";
                break;
            case 16:
                suffix = "QnDe ";
                break;
            case 17:
                suffix = "SxDe ";
                break;
            case 18:
                suffix = "SpDe  ";
                break;
            case 19:
                suffix = "OcDe  ";
                break;
            case 20:
                suffix = "NoDe  ";
                break;

            default:
                suffix = "Default Case";
                break;
        }

        return suffix;
    }
}
