using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {

    //public enum StrikeState { firstStrike, multiStrike, firstSpare, multiSpare, none};

    //returns a list of cumulative scores, like a normal scorecard
    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
        int frame = 1;
        foreach(int frameScore in ScoreFrames(rolls)){
            if (frame == 11) {
                break;
            }
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
            frame++;
        }

        return cumulativeScores;
    }


    //return a list of individual frame scores, NOT cumulative
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();
        frameList.Clear();

        bool firstRoll = true;
        bool finalRolls = false;
        bool strikeOnLastRoll = false;
        
        for(var i = 0; i < rolls.Count; i++) {
            if(i == 19) { finalRolls = true; }
            if(strikeOnLastRoll) { firstRoll = true; }

            //strike check
            
            if(rolls[i] == 10 && firstRoll && (i + 2) < rolls.Count) {
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
                strikeOnLastRoll = true;
            }
            else { strikeOnLastRoll = false; }
            
            //regular or spare check
            if((i + 1) < rolls.Count) {
                //regular check
                if((rolls[i] + rolls[i + 1]) < 10 && firstRoll && !finalRolls) {
                    if(i > 18 && strikeOnLastRoll) {
                        break;
                    }
                    frameList.Add(rolls[i] + rolls[i + 1]);
                    firstRoll = true;
                    i ++;
                    if(i == 19) {
                        break;
                    }
                }
                //spare check
                else if(i > 0 && rolls[i] + rolls[i - 1] == 10 && !firstRoll) {
                    frameList.Add(10 + rolls[i + 1]);
                    firstRoll = true;
                }
                
                //next ball completes the spare
                else if (rolls[i]+rolls[i+1] == 10){ firstRoll = false; }
            }
        }
        return frameList;
    }

	
}


