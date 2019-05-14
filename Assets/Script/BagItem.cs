using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem : MonoBehaviour {

    public static List<string> Bag = new List<string>();

    // FishBait,Key,PuzzleVase,PuzzleCapBoard useable
    // Music,Clown,Cars,Bear unuseable
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {   
            if (!Bag.Contains("Clown"))
            {
                Bag.Add("Clown");
            }
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (!Bag.Contains("FishBait"))
            {
                Bag.Add("FishBait");
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Bag.Remove("Clown");
        }
    }
}
