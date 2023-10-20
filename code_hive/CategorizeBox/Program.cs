/// <summary>
/// 20231020
/// https://leetcode.cn/problems/categorize-box-according-to-criteria
/// </summary>
public class Solution
{
    public int MaxSize = 10000;
    public int MaxVolume = 1000000000;
    public string CategorizeBox(int length, int width, int height, int mass)
    {
        var isHeavyBox = IsHeavyBox(mass);
        var isBulkyBox = IsBulkyBox(length, width, height);
        if (isHeavyBox && isBulkyBox)
        {
            return "Both";
        }
        if (isHeavyBox && !isBulkyBox)
        {
            return "Heavy";
        }
        if (!isHeavyBox && isBulkyBox)
        {
            return "Bulky";

        }
        if (!isHeavyBox && !isBulkyBox)
        {
            return "Neither";
        }
        return "";
    }
    public bool IsHeavyBox(int mass)
    {
        if (mass >= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsBulkyBox(int length, int width, int height)
    {
        if (length >= MaxSize || width >= MaxSize || height >= MaxSize)
        {
            return true;
        }
        long volume = (long)length * (long)width * (long)height * 1l;
        return volume >= MaxVolume;

    }
}