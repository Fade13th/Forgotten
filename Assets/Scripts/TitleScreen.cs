using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    Button newGame;
    Button load;
    CanvasGroup newGameCanvas;
    CanvasGroup loadCanvas;

	// Use this for initialization
	void Start () {
        newGame = GameObject.Find("NewGame").GetComponent<Button>();
        load = GameObject.Find("Load").GetComponent<Button>();
        newGameCanvas = GameObject.Find("Name").GetComponent<CanvasGroup>();
        loadCanvas = GameObject.Find("LoadCanvas").GetComponent<CanvasGroup>();
	}

    public void ClickNewGame() {
        newGameCanvas.alpha = 1;
        newGameCanvas.blocksRaycasts = true;
    }

    public void CreateNewGame() {
        string name = GameObject.Find("NewGameName").GetComponent<InputField>().text;

        Game game = new Game();
        game.name = name;

        SaveLoad.Save();
    }

    public void Load() {
        SaveLoad.Load();

        loadCanvas.alpha = 1;
        loadCanvas.blocksRaycasts = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
