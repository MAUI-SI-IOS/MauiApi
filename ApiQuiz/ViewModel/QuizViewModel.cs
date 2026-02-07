using ApiQuiz.GameService;
using ApiQuiz.Logic.ApiService;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.ViewModel
{
    //to test
    public partial class QuizViewModel<T> : ObservableObject
    {
        T game;
        public QuizViewModel(UrlBuilder builder, IGame<T> factory)
        {
           this.game = factory.play();
        }

        
        
    }
}
