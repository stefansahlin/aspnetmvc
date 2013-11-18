using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace s101.Models
{
    public struct GuessedNumber
    {      
            public int? number; //Gissningen. 
            public Outcome outcome;
    }

    public enum Outcome
    //hur sätter man get och set på den här         
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        OldGuess
    } 
}