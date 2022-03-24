using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TP01.Models.Enums;
using TP01.ViewModels.Commands;
using TP01.Views;

namespace TP01.ViewModels
{
    public class GameVM : INotifyPropertyChanged
    {
        private int _nbrGuess;
        private int _mysteryNumber;
        private GamePage _page;
        private int _nbrOfAttempts;
        private bool isWon;
        private int minValue;
        private int maxValue;

        public int NbrGuess
        {
            get => _nbrGuess;
            set
            {
                _nbrGuess = value;
                OnPropertyChanged("NbrGuess");
            }
        }

        public int NbrOfAttempts
        {
            get => _nbrOfAttempts;
            set
            {
                _nbrOfAttempts = value;
                OnPropertyChanged("NbrOfAttempts");
            }
        }

        public int MysteryNumber
        {
            get => _mysteryNumber;
            set
            {
                _mysteryNumber = value;
                OnPropertyChanged("MysteryNumber");
            }
        }

        public bool IsWon
        {
            get => isWon;
            set
            {
                isWon = value;
                OnPropertyChanged("IsWon");
            }
        }

        public int MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                OnPropertyChanged("MinValue");
            }
        }

        public int MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                OnPropertyChanged("MaxValue");
            }
        }

        public string MinMaxText { get; set; }

        public TestNumberCommand TestNumberCommand { get; set; }
        public TryAgainCommand TryAgainCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public GameVM(GamePage page, Difficulties difficulty)
        {
            _page = page;

            switch(difficulty)
            {
                case Difficulties.Facile:
                    MinValue = 0;
                    MaxValue = 10;
                    break;
                case Difficulties.Normal:
                    MinValue = 0;
                    MaxValue = 100;
                    break;
                case Difficulties.Difficile:
                    MinValue = 0;
                    MaxValue = 1000;
                    break;
                case Difficulties.Cauchemard:
                    MinValue = -666;
                    MaxValue = 666;
                    break;
                default:
                    break;
            }

            MysteryNumber = new Random().Next(MinValue, MaxValue+1);
            MinMaxText = $"entre {MinValue} et {MaxValue}";

            TestNumberCommand = new TestNumberCommand(this);
            TryAgainCommand = new TryAgainCommand(this);
        }

        public GameVM()
        {

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TestMysteryNumber()
        {
            NbrOfAttempts++;

            if (NbrGuess == MysteryNumber)
            {
                ReturnToMainPage();                
            }
            else if (MysteryNumber > NbrGuess)
            {
                _page.DisplayAlert("Trop petit", $"Le nombre mystère est plus grand que {NbrGuess}", "Recommencer");
            }
            else if (_mysteryNumber < NbrGuess)
            {
                _page.DisplayAlert("Trop grand", $"Le nombre mystère est plus petit que {NbrGuess}", "Recommencer");
            }

            NbrGuess = 0;
        }

        private async void ReturnToMainPage()
        {
            await _page.DisplayAlert("Félicitations", $"Vous avez gagné en {NbrOfAttempts} essais !", "OK");
            _page.Navigation.PopAsync();
        }

        public void GenerateNewNumber()
        {
            isWon = false;
            MysteryNumber = new Random().Next(MinValue, MaxValue+1);
            NbrOfAttempts = 0;
        }
    }
}