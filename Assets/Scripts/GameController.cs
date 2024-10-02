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

    public Sprite[] catsImage;
    public List<Sprite> catPuzzles = new List<Sprite>();
    public List<Button> btnList = new List<Button>();

    [SerializeField]
    private GameObject btn;
    private int totalBtn = 12;

    private bool firstGuess, secondGuess;
    private string firstGuessPuzzle, secondGuessPuzzle;
    private int firstGuessIndex, secondGuessIndex;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;


    //----- Functions
    void Awake() {
        PopulateBtns();
        catsImage = Resources.LoadAll<Sprite>("Sprites/Cats");
    } //-- Awake end

    void Start() {
        GetButtons();
        AddBtnListeners();
        AddCatPuzzles();
        ShuffleCats(catPuzzles);
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


    private void AddCatPuzzles() {
        int looper = btnList.Count;
        int index = 0;

        for (int i = 0; i < looper; i++) {
            if (index == looper / 2) {
                index = 0;
            }

            catPuzzles.Add(catsImage[index]);
            index++;
        }

        gameGuesses = catPuzzles.Count / 2;
    } //-- AddCatPuzzles end

    private void AddBtnListeners() {
        foreach (Button btn in btnList) {
            btn.onClick.AddListener(() => PickPuzzle());
        }
    } //-- AddBtnListeners end

    private void ShuffleCats(List<Sprite> list) {
        for (int i = 0; i < list.Count; i++) {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    } //-- ShuffleCats end


    public void PickPuzzle() {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
        if(!firstGuess) {
            firstGuess = true;
            firstGuessIndex = int.Parse(name);
            firstGuessPuzzle = catPuzzles[firstGuessIndex].name;
            btnList[firstGuessIndex].image.sprite = catPuzzles[firstGuessIndex];
        } else if(!secondGuess) {
            secondGuess = true;
            secondGuessIndex = int.Parse(name);
            secondGuessPuzzle = catPuzzles[secondGuessIndex].name;
            btnList[secondGuessIndex].image.sprite = catPuzzles[secondGuessIndex];

            countGuesses++;
            StartCoroutine(CheckIfCatsMatch());
        }
    } //-- PickPuzzle end

    IEnumerator CheckIfCatsMatch() {
        yield return new WaitForSeconds(1.0f);

        if(firstGuessPuzzle == secondGuessPuzzle) {
            yield return new WaitForSeconds(0.5f);
            btnList[firstGuessIndex].interactable = false;
            btnList[secondGuessIndex].interactable = false;
            btnList[firstGuessIndex].image.color = new Color(0,0,0,0);
            btnList[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            IsGameFinished();
        } else {
            yield return new WaitForSeconds(0.5f);
            btnList[firstGuessIndex].image.sprite = bgImage;
            btnList[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(0.5f);
        firstGuess = secondGuess = false;
    } //-- CheckIfCatsMatch end

    void IsGameFinished() {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses) {
            Debug.Log("Game Finished");
            Debug.Log("Total: " + countGuesses);
        }
    } //-- IsGameFinised end
}

/*
Project Name : Card of Cats
Created by   : Sir Reyyy
*/