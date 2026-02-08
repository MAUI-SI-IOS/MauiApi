
﻿using ApiQuiz.Data;
using ApiQuiz.GameService;
using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.Data;
using ApiQuiz.Logic.GameService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApiQuiz.ViewModel
{
    //to test
    public partial class QuizViewModel<T> : ObservableObject
    {
        IGame game;
        private readonly IEnumerator<UIQuestion> _iterator;

        [ObservableProperty]
        string str;
        [ObservableProperty]
        (int, string)[] answers;


        public QuizViewModel(IGameCreator creator)
        {
            game = creator.CreateGame();
            _iterator = game.GetEnumerator();

            GetQuestion();
        }

        [RelayCommand]
        public void GetQuestion()
        {
            if(_iterator.MoveNext())
            {
                Str     = _iterator.Current.question;
                Answers = _iterator.Current.array;
            }
            else
            {
                //end game
            }
        }
    }
}
