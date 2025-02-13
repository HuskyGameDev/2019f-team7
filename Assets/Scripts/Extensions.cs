﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions  {
	public static GameManager.Direction inverse(this GameManager.Direction dir) {
		switch (dir)
		{
			case GameManager.Direction.North:
				return GameManager.Direction.South;
			case GameManager.Direction.South:
				return GameManager.Direction.North;
			case GameManager.Direction.East:
				return GameManager.Direction.West;
			case GameManager.Direction.West:
				return GameManager.Direction.East;
		}
		return GameManager.Direction.East;
	}

	public static Vector2Int offset(this GameManager.Direction dir) {
		switch (dir)
		{
			case GameManager.Direction.North:
				return new Vector2Int(0,1);
			case GameManager.Direction.South:
				return new Vector2Int(0,-1);
			case GameManager.Direction.East:
				return new Vector2Int(1,0);
			case GameManager.Direction.West:
				return new Vector2Int(-1,0);
		}
		return new Vector2Int(0,0);
	}

	public static GameManager.Direction clockwise(this GameManager.Direction dir) {
		switch (dir) {
			case GameManager.Direction.North:
				return GameManager.Direction.East;
			case GameManager.Direction.South:
				return GameManager.Direction.West;
			case GameManager.Direction.East:
				return GameManager.Direction.South;
			case GameManager.Direction.West:
				return GameManager.Direction.North;
		}
		return GameManager.Direction.South;
	}

	public static GameManager.Direction counterclockwise(this GameManager.Direction dir) {
		switch (dir) {
			case GameManager.Direction.North:
				return GameManager.Direction.West;
			case GameManager.Direction.South:
				return GameManager.Direction.East;
			case GameManager.Direction.East:
				return GameManager.Direction.North;
			case GameManager.Direction.West:
				return GameManager.Direction.South;
		}
		return GameManager.Direction.North;
	}

	public static int renderLayer(this GameManager.Direction dir) {
		switch (dir) {
			case GameManager.Direction.North:
			case GameManager.Direction.South:
				return 0;
			case GameManager.Direction.East:
			case GameManager.Direction.West:
				return 1;
		}

		return -1;
	}
}
