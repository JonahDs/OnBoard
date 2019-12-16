﻿using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class SeatViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ICollection<int> _selectedSeats;
        public RelayCommand SelectUserCommand { get; set; }
        public RelayCommand SwitchSeatsCommand { get; set; }
       
        public bool HasTwoSeats => _selectedSeats.Count == 2;

        public SeatViewModel()
        {
            _selectedSeats = new ObservableCollection<int>();
            SelectUserCommand = new RelayCommand(seatnr => SelectUser((int)seatnr));
            SwitchSeatsCommand = new RelayCommand(_ => SwitchUsers());
        }


        private async void SwitchUsers()
        {
            var seatOne = _selectedSeats.First();
            var seatTwo = _selectedSeats.Last();
            try
            {
                Uri uri = new Uri($"http://localhost:50236/api/seat/switchSeats/{seatOne}/{seatTwo}");
                HttpStringContent content = new HttpStringContent("", Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                HttpResponseMessage message = await client.PutAsync(uri, content);
                message.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private void SelectUser(int seatnr)
        {
            if (_selectedSeats.Contains(seatnr))
                _selectedSeats.Remove(seatnr);
            else
            {
                _selectedSeats.Add(seatnr);
            }
            OnPropertyChanged(nameof(HasTwoSeats));
            if (_selectedSeats.Count > 2)
                ShowMessageDialog("You can only select 2 passengers to switch seats");
        }

        private async void ShowMessageDialog(string text)
        {
            var messageDialog = new MessageDialog(text);
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.Commands.Add(new UICommand("Close"));
            await messageDialog.ShowAsync();
        }




    }
}
