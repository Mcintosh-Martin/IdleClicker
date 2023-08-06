using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringGenerator 
{
    //Takes in double and outputs a string in the form of any of below depeneding on input
    //000,000,000
    //100.000k
    public string GeneratePrintableString(double rawVal)
    {
        if (rawVal <= 1000000)
        {
            return rawVal.ToString("N");
        }
        else
        {
            string returnable = "";

            returnable = FindExponetialPosition(grabExponential(rawVal), rawVal);
            returnable = RemoveExponetial(returnable);
            returnable = returnable + FindSuffix(grabExponential(rawVal));

            return returnable;
        }
    }

    int grabExponential(double rawValue)
    {
        //EXPONENTIAL
        int returnable = 0;
        int.TryParse(rawValue.ToString("0.00000E0").Substring(8), out returnable);

        return returnable;
    }
    string FindExponetialPosition(int exponential, double rawValue)
    {
        string scientificNotation = "";
        if ((exponential % 3) + 1 == 1)
        {
            scientificNotation = rawValue.ToString("0.000e0");
        }
        else if ((exponential % 3) + 1 == 2)
        {
            scientificNotation = rawValue.ToString("00.000e0");
        }
        else if ((exponential % 3) + 1 == 3)
        {
            scientificNotation = rawValue.ToString("000.000e0");
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
}
