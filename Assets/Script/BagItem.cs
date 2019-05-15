using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem : MonoBehaviour {

    public static List<string> Bag = new List<string>();

    // FishBait,Key,PuzzleVase,PuzzleCapBoard useable
    // Music,Clown,Cars,Bear unuseable

    public GameObject FishBait;
    public GameObject Key;
    public GameObject PuzzleVase;
    public GameObject PuzzleCupbBoard;
    public GameObject Music;
    public GameObject Clown;
    public GameObject Cars;
    public GameObject Bear;


    private void Update()
    {
        if (Bag.Contains("FishBait"))
            FishBait.SetActive(true);
        else
            FishBait.SetActive(false);

        if (Bag.Contains("Key"))
            Key.SetActive(true);
        else
            Key.SetActive(false);

        if (Bag.Contains("PuzzleVase"))
            PuzzleVase.SetActive(true);
        else
            PuzzleVase.SetActive(false);

        if (Bag.Contains("PuzzleCupBoard"))
            PuzzleCupbBoard.SetActive(true);
        else
            PuzzleCupbBoard.SetActive(false);

        if (Bag.Contains("Music"))
            Music.SetActive(true);
        else
            Music.SetActive(false);

        if (Bag.Contains("Clown"))
            Clown.SetActive(true);
        else
            Clown.SetActive(false);

        if (Bag.Contains("Cars"))
            Cars.SetActive(true);
        else
            Cars.SetActive(false);

        if (Bag.Contains("Bear"))
            Bear.SetActive(true);
        else
            Bear.SetActive(false);
    }
}
