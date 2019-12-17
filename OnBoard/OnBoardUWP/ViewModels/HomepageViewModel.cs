using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    /// <summary>
    /// Provides data accessible to the entire app
    /// </summary>
    public class HomepageViewModel : BindableBase
    {
        private Flight _flight;

        public Flight Flight {
            get {
                return _flight;
            }
            set {
                Set(ref _flight, value);
            }
        }

        private Seat _seat;

        public Seat Seat {
            get {
                return _seat;
            }
            set {
                Set(ref _seat, value);
            }
        }

        private CrewMember _crewMember;

        public CrewMember CrewMember {
            get {
                return _crewMember;
            }
            set {
                Set(ref _crewMember, value);
            }
        }

        private bool _loading;
        public bool IsLoading { get { return _loading; } set { Set(ref _loading, value); } }

        private HttpClient client = new HttpClient();

        /// <summary>
        /// Creates a viewmodel and seeding the flight property
        /// </summary>
        public HomepageViewModel()
        {
            GetFlightInformation();
        }

        /// <summary>
        /// Calls the api for a flight object, making sure the call succeeds to only work with 20X messages
        /// </summary>
        /// <returns></returns>
        private async void GetFlightInformation()
        {
            try
            {
                Flight = await GlobalMethods.ApiCall<Flight>("http://localhost:50236/api/flight", client);
                Flight.Seats = Flight.Seats.OrderBy(f => f.SeatNumber);
            }
            catch(Exception ex)
            {
                var messageDialog = new MessageDialog("Can't connect to the api, restart application");
                messageDialog.Commands.Add(new UICommand("Close application"));
                await messageDialog.ShowAsync();
                Application.Current.Exit();
            }
        }

        public async Task GetSeatInstance(int seatNumber)
        {

            IsLoading = true;
            try
            {
                Seat = await GlobalMethods.ApiCall<Seat>($"http://localhost:50236/api/seat/{seatNumber}", client);
            }
            catch (Exception ex)
            {
                IsLoading = false;
                throw ex;
            }

        }

        public async Task GetCrewMemberInstance(int crewmemberId)
        {
            IsLoading = true;
            try
            {
                CrewMember = await GlobalMethods.ApiCall<CrewMember>($"http://localhost:50236/api/user/crewmember/{crewmemberId}", client);
            }
            catch (Exception ex)
            {
                IsLoading = false;
                throw ex;
            }
        }

        public void Refresh()
        {
            GetFlightInformation();
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
