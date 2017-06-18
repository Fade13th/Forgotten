﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

    public static List<Game> savedGames = new List<Game>();

    //it's static so we can call it from anywhere
    public static void Save(Game game) {
        Load();

        List<Game> copy = new List<Game>();
        MonoBehaviour.print(SaveLoad.savedGames.Count);

        foreach (Game g in SaveLoad.savedGames) {
            if (g.name == game.name) {
                copy.Add(g);
            }
        }

        foreach (Game g in copy) {
            SaveLoad.savedGames.Remove(g);
        }

        SaveLoad.savedGames.Add(game);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, SaveLoad.savedGames);
        file.Close();        

        MonoBehaviour.print(SaveLoad.savedGames.Count);
    }

    public static void Load() {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void LoadGame(Game g) {
        GameManager.game = g;
    }
}
