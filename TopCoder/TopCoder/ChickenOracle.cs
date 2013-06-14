using System;
using System.Collections.Generic;
using System.Text;

public class ChickenOracle
{
    public string theTruth(int n, int eggCount, int lieCount, int liarCount)
    {
        int chickenCount = n - eggCount;
        bool egg = false;
        bool chicken = false;
        bool am = false;
        int group1 = lieCount;
        int group2 = n - lieCount;

        //i is who are told chicken but say egg
        //liarcount -i is who are told egg but say chiken
        //chicken
        for (int i = 0; i <= liarCount; i++)
        {
            if (i > group2 || (liarCount - i) > group1)
            {
                continue;
            }


            int chikenTrue = group2 - i + liarCount - i;
            int eggTrue = group1 - liarCount + i + i;

            if (chikenTrue < 0)
            {
                break;
            }

            if (chikenTrue == chickenCount)
            {
                chicken = true;
                break;
            }
        }

        //egg
        for (int i = 0; i <= liarCount && i<=group1 && (liarCount-i)<=group2; i++)
        {
            if (i > group1 || (liarCount - i) > group2)
            {
                continue;
            }

            int chikenTrue = group1 - i + liarCount - i;
            int eggTrue = group2 - liarCount + i + i;


            if (chikenTrue < 0)
            {
                break;
            }

            if (chikenTrue == chickenCount)
            {
                egg = true;
                break;
            }
        }


        if (chicken == true && egg == true)
        {
            chicken = egg = false;
            am = true;
        }

        if (chicken)
        {
            return "The chicken";
        }
        else if (egg)
        {
            return "The egg";
        }
        else if (am)
        {
            return "Ambiguous";
        }
        else
        {
            return "The oracle is a lie";
        }

    }
}