using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSpbkk.Models;
using UTSpbkk.Services;
using UTSpbkk.Views;

namespace UTSpbkk.ViewModels
{
    public partial class KontakListPageViewModel : ObservableObject
    {
        public ObservableCollection<KontakModel> Kontaks { get; set; } = new ObservableCollection<KontakModel>();

        private readonly IKontakService _kontakService;
        public KontakListPageViewModel(IKontakService kontakService)
        {
            _kontakService = kontakService;
        }

        [RelayCommand]
        private async void GetKontakList()
        {
            var kontakList = await _kontakService.GetKontakList();
            if (kontakList?.Count > 0)
            {
                Kontaks.Clear();
                foreach (var kontak in kontakList)
                {
                    Kontaks.Add(kontak);
                }
            }
        }


        [RelayCommand]
        public async void AddUpdateKontak()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateKontakDetail));
        }

        [RelayCommand]
        public async void DisplayAction(KontakModel kontakModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("KontakDetail", kontakModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateKontakDetail),navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _kontakService.DeleteKontak(kontakModel);
                if(delResponse>0)
                {
                    GetKontakList();
                }
            }
        }
    }
}
