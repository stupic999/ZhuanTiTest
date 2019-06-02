using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem : MonoBehaviour {

    public List<string> Bag = new List<string>();

    public GameObject FishBait;
    public GameObject Key;
    public GameObject PuzzleVase;
    public GameObject PuzzleCupBoard;
    public GameObject Music;
    public GameObject Clown;
    public GameObject Cars;
    public GameObject Bear;
    public Animator BagAnim;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;
    public GameObject Item7;
    public GameObject Item8;

    public static bool isItem=true;

    public GameObject BagUI;

    Vector3 Place;

    bool isBagOpen;

    private void Update()
    {
        if (GameController.isPause && !isBagOpen)
        {
            BagUI.SetActive(false);
        }
        else
        {
            BagUI.SetActive(true);
        }
    }


    public void isClickBagBtn()
    {
        if (!GameController.isPause || isBagOpen)
        {
            AudioController.openBag = true;
            isBagOpen = !isBagOpen;
            BagAnim.SetBool("isBagOpen", isBagOpen);
            if (isBagOpen)
            {
                GameController.isPause = true;
            }
            else
            {
                GameController.isPause = false;
            }
        }
    }

    public void AddItem(string item)
    {
        Bag.Add(item);
        ShowItem();
    }

    public void RemoveItem(string item)
    {
        Bag.Remove(item);

        if (!Bag.Contains("FishBait"))
            FishBait.SetActive(false);

        if (!Bag.Contains("Key"))
            Key.SetActive(false);

        if (!Bag.Contains("PuzzleVase"))
            PuzzleVase.SetActive(false);

        if (!Bag.Contains("PuzzleCupBoard"))
            PuzzleCupBoard.SetActive(false);

        if (!Bag.Contains("Music"))
            Music.SetActive(false);

        if (!Bag.Contains("Clown"))
            Clown.SetActive(false);

        if (!Bag.Contains("Cars"))
            Cars.SetActive(false);

        if (!Bag.Contains("Bear"))
            Bear.SetActive(false);

        ShowItem();
    }

    public void ShowItem()
    {
        int Count = 0;
        foreach (string item in Bag)
        {
            if (Count == 0)
            {
                Place = Item1.transform.position;
            }
            else if (Count == 1)
            {
                Place = Item2.transform.position;
            }
            else if (Count == 2)
            {
                Place = Item3.transform.position;
            }
            else if (Count == 3)
            {
                Place = Item4.transform.position;
            }
            else if (Count == 4)
            {
                Place = Item5.transform.position;
            }
            else if (Count == 5)
            {
                Place = Item6.transform.position;
            }
            else if (Count == 6)
            {
                Place = Item7.transform.position;
            }
            else if (Count == 7)
            {
                Place = Item8.transform.position;
            }
            if (item == "FishBait")
            {
                FishBait.SetActive(true);
                FishBait.transform.position = Place;
            }
            else if (item == "Key")
            {
                Key.SetActive(true);
                Key.transform.position = Place;
            }
            else if (item == "PuzzleVase")
            {
                PuzzleVase.SetActive(true);
                PuzzleVase.transform.position = Place;
            }
            else if (item == "PuzzleCupBoard")
            {
                PuzzleCupBoard.SetActive(true);
                PuzzleCupBoard.transform.position = Place;
            }
            else if (item == "Music")
            {
                Music.SetActive(true);
                Music.transform.position = Place;
            }
            else if (item == "Clown")
            {
                Clown.SetActive(true);
                Clown.transform.position = Place;
            }
            else if (item == "Cars")
            {
                Cars.SetActive(true);
                Cars.transform.position = Place;
            }
            else if (item == "Bear")
            {
                Bear.SetActive(true);
                Bear.transform.position = Place;
            }
            Count++;
        }
    }
}
