using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {

    //returns a list of cumulative scores, like a normal scorecard
    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls)){
            runningTotal += frameScore;
            cumulativeScores.Add(frameScore + runningTotal);
        }

        return cumulativeScores;
    }
    //return a list of individual frame scores, NOT cumulative
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();


        return frameList;
    }


	
}
