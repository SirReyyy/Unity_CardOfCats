using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //----- Variables
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    public Sprite bgImage;

    [SerializeField]
    private GameObject btn;
    private int totalBtn = 8;

    public List<Button> btnList = new List<Button>();


    //----- Functions
    void Awake() {
        PopulateBtns();
    } //-- Awake end

    void Start() {
        GetButtons();
        AddBtnListeners();
    } //-- Awake end


    private void PopulateBtns() {
        for (int i = 0; i < totalBtn; i++) {
            GameObject buttonObj = Instantiate(btn);
            buttonObj.name = "" + i;
            buttonObj.transform.SetParent(puzzleField, false);
        }
    } //-- PopulateBtns end

    private void GetButtons() {
        // Get buttons with tag Puzzle Button
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++) {
            btnList.Add(objects[i].GetComponent<Button>());
            btnList[i].image.sprite = bgImage;
        }
    } //-- GetButtons end


    private void AddBtnListeners() {
        foreach (Button btn in btnList) {
            btn.onClick.AddListener(() => PickPuzzle());
        }
    } //-- AddBtnListeners end

    public void PickPuzzle() {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Pressed " + name);
    } //-- PickPuzzle end

}


/*
Project Name : Card of Cats
Created by   : Sir Reyyy
*/