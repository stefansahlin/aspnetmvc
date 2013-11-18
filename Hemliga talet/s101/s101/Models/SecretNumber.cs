using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace s101.Models
{
    public class SecretNumber
    {
     //Problem. Hur vet jag utanför loopen om användarens gissningar är slut för att de har passerat 7 eller för att rätt tal har gissats fram.    
        //Fält
        private const int maxNumberOfGuesses = 7;
        private int? _number;
        private List<GuessedNumber> _guessedNumbers;
       //private Outcome outcome;

        #region constructor
        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>(maxNumberOfGuesses);
           Initialize();
        }
        #endregion

        #region properties

        public bool CanMakeGuess
        {
            get
            {
                if (Count >= maxNumberOfGuesses || Guess == Number)
                {
                    return false;
                }

                return true; 
            }
        }

        public int? Number
        {
            get
            {
                 return _number;
            }
            set
            {
                _number = (int?)value;
            }
        }

        //[DisplayName("Gissning")]
        [Required(ErrorMessage = "Du måste skriva in ett heltal!")]
        [Range(1, 100, ErrorMessage="Skriv in ett heltal")]
        //[RegularExpression(@"^[0-9]$")]
       // [RegularExpression(@"^[0-9]+$")] //Does not work
        //Validering om användaren skriver in något annat tecken som inte ska vara där.
        public int? Guess
        {
            get;

            set;

        }

        public int Count
        {
            get { return _guessedNumbers.Count; }
        }

         
        public GuessedNumber? LastGuessedNumber
        {
            get { return GuessedNumbers[GuessedNumbers.Count-1];}
        }

        public List<GuessedNumber> GuessedNumbers
        {
            get { return _guessedNumbers;}
        }

        #endregion

        public void Initialize()
        {
            _guessedNumbers = new List<GuessedNumber>();
            _guessedNumbers.Clear();
            Random random = new Random();
            Number = random.Next(1, 101);
            Guess = null;
        }

        public Outcome MakeGuess()
        {

            if (!_guessedNumbers.Any(w => w.number == Guess)) 

            {
                GuessedNumber gn = new GuessedNumber();

                gn.number = Guess;
                if (Count >= maxNumberOfGuesses)
                {
                    gn.outcome = Outcome.NoMoreGuesses;

                }
                else if (Guess < Number)
                {
                    gn.outcome = Outcome.Low;

                }

                else if (Guess > Number)
                {
                    gn.outcome = Outcome.High;
                }

                else if (Guess == Number)
                {
                    gn.outcome = Outcome.Correct;
                }
                _guessedNumbers.Add(gn);

                return gn.outcome;
            }

            return Outcome.OldGuess; 
        }
    }   
}