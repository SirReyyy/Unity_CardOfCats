using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //----- Variables
    [SerializeField]
    private Transform puzzleField;
    
    [SerializeField]
    private GameObject btn;
    private int totalBtn = 8;

    //----- Functions

    void Awake() {
        // Populate buttons
        for(int i = 0; i < totalBtn; i++) {
            GameObject buttonObj = Instantiate(btn);
            buttonObj.name = "" + i;
            buttonObj.transform.SetParent(puzzleField, false);
        }
    } //-- Awake end


    void Start() {
        // code
    } //-- Start end


    void Update() {
        // code
    } //-- Update end

}


/*
Project Name : Card of Cats
Created by   : Sir Reyyy
*/