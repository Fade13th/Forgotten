using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    Button newGame;
    Button load;
    CanvasGroup canvas;
    CanvasGroup newGameCanvas;
    CanvasGroup loadCanvas;

    public GameObject button;

	// Use this for initialization
	void Start () {
        newGame = GameObject.Find("NewGame").GetComponent<Button>();
        load = GameObject.Find("Load").GetComponent<Button>();
        canvas = GetComponent<CanvasGroup>();
        newGameCanvas = GameObject.Find("Name").GetComponent<CanvasGroup>();
        loadCanvas = GameObject.Find("LoadCanvas").GetComponent<CanvasGroup>();
	}

    public void ClickNewGame() {
        newGameCanvas.alpha = 1;
        newGameCanvas.blocksRaycasts = true;
    }

    public void CreateNewGame() {
        string name = GameObject.Find("NewGameName").GetComponent<InputField>().text;

        Game game = new Game(name);
        game.CreatePlayer(name);
        GameManager.game = game;

        SaveLoad.Save(game);

        LoadGame(game);
    }

    public void Load() {
        foreach (Button b in loadCanvas.GetComponentsInChildren<Button>()) {
            if (b.name != "Close") {
                Destroy(b.gameObject);
            }
        }

        SaveLoad.Load();

        loadCanvas.alpha = 1;
        loadCanvas.blocksRaycasts = true;

        float y = 0;

        foreach (Game game in SaveLoad.savedGames) {
            MonoBehaviour.print(game);

            GameObject b = Instantiate(button);
            b.transform.parent = loadCanvas.transform;
            b.transform.localPosition = new Vector2(0, y);
            b.gameObject.GetComponentInChildren<Text>().text = game.name;

            y += 40;

            b.GetComponent<Button>().onClick.AddListener(delegate { LoadGame(game); });
        }
    }

    private void LoadGame(Game game) {
        canvas.alpha = 0;
        canvas.blocksRaycasts = false;

        SaveLoad.LoadGame(game);
    }

    public void Close() {
        newGameCanvas.alpha = 0;
        newGameCanvas.blocksRaycasts = false;

        loadCanvas.alpha = 0;
        loadCanvas.blocksRaycasts = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
