using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour {
    public GameObject playerfabs;
    public GameObject newplayer;
    int playerNum;
    int playerNumMax;
    playerInput inputs;
    List<Player> playerList;

    void Start()
    {
        playerNum = 0;
        playerNumMax = 2;
        inputs = GetComponent<playerInput>();
        playerList = new List<Player>();
        for (int i = playerNum; i < playerNumMax; i++) addPlayer();
    }

    void addPlayer()
    {
        newplayer = Instantiate(playerfabs, this.transform); 
        Player _player = newplayer.GetComponent<Player>();
        playerList.Add(_player);

        if (playerNum == 0)
        {
            _player.up = inputs.player1and3StateInput(changeFinger.state, 0, "3");
            _player.down = inputs.player1and3StateInput(changeFinger.state, 1, "3");
            _player.left = inputs.player1and3StateInput(changeFinger.state, 2, "3");
            _player.right = inputs.player1and3StateInput(changeFinger.state, 3, "3");
            _player.interact = inputs.player1and3StateInput(changeFinger.state, 4, "3");
        }
        if (playerNum == 1)
        {
            _player.up = inputs.player2and4StateInput(changeFinger.state, 0, "4");
            _player.down = inputs.player2and4StateInput(changeFinger.state, 1, "4");
            _player.left = inputs.player2and4StateInput(changeFinger.state, 2, "4");
            _player.right = inputs.player2and4StateInput(changeFinger.state, 3, "4");
            _player.interact = inputs.player2and4StateInput(changeFinger.state, 4, "4");
        }
        playerNum++;
    }

   /* private void changeCharacter()
    {
        _player.up = inputs.player1and3StateInput(changeFinger.state, 0, "3");
        _player.down = inputs.player1and3StateInput(changeFinger.state, 1, "3");
        _player.left = inputs.player1and3StateInput(changeFinger.state, 2, "3");
        _player.right = inputs.player1and3StateInput(changeFinger.state, 3, "3");
        _player.interact = inputs.player1and3StateInput(changeFinger.state, 4, "3");
        _player.up = inputs.player2and4StateInput(changeFinger.state, 0, "4");
        _player.down = inputs.player2and4StateInput(changeFinger.state, 1, "4");
        _player.left = inputs.player2and4StateInput(changeFinger.state, 2, "4");
        _player.right = inputs.player2and4StateInput(changeFinger.state, 3, "4");
        _player.interact = inputs.player2and4StateInput(changeFinger.state, 4, "4");
    }*/
}
