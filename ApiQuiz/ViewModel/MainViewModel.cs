using ApiQuiz.Logic.ApiService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiQuiz.ViewModel
{
    //information 
    //https://www.youtube.com/watch?v=5Qga2pniN78&list=PLdo4fOcmZ0oUBAdL2NwBpDs32zwGqb9DY&index=5
    public partial class MainViewModel : ObservableObject
    {
        private readonly UrlBuilder builder;

        [ObservableProperty]
        List<string> categories;

        public MainViewModel(UrlBuilder builder)
        {
            this.builder = builder;
            categories = Enum.GetNames(typeof(Category)).ToList();

            //set value by default
            SelectedCategory = Category.GeneralKnowledge.ToString();
            amount = 10;
        }

        [ObservableProperty]
        string selectedCategory;
        [ObservableProperty]
        short amount;

        [ObservableProperty]
        string errCategoryMessage;
        [ObservableProperty]
        string errTextMessage;

        partial void OnSelectedCategoryChanged(string value) => SanitizeCategory();
        partial void OnAmountChanged(short value) => SanitizeAmount();

        [RelayCommand]
        void SanitizeAmount() {
            UrlBuilder builder = new UrlBuilder();
            ErrTextMessage = this.builder.TrySetAmount(amount);
        }

        [RelayCommand]
        void SanitizeCategory()
        {
            ErrTextMessage = this.builder.TrySetCategory(selectedCategory);
        }    
    }
}
