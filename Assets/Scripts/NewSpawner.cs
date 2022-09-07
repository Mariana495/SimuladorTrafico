using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bot;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject dp;
    public const int nBot = 5;
    public const int nBox = 40;
    public const int nDP = 10;
    private Vector3[] posListDZ;
    private Vector3[] possiblePosRobot;
    private Vector3[] possiblePosBox;
    private Vector3[] posListBot;
    private Vector3[] posListBox;
    private Vector3 vecRand;


    private void Start()
    {
        posListDZ = new Vector3[nDP] { new Vector3(0, 0.15f, 0), new Vector3(1, 0.15f, 0), new Vector3(2, 0.15f, 0), new Vector3(3, 0.15f, 0), new Vector3(4, 0.15f, 0), new Vector3(5, 0.15f, 0), new Vector3(6, 0.15f, 0), new Vector3(7, 0.15f, 0), new Vector3(8, 0.15f, 0), new Vector3(9, 0.15f, 0) };
        possiblePosRobot = new Vector3[10] { new Vector3(0, 1.8f, 1), new Vector3(1, 1.8f, 1), new Vector3(2, 1.8f, 1), new Vector3(3, 1.8f, 1), new Vector3(4, 1.8f, 1), new Vector3(5, 1.8f, 1), new Vector3(6, 1.8f, 1), new Vector3(7, 1.8f, 1), new Vector3(8, 1.8f, 1), new Vector3(9, 1.8f, 1) };
        possiblePosBox = new Vector3[80] { new Vector3(0, 1.75f, 2), new Vector3(1, 1.75f, 2), new Vector3(2, 1.75f, 2), new Vector3(3, 1.75f, 2), new Vector3(4, 1.75f, 2), new Vector3(5, 1.75f, 2), new Vector3(6, 1.75f, 2), new Vector3(7, 1.75f, 2), new Vector3(8, 1.75f, 2), new Vector3(9, 1.75f, 2), new Vector3(0, 1.75f, 3), new Vector3(1, 1.75f, 3), new Vector3(2, 1.75f, 3), new Vector3(3, 1.75f, 3), new Vector3(4, 1.75f, 3), new Vector3(5, 1.75f, 3), new Vector3(6, 1.75f, 3), new Vector3(7, 1.75f, 3), new Vector3(8, 1.75f, 3), new Vector3(9, 1.75f, 3), new Vector3(0, 1.75f, 4), new Vector3(1, 1.75f, 4), new Vector3(2, 1.75f, 4), new Vector3(3, 1.75f, 4), new Vector3(4, 1.75f, 4), new Vector3(5, 1.75f, 4), new Vector3(6, 1.75f, 4), new Vector3(7, 1.75f, 4), new Vector3(8, 1.75f, 4), new Vector3(9, 1.75f, 4), new Vector3(0, 1.75f, 5), new Vector3(1, 1.75f, 5), new Vector3(2, 1.75f, 5), new Vector3(3, 1.75f, 5), new Vector3(4, 1.75f, 5), new Vector3(5, 1.75f, 5), new Vector3(6, 1.75f, 5), new Vector3(7, 1.75f, 5), new Vector3(8, 1.75f, 5), new Vector3(9, 1.75f, 5), new Vector3(0, 1.75f, 6), new Vector3(1, 1.75f, 6), new Vector3(2, 1.75f, 6), new Vector3(3, 1.75f, 6), new Vector3(4, 1.75f, 6), new Vector3(5, 1.75f, 6), new Vector3(6, 1.75f, 6), new Vector3(7, 1.75f, 6), new Vector3(8, 1.75f, 6), new Vector3(9, 1.75f, 6), new Vector3(0, 1.75f, 7), new Vector3(1, 1.75f, 7), new Vector3(2, 1.75f, 7), new Vector3(3, 1.75f, 7), new Vector3(4, 1.75f, 7), new Vector3(5, 1.75f, 7), new Vector3(6, 1.75f, 7), new Vector3(7, 1.75f, 7), new Vector3(8, 1.75f, 7), new Vector3(9, 1.75f, 7), new Vector3(0, 1.75f, 8), new Vector3(1, 1.75f, 8), new Vector3(2, 1.75f, 8), new Vector3(3, 1.75f, 8), new Vector3(4, 1.75f, 8), new Vector3(5, 1.75f, 8), new Vector3(6, 1.75f, 8), new Vector3(7, 1.75f, 8), new Vector3(8, 1.75f, 8), new Vector3(9, 1.75f, 8), new Vector3(0, 1.75f, 9), new Vector3(1, 1.75f, 9), new Vector3(2, 1.75f, 9), new Vector3(3, 1.75f, 9), new Vector3(4, 1.75f, 9), new Vector3(5, 1.75f, 9), new Vector3(6, 1.75f, 9), new Vector3(7, 1.75f, 9), new Vector3(8, 1.75f, 9), new Vector3(9, 1.75f, 9) };
        posListBot = new Vector3[nBot];
        posListBox = new Vector3[nBox];

        for (int i = 0; i < nBot; i++)
        {
            vecRand = FillVector(possiblePosRobot);
            while(checkSame(vecRand, posListBot) == true)
            {
                vecRand = FillVector(possiblePosRobot);
            }
            posListBot[i] = vecRand;

        }
        
        for (int i = 0; i < nBox; i++)
        {
            vecRand = FillVector(possiblePosBox);
            while(checkSame(vecRand, posListBox) == true)
            {
                vecRand = FillVector(possiblePosBox);
            }
            posListBox[i] = vecRand;

        }

        Summon(posListDZ, dp);
        Summon(posListBot, bot);
        Summon(posListBox, box);
    }

    bool checkSame(Vector3 randVec, Vector3[] array)
    {
        foreach(Vector3 element in array)
        {
            if(element == randVec)
            {
                return true;
            }
        }
        return false;
    }

    Vector3 FillVector(Vector3[] arrayPossible)
    {
        Vector3 rand = arrayPossible[Random.Range(0, arrayPossible.Length - 1)];
        return rand;
    }

    void readArray(Vector3[] array)
    {
        foreach(Vector3 element in array)
        {
            Debug.Log(element);
        }
    }

    void Summon(Vector3[] array, GameObject pref)
    { 
        for(int i = 0; i < array.Length; i++)
        {
            Instantiate(pref, new Vector3(array[i].x * 4, array[i].y, array[i].z * 4), Quaternion.identity);
            transform.position = array[i];
        }
    }
}
