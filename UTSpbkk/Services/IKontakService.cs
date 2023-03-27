using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTSpbkk.Models;

namespace UTSpbkk.Services
{
    public interface IKontakService
    {
        Task<List<KontakModel>> GetKontakList();

        Task<int> AddKontak(KontakModel kontakModel);
        Task<int> DeleteKontak(KontakModel kontakModel);
        Task<int> UpdateKontak(KontakModel kontakModel);

    }
}
