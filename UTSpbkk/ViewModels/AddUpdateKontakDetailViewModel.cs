using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSpbkk.Models;
using UTSpbkk.Services;

namespace UTSpbkk.ViewModels
{
    [QueryProperty(nameof(KontakDetail), "KontakDetail")]
    public partial class AddUpdateKontakDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private KontakModel _kontakDetail = new KontakModel();

        private readonly IKontakService _kontakService;
        public AddUpdateKontakDetailViewModel(IKontakService kontakService)
        {
            _kontakService = kontakService;
        }


        [RelayCommand]
        public async void AddUpdateKontak()
        {
            int response = -1;
            if (KontakDetail.IdKontak > 0)
            {
                response = await _kontakService.UpdateKontak(KontakDetail);
            }
            else
            {
                response = await _kontakService.AddKontak(new Models.KontakModel
                {
                    Nama = KontakDetail.Nama,
                    Perusahaan = KontakDetail.Perusahaan,
                    Email = KontakDetail.Email,
                    Telpkantor = KontakDetail.Telpkantor,
                    Telpprib = KontakDetail.Telpprib
                });
            }

            if (response > 0) 
            {
                await Shell.Current.DisplayAlert("Kontak Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }
    }
}
