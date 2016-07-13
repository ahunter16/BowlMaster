using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster  {

    public enum Action {
        Tidy,
        Reset, 
        EndTurn,
        EndGame
    }

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls) {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls) {
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }

    public Action Bowl(int pins) { //TODO make private
        
        if(pins < 0 || pins > 10) { throw new UnityException("Invalid number of pins"); }

        bowls[bowl - 1] = pins;
        //last frame logic
        if(bowl == 21) {
            return Action.EndGame;
        }

        if (bowl == 20 && bowls[18] == 10 && pins < 10) {
            bowl++;
            return Action.Tidy;
        }
        
        if(bowl >= 19 && Bowl21Awarded()) {
            bowl++;
            return Action.Reset;
        }else if (bowl == 20 && !Bowl21Awarded()) {
            return Action.EndGame;
        }



        //handle strike on first roll of frame
        if (pins == 10 && bowl % 2 == 1) {
            bowl += 2;
            return Action.EndTurn;
        }

        if(bowl % 2 == 1) {
            bowl ++;
            return Action.Tidy;
        }
        else if (bowl % 2 == 0){
            bowl++;
            return Action.EndTurn;
        }

        // other behaviour here
        throw new UnityException("Not sure what action to return");
    }

    private bool Bowl21Awarded() {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }

}

//   |01|02|  ...  |15|16|   |17|18|  |19|20|21|