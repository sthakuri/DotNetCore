using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    //      AB:CD   => 23:18
    //      Hours   => AB
    //      Minutes => CD
    int[] digits = new int[4];
    List<int> arrHours = new List<int>();
    int attempt = 0;
    String NOT_POSSIBLE = "NOT POSSIBLE";
    public string solution(int A, int B, int C, int D)
    {
        string result = string.Empty;
        digits[0] = A;
        digits[1] = B;
        digits[2] = C;
        digits[3] = D;

        string hourDigits = NOT_POSSIBLE;
        string minuteDigits = NOT_POSSIBLE;
        MakeHourDigits();
        if (arrHours == null || arrHours.Count == 0)
        {
            return NOT_POSSIBLE;
        }

        foreach (int AB in arrHours)
        { 
            char[] strDigits = AB.ToString("00").ToCharArray();            
            int hourA = Convert.ToInt32(strDigits[0].ToString());
            int hourB = Convert.ToInt32(strDigits[1].ToString());
            int[] listTemp = UpdateArray(digits, hourA, -hourA);
            listTemp = UpdateArray(listTemp, hourB, -hourB);
            minuteDigits = MakeMinuteDigits(listTemp, hourA, hourB);
            if (minuteDigits == NOT_POSSIBLE)
            {
                attempt++;
                continue;
            }
            else
            {
                hourDigits=AB.ToString("00");
                break;                
            }
        }

        result = (hourDigits != NOT_POSSIBLE && minuteDigits != NOT_POSSIBLE) ? string.Format("{0}:{1}", hourDigits, minuteDigits) : NOT_POSSIBLE;

        return string.Format("\"{0}\"", result);        
    }

    private int[] UpdateArray(int[] arr, int oldValue, int newValue)
    {
        int[] temp = Clone(arr);
        for (int i = 0; i < temp.Length; i++)
        {
            if (arr[i] == oldValue)
            {
                temp[i] = newValue;
                return temp;
            }
            else
                temp[i] = temp[i];
        }
        return temp;
    }
    private int[] Clone(int[] arr)
    {
        int[] temp = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            temp[i] = arr[i];
        return temp;
    }
    private int Exist(int[] nums, int num)
    {
        for (int i = 0; i < nums.Length; i++)
            if (nums[i] >= 0 && nums[i] == num)
            {
                return i;
            }
        return -1;
    }

    private void MakeHourDigits()
    {
        string hourDigits = string.Empty;
        int digitFirst = -1;
        arrHours = new List<int>();
        //make first digit
        //possible values 0,1,2

        for (int i = 2; i >= 0; i--)
        {
            int[] listA = Clone(digits);
            int index = Exist(listA, i);
            if (index >= 0)
            {
                digitFirst = i;
                listA[index] = -listA[index];
                MakeHourDigit_Second(listA, i);
            }
        }
        if (arrHours != null)
        {
            arrHours = arrHours.OrderByDescending(x => x).ToList();
        }
    }

    private void MakeHourDigit_Second(int[] arr, int digitFirst)
    {
        //make second digit
        //possible values 0[0-9], 1[0-9], 2[0-3]  
        int digitSecond = -1;
        int[] listB = Clone(arr);

        //case digitFirst = 0 or 1
        if (digitFirst == 0 || digitFirst == 1)
        {
            foreach (int val in arr)
            {
                if (val >= 0 && val <= 9)
                {
                    int index = Exist(listB, val);
                    if (index >= 0)
                    {
                        listB[index] *= -1;
                        digitSecond = val;
                        int AB = digitFirst * 10 + digitSecond;
                        arrHours.Add(AB);
                    }
                }
            }
        }
        //case digitFirst = 2  
        else if (digitFirst == 2)
        {
            foreach (int val in arr)
            {
                if (val >= 0 && val <= 3)
                {
                    int index = Exist(listB, val);
                    if (index >= 0)
                    {
                        listB[index] *= -1;
                        digitSecond = val;
                        int AB = digitFirst * 10 + digitSecond;
                        arrHours.Add(AB);
                    }
                }
            }
        }        
    }

    public string MakeMinuteDigits(int[] arr, int A, int B)
    {
        int digitFirst = -1;
        int[] listC = Clone(arr);
        //make first digit
        //possible values [0-5]
        for (int i = 5; i >= 0; i--)
        {
            int index = Exist(listC, i);
            if (index >= 0)
            {
                digitFirst = i;
                listC[index] *= -1;
                break;
            }
        }
        if (digitFirst == -1)
        {
            return NOT_POSSIBLE;
        }

        //make second digit
        //possible values [0-9]
        int digitSecond = -1;
        for (int i = 9; i >= 0; i--)
        {
            int index = Exist(listC, i);
            if (index >= 0)
            {
                digitSecond = i;
                listC[index] *= -1;
                break;
            }
        }
        if (digitSecond == -1)
        {
            return NOT_POSSIBLE;
        }

        return string.Format("{0}{1}", digitFirst, digitSecond);
    }
}