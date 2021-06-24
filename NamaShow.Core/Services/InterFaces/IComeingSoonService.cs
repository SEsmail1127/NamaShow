using NamaShow.Core.VeiwModels.ComeingSoonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services.InterFaces
{
   public interface IComeingSoonService
    {
        bool IsExisteComeingSoon(string id);
        void AddComeingSoonForAdmin(CreateComeingSoon model);
        void EditComeingSoonForAdmin(EditComeingSoon model);
        List<IndexComeingSoon> IndexOfComeingSoonrForAdmin();
        EditComeingSoon GetComeingSoonForEditById(string id);
        void DeletComeingSoon(string id);

        List<VeiwModels.ComeingSoon.ComeingSoonForLandingVM> ListOfComeingSoonForLanding();
    }
}
