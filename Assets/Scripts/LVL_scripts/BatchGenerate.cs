﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchGenerate {
	static public Generate_Generic_Room[] roomsToGenerate = {
		new Generate_Room_001(),
		new Generate_Room_002(),
		new Generate_Room_003(),
		new Generate_Room_004(),
		new Generate_Room_005(),
		new Generate_Room_006(),
		new Generate_Room_007(),
		new Generate_Room_Bug(),
		new Generate_Room_Demo(),
		new Generate_Room_Demo2(),
		new Generate_Room_Demo3(),
		new Generate_Room_Demo4()
		//new Generate_Room_00(),
	};

	static public void GenerateRooms() {
		int i = 0;
		Map mapTest;
		while (i < roomsToGenerate.Length) {
			mapTest = roomsToGenerate[i].generateRoom();
			Map.Save(mapTest, Application.dataPath + "/Levels/room_" + (roomsToGenerate[i].getLevelName()));
			i++;
		}
		
	}
	
}