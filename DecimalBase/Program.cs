using System;
class DecimalBase
{
    static void Main(string[] args)
    {
        bool isRet = IsDecimalNumner("1");
        if (isRet)
        {
            Console.WriteLine("Is DecimalNumber");
        }
        else
        {
            Console.WriteLine("Not DecimalNumber");
        }

        Console.ReadKey();
    }

    static bool IsDecimalNumner(string strNumber)
    {
        if (string.IsNullOrEmpty(strNumber))
        {
            return false;
        }

        bool isDecimalNumber = true;
        bool isFristNumber = true;
        foreach (char cNumber in strNumber)
        {
            try
            {
                if (!isDecimalNumber)
                {
                    break;
                }

                int number = Convert.ToInt32(cNumber);
                isDecimalNumber = IsRegionNumber(number, isFristNumber);

                //不为1-9开头  
                if (!isDecimalNumber && isFristNumber)
                {
                    isDecimalNumber = IsLegalChar(isFristNumber, cNumber, strNumber);
                }
                isFristNumber = false;
            }
            catch (Exception )
            {
                isDecimalNumber = false;
                break;
            }
        }
        return isDecimalNumber;
    }

    static bool IsLegalChar(bool isFristSymbols, char cNumber, string strLine)
    {
        bool legalSymbols = false;
        string strNumber = Convert.ToString(cNumber);

        //第一位为 正负符号
        if (isFristSymbols && (strNumber == "+" || strNumber == "-"))
        {
            legalSymbols = true;
        }

        //单符号
        if (isFristSymbols && (strNumber == "+" || strNumber == "-") && strLine.Length == 1)
        {
            legalSymbols = false;
        }

        //单0的情况
        if (isFristSymbols && strNumber == "0" && strLine.Length == 1)
        {
            legalSymbols = true;
        }
        
        return legalSymbols;
    }
    

    static bool IsRegionNumber(int number, bool isFirstNumber)
    {
        bool isRegionNumber = false;
        if (isFirstNumber && number > 48 && number <= 57)
        {
            isRegionNumber = true;
        }

        if(!isFirstNumber && number >= 48 && number <= 57)
        {
            isRegionNumber = true;
        }

        return isRegionNumber;
    }

}