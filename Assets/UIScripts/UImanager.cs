using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {


    public int round;
    public float oneTurnTime ;
    public TimeCount timeUI;
    public List<ScoreCount> scoreUIList;
    public GameObject StartBG;
    public GameObject EndBG;
    public GameObject ToturialBG;
    public SoundManager SoundManager; 
    
    public static bool isGameStart = false;
    public static bool isGameEnd = false;
    private bool isInToturial = true;
    public static  int roundCount;
    private float time = 0.0f;
    private bool isScoreLimit = false;
    private int redTeamScore;
    private int blueTeamScore;


    void Update () {

        //遊戲中UI
        if (!isGameEnd && isGameStart)
        {
            if (!isInToturial)
            {
                time += Time.deltaTime;

                int timeSecond = (int)oneTurnTime - (int)time;

                timeUI.ChangeTimeSprite(timeSecond);

                if (time >= oneTurnTime)
                {
                    Debug.Log("ChangeTurn");
                    time = 0.0f;
                    roundCount++;
                    changeFinger.state++;
                    if (roundCount == round)
                    {
                        Image[] resultSprite = EndBG.GetComponentsInChildren<Image>();

                        isGameEnd = true;
                        isGameStart = false;
                        EndBG.SetActive(true);
                        if (blueTeamScore > redTeamScore)
                        {
                            resultSprite[1].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            resultSprite[2].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                        }
                        else if (blueTeamScore < redTeamScore)
                        {
                            resultSprite[1].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                            resultSprite[2].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        }
                        else
                        {
                            resultSprite[1].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            resultSprite[2].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        }

                        SoundManager.changeMusic();
                    }
                }

                //玩家分數模擬
                if (!isScoreLimit)
                {
                    if (blueTeamScore > redTeamScore)
                    {
                        scoreUIList[0].gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                        scoreUIList[1].gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                    }
                    else if (redTeamScore > blueTeamScore)
                    {
                        scoreUIList[1].gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                        scoreUIList[0].gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                    }
                    else
                    {
                        scoreUIList[0].gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                        scoreUIList[1].gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }

                    if (redTeamScore == 99 || blueTeamScore == 99)
                    {
                        isScoreLimit = true;
                    }
                }
            }
            else
            {
                if (Input.anyKeyDown)
                {
                    ToturialBG.SetActive(false);
                    isInToturial = false;
                }
            }
        }

        //開始的UI
        else if (!isGameStart && !isGameEnd)
        {
            if (Input.anyKeyDown)
            {
                isGameStart = true;
                StartBG.SetActive(false);
                SoundManager.changeMusic();
                SoundManager.InitSoundeffect(0);
            }
        }

        //結束的UI
        else if (isGameEnd && !isGameStart)
        {
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                roundCount = 0;
                redTeamScore = 0;
                blueTeamScore = 0;
                scoreUIList[0].ChangeScoreSprite(blueTeamScore);
                scoreUIList[1].ChangeScoreSprite(redTeamScore);
                isGameEnd = false;
                isInToturial = true;
                ToturialBG.SetActive(true);
                StartBG.SetActive(true);
                EndBG.SetActive(false);
                SoundManager.InitSoundeffect(0);
            }
        }
    }

    public void redTeamScorePlus(int v)
    {
        redTeamScore += v;
        scoreUIList[1].ChangeScoreSprite(redTeamScore);
    }

    public  void blueTeamScorePlus(int v)
    {
        blueTeamScore += v;
        scoreUIList[0].ChangeScoreSprite(blueTeamScore);
    }

    public void resetEverything()
    {
        time = oneTurnTime-1;
    }

    public int GetredTeamScore()
    {
        return redTeamScore;
    }

    public int GetblueTeamScore()
    {
        return blueTeamScore;
    }

    public bool GetIsGameStart()
    {
        return isGameStart;
    }

    public bool GetIsGameEnd()
    {
        return isGameEnd;
    }

}
