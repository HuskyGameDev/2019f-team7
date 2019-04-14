﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public string levelSavePath = "level.json";

	public void CreateAndSaveLevel() {
		Map.Save(GenerateLevel(), "/" + levelSavePath);
		//UnityEditor.AssetDatabase.Refresh();
	}
	public virtual Map GenerateLevel() { return new Map();}

}