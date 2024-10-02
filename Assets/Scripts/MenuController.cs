using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //----- Variables
    private Singleton _singletonManager;


    //----- Functions

    void Awake() {
        _singletonManager = Singleton.Instance;

        GetMenuButtons();
    } //-- Awake end

    private void GetMenuButtons() {
        // Get buttons with tag Menu Button
        GameObject[] menuBtn = GameObject.FindGameObjectsWithTag("MenuButton");

        foreach (GameObject btnObj in menuBtn) {
            btnObj.GetComponent<Button>().onClick.AddListener(() => SetGridSize());
        }
    } //-- GetMenuButtons end

    private void SetGridSize() {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        _singletonManager.GridSize = int.Parse(name);
        SceneManager.LoadScene("Game");
    } //-- SetGridSize end
}


/*
Project Name :
Created by   : Sir Reyyy
*/