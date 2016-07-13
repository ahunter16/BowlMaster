using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Linq;

public class ActionMasterTest {

    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    

    [SetUp]
    public void Setup() {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }
    /*
    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    
    [Test]
    public void T02Bowl8ReturnsTidy() {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }
    
    [Test]
    public void T03Bowl28ReturnsEndTurn() {
        int[] rolls = { 8, 2 };
        
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T04CheckResetAtStrikeInLastFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,10};
       
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T05CheckResetAtSpareInLastFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5 }; //18 bowls

        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T06YouTubeRollsEndInEndGame() {
        //https://www.youtube.com/watch?v=aBe71sD8o8c
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };


        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T07GameEndsAtBowl20() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1 };


        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T08TidyAfterStrikeAtBowl19() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 }; //18 bowls

        
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T09TidyAfterGutterOnBowl20() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 }; //18 bowls
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    

    [Test]
    public void T10TreatStrikeonEvenRollAsSpare() {
        int[] rolls = {0,10,5,1}; 

        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T11Dondi10thFrameTurkey() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    */
}
