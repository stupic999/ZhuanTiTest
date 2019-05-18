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
    public GameObject PuzzleCupBoard;
    public GameObject Music;
    public GameObject Clown;
    public GameObject Cars;
    public GameObject Bear;
    public Animator BagAnim;
    //public GameObject Item1;
    //public GameObject Item2;
    //public GameObject Item3;
    //public GameObject Item4;
    //public GameObject Item5;
    //public GameObject Item6;
    //public GameObject Item7;
    //public GameObject Item8;

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

        if (isItem)
        {
            //Count = Bag.Count;
            //if (Count == 0)
            //{
            //    Place = Item1.transform.position;
            //}
            //else if (Count == 1)
            //{
            //    Place = Item2.transform.position;
            //}
            //else if (Count == 2)
            //{
            //    Place = Item3.transform.position;
            //}
            //else if (Count == 3)
            //{
            //    Place = Item4.transform.position;
            //}
            //else if (Count == 4)
            //{
            //    Place = Item5.transform.position;
            //}
            //else if (Count == 5)
            //{
            //    Place = Item6.transform.position;
            //}
            //else if (Count == 6)
            //{
            //    Place = Item7.transform.position;
            //}
            //else if (Count == 7)
            //{
            //    Place = Item8.transform.position;
            //}

            //if (itemName == "FishBait")
            //{
            //    FishBait.transform.position = Place;
            //}
            //else if (itemName == "Key")
            //{
            //    Key.transform.position = Place;
            //}
            //else if (itemName == "PuzzleVase")
            //{
            //    PuzzleVase.transform.position = Place;
            //}
            //else if (itemName == "PuzzleCupBoard")
            //{
            //    PuzzleCupBoard.transform.position = Place;
            //}
            //else if (itemName == "Music")
            //{
            //    Music.transform.position = Place;
            //}
            //else if (itemName == "Clown")
            //{
            //    Clown.transform.position = Place;
            //}
            //else if (itemName == "Cars")
            //{
            //    Cars.transform.position = Place;
            //}
            //else if (itemName == "Bear")
            //{
            //    Bear.transform.position = Place;
            //}
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
                PuzzleCupBoard.SetActive(true);
            else
                PuzzleCupBoard.SetActive(false);

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
}
