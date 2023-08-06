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
    StringGenerator stringGenerator;
    public string finalString;
    int expo = 0;

    bool auto = false;
    // Start is called before the first frame update
    void Start()
    {
        val = 0;
        add = 1;

        stringGenerator = new StringGenerator();
    }

    // Update is called once per frame
    void Update()
    {

        if(auto)
            val += add;
        eNum = val.ToString("0.00000E0");

        //RAW
        text.text = val.ToString();
        //SCIENTIFIC NOTATION
        text2.text = val.ToString("0.00000E0");

        
        finalString = FindExponetialPosition(grabExponential(val));
        finalString = RemoveExponetial(finalString);
        finalString = finalString + FindSuffix(grabExponential(val));
        text4.text = stringGenerator.GeneratePrintableString(val);

        text5.text = GeneratePrintableString(val);
    }

    string GeneratePrintableString(double rawVal)
    {
        if (rawVal <= 1000000)
        {
            return rawVal.ToString("N");
        }
        else
        {
            int exponentialSize = 0;
            int.TryParse(rawVal.ToString("0.00000E0").Substring(8), out exponentialSize);

            string scientificNotation = "";
            if ((exponentialSize % 3) + 1 == 1)
            {
                scientificNotation = val.ToString("0.000e0");
            }
            else if ((exponentialSize % 3) + 1 == 2)
            {
                scientificNotation = val.ToString("00.000e0");
            }
            else if ((exponentialSize % 3) + 1 == 3)
            {
                scientificNotation = val.ToString("000.000e0");
            }

            string returnable = scientificNotation.Remove(scientificNotation.IndexOf('e'));

            returnable = returnable + FindSuffix(exponentialSize);

           return returnable;
        } 
    }

    int grabExponential(double rawVal)
    {
        //EXPONENTIAL
        int returnable = 0;
        int.TryParse(eNum.Substring(8), out returnable);
        text3.text = expo.ToString();

        return returnable;
    }
    string FindExponetialPosition(int exponential)
    {
        string scientificNotation = "";
        if ((exponential % 3) + 1 == 1)
        {
            scientificNotation = val.ToString("0.000e0");
        }
        else if ((exponential % 3) + 1 == 2)
        {
            scientificNotation = val.ToString("00.000e0");
        }
        else if ((exponential % 3) + 1 == 3)
        {
            scientificNotation = val.ToString("000.000e0");
        }
        return scientificNotation;
    }

    string RemoveExponetial(string val)
    {
        string returnable = val.Remove(val.IndexOf('e'));
        return returnable;
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

    public void addBut()
    {
        val += 10;
    }
    public void subBut()
    {
        val -= 10;
    }
    public void autoBut()
    {
        auto = !auto;
    }
}
