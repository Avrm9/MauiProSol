using APIService;
using Microsoft.Maui.Controls;
using Model; // Assuming you have models for Sport, League, Team, SpecialTeam, Player
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiPro
{
    public partial class Data : ContentPage
    {
        private readonly ApiService ApiService;
        public ObservableCollection<Sport> SportsList { get; set; }
        public ObservableCollection<League> LeaguesList { get; set; }
        public ObservableCollection<Team> TeamList { get; set; }
        public ObservableCollection<SpecialTeams> SpecialTeamsList { get; set; }
        public ObservableCollection<Player> PlayersList { get; set; }

        public Data()
        {
            InitializeComponent();
            ApiService = new ApiService();
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            SportsList = new ObservableCollection<Sport>(await ApiService.GetSports());
            LeaguesList = new ObservableCollection<League>(await ApiService.GetLeagues());
            TeamList = new ObservableCollection<Team>(await ApiService.GetTeams());
            SpecialTeamsList = new ObservableCollection<SpecialTeams>(await ApiService.GetSpecialTeamss());
            PlayersList = new ObservableCollection<Player>(await ApiService.GetPlayers());
            foreach (var item in SportsList)
            { 
                SportsLst.Add(new Label() { Text = $"{item.SportName}      ", TextColor = Color.FromRgb(255,255,255) });
                SportsLst.Add(new BoxView() { WidthRequest = 10 });
            }
            foreach (var item in LeaguesList)
            {
                LeaguesLst.Add(new Label() { Text = $"{item.LeagueName}      ", TextColor = Color.FromRgb(255, 255, 255) });
                LeaguesLst.Add(new BoxView() { WidthRequest = 10 });
            }
            foreach (var item in TeamList)
            {
                TeamLst.Add(new Label() { Text = $"{item.TeamName}      ", TextColor = Color.FromRgb(255, 255, 255) });
                TeamLst.Add(new BoxView() { WidthRequest = 10 });
            }
            foreach (var item in SpecialTeamsList)
            {
                SpecialLst.Add(new Label() { Text = $"{item.TeamName}      ", TextColor = Color.FromRgb(255, 255, 255) });
                SpecialLst.Add(new BoxView() { WidthRequest = 10 });
            }
            foreach (var item in PlayersList)
            {
                PlayerLst.Add(new Label() { Text = $"{item.PlayerName}      ", TextColor = Color.FromRgb(255, 255, 255) });
                PlayerLst.Add(new BoxView() { WidthRequest = 10 });
            }
            BindingContext = this;
        }
    }
}
