using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    public int GridSize { get; set; }
    public int easyBest { get; set; } = 10;
    public int medBest { get; set; } = 15;
    public int diffBest { get; set; } = 20;

    // Singleton Instance
    public static Singleton Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<Singleton>();

                if (instance == null) {
                    GameObject singletonObject = new GameObject("Singleton");
                    instance = singletonObject.AddComponent<Singleton>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    } //-- Singleton end

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    } //-- Awake end
}



/*
Project Name : Card of Cats
Created by   : Sir Reyyy
*/