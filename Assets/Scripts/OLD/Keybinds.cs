using System.Collections.Generic;
using UnityEngine;

public class Keybinds : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>(); //static dictionary containing keycodes and their reference names

    private void Start()
    {
        if (!keys.ContainsKey("Forward"))
        {
            DefaultKeyBinds(); //set default keys
        }
    }

    public void DefaultKeyBinds()
    {
        //add default keys with code and tag to dictionary keys
        keys.Add("Forward", KeyCode.UpArrow);
        keys.Add("Backwards", KeyCode.DownArrow);
        keys.Add("Left", KeyCode.LeftArrow);
        keys.Add("Right", KeyCode.RightArrow);
    }
}
