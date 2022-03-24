using Plugin.Media.Abstractions;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TP03.ViewModels.Commands;
using TP03.ViewModels.Services;
using TP03.Views;
using Xamarin.Essentials;

namespace TP03.ViewModels
{
    public class ScanVM : INotifyPropertyChanged
    {
        private string _stateLabelMessage;
        private string _ageLabelMessage;
        private string _sexLabelMessage;
        private bool _analysisState;
        private int _laserTranslation;
        private bool _laserVisibility;
        private SpeechOptions _speechOptions;

        public ScanPage page;
        public string StateLabelMessage
        {
            get { return _stateLabelMessage; }
            set
            {
                _stateLabelMessage = value;
                OnPropertyChanged("StateLabelMessage");
            }
        }

        public int LaserTranslation
        {
            get { return _laserTranslation; }
            set
            {
                _laserTranslation = value;
                OnPropertyChanged("LaserTranslation");
            }
        }

        public bool LaserVisibility
        {
            get { return _laserVisibility; }
            set
            {
                _laserVisibility = value;
                OnPropertyChanged("LaserVisibility");
            }
        }

        public bool AnalysisState
        {
            get { return _analysisState; }
            set
            {
                _analysisState = value;
                OnPropertyChanged("AnalysisState");
            }
        }

        public string SexLabelMessage
        {
            get { return _sexLabelMessage; }
            set
            {
                _sexLabelMessage = value;
                OnPropertyChanged("SexLabelMessage");
            }
        }

        public string AgeLabelMessage
        {
            get { return _ageLabelMessage; }
            set
            {
                _ageLabelMessage = value;
                OnPropertyChanged("AgeLabelMessage");
            }
        }

        public RedoPictureCommand RedoPictureCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ScanVM(ScanPage page, MediaFile file)
        {
            this.page = page;

            RedoPictureCommand = new RedoPictureCommand(this);

            GetInfosFromPicture(file);
            InitSpeechSettings();
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private async Task LaserAnimation()
        {
            bool moveDown = true;
            PlaySound("scan.wav");

            do
            {
                if (moveDown)
                {
                    LaserTranslation++;
                }
                else
                {
                    LaserTranslation--;
                }

                await Task.Delay(2);

                if (LaserTranslation <= 0)
                {
                    PlayCurrentSound();
                    moveDown = true;
                }
                else if (LaserTranslation >= 360) 
                {
                    PlayCurrentSound();
                    moveDown = false; 
                }


            } while (LaserVisibility);
        }

        private async Task PlaySound(string nom)
        {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStreamFromFile(nom));
            player.Play();
        }

        private async Task PlayCurrentSound()
        {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Play();
        }

        private async Task StopCurrentSound()
        {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Stop();
        }

        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("TP03.Assets." + filename);
            return stream;
        }

        private async Task InitSpeechSettings()
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            var french = locales.FirstOrDefault(locale => locale.Name.ToLower() == "fr");

            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 0.1f,
                Locale = french
            };

            _speechOptions = settings;
        }

        private async Task SaySomething(string text)
        {
            await TextToSpeech.SpeakAsync(text, _speechOptions);
        }

        private async Task GetInfosFromPicture(MediaFile file)
        {
            if (file != null)
            {
                StateLabelMessage = "Analyse en cours...";
                AgeLabelMessage = null;
                SexLabelMessage = null;
                AnalysisState = false;
                LaserVisibility = true;

                LaserAnimation();


                var result = await CognitiveService.FaceDetect(file);

                if (result == null)
                {
                    LaserVisibility = false;
                    PlaySound("result.wav");
                    AnalysisState = true;
                    await SaySomething("Spécimen inconnu");
                    StateLabelMessage = "Analyse échouée...";
                }
                else
                {
                    LaserVisibility = false;
                    StopCurrentSound();
                    PlaySound("result.wav");
                    AnalysisState = true;
                    await SaySomething("Humain détecté");
                    StateLabelMessage = "Analyse terminée !";
                    AgeLabelMessage = result.faceAttributes.age.ToString();
                    SexLabelMessage = result.faceAttributes.gender == "male" ? "M" : "F";
                    await SaySomething("Sexe");
                    if (SexLabelMessage == "M") await SaySomething("Masculin");
                    else await SaySomething("Féminin");
                    await SaySomething("âge");
                    await SaySomething(AgeLabelMessage);
                }
            }
        }

        public void RedoPicture()
        {
            page.Navigation.PopAsync();
        }
    }
}
