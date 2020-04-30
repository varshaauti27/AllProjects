using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.BLL
{
    public class GameManager
    {
        private IChoiceGetter _chooser;
        public string _guessWord;
        private List<char> _guess = new List<char>();
        List<char> _miss = new List<char>();
        private char[] _tempString;
           
        // Constructor Injection
        public GameManager(IChoiceGetter concrete)
        {
            _chooser = concrete;
            _guessWord = _chooser.GetChoice().ToString().ToUpper();
            _tempString = new char[_guessWord.Length];

            for (int i = 0; i < _guessWord.Length; i++)
            {
                _tempString[i] = '_';
            }
            //Console.WriteLine(" >>>>>>>>>" +_guessWord);
        }

        public PlayRoundResponse PlayRound(char guess)
        {
            PlayRoundResponse response = new PlayRoundResponse();
            if (_guessWord.Contains(guess))
            {
                _guess.Add(guess);
            }
            else
            {
                _miss.Add(guess);
            }
            response.Guess = _guess;
            response.Miss = _miss;

            int foundPos = -1;
            int startPos = 0;
            do
            {
                foundPos = _guessWord.IndexOf(guess, startPos);
                if (foundPos > -1)
                {
                    _tempString[foundPos] = guess;
                    startPos = foundPos + 1;
                }
            } while (foundPos > -1);

            response.UpdatedString = _tempString;

            if (new string(_tempString).Equals(_guessWord))
            {
                response.Result = GameResult.Win;
            }
            else
            {
                response.Result = GameResult.Loss;
            }
           
            return response;
        }
    }
}
