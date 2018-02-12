using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour {
	public KeyCode[,] playerKeys;
	void Awake(){
		playerKeys = new KeyCode[4, 5];

		playerKeys[0, 0] = KeyCode.UpArrow;
		playerKeys[0, 1] = KeyCode.DownArrow;
		playerKeys[0, 2] = KeyCode.LeftArrow;
		playerKeys[0, 3] = KeyCode.RightArrow;
		playerKeys[0, 4] = KeyCode.RightControl;

		playerKeys[1, 0] = KeyCode.I;
		playerKeys[1, 1] = KeyCode.K;
		playerKeys[1, 2] = KeyCode.J;
		playerKeys[1, 3] = KeyCode.L;
		playerKeys[1, 4] = KeyCode.N;

		playerKeys[2, 0] = KeyCode.T;
		playerKeys[2, 1] = KeyCode.G;
		playerKeys[2, 2] = KeyCode.F;
		playerKeys[2, 3] = KeyCode.H;
		playerKeys[2, 4] = KeyCode.B;

		playerKeys[3, 0] = KeyCode.W;
		playerKeys[3, 1] = KeyCode.S;
		playerKeys[3, 2] = KeyCode.A;
		playerKeys[3, 3] = KeyCode.D;
		playerKeys[3, 4] = KeyCode.C;
	}
	public KeyCode player1and3StateInput(int state,int num,string playerNum){
		int player1=0;
		int player3=0;
		if (state == 0) {
			player1 = 0;
			player3 = 2;
		}
		if (state == 1) {
			player1 = 2;
			player3 = 0;
		}
		if (playerNum == "1")
			return playerKeys [player1, num];
		if (playerNum == "3")
			return playerKeys [player3, num];
		return KeyCode.Alpha0;
	}
	public KeyCode player2and4StateInput(int state,int num,string playerNum){
		int player2=0;
		int player4=0;
		if (state == 0) {
			player2 = 1;
			player4 = 3;
		}
		if (state == 1) {
			player2 = 3;
			player4 = 1;
		}
		if (playerNum == "2") {
			return playerKeys [player2, num];
		}
		if (playerNum == "4")
			return playerKeys [player4, num];
		return KeyCode.Alpha0;
	}
}
