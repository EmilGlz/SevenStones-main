using UnityEngine;

public static class Utils 
{
    public static void SetCharAtIndex(ref string inputString, int index, char newChar)
    {
        if (index >= 0 && index < inputString.Length)
        {
            char[] charArray = inputString.ToCharArray();
            charArray[index] = newChar;
            inputString = new string(charArray);
        }
    }

    public static GameObject FindGameObject(string name, GameObject parentOrSelf)
    {
        if (parentOrSelf == null)
            return null;
        if (parentOrSelf.name == name)
            return parentOrSelf;
        var components = parentOrSelf.GetComponentsInChildren<Transform>(true);
        foreach (Transform component in components)
        {
            if (component.gameObject.name == name)
                return component.gameObject;
        }

        return null;
    }

}
