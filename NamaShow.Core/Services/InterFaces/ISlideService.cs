using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamaShow.Core.VeiwModels.Slider;
using NamaShow.DataLayer.Entities.Landing;

namespace NamaShow.Core.Services.InterFaces
{
    public interface ISlideService
    {
        //void AddSlide(Slide slide);
        //void UpdateSlide(Slide slide);
        //void DeleteSlide(int id);
        //Slide GetSlideById(int id);
        //List<Slide> GetListSlideOfSlide (int page);
        //void ShowSlide(int id);


        bool IsExisteSlide(string id);
        void AddSlideForAdmin(CreateSliderForAdmin model);
        void EditSlideForAdmin(EditSliderForAdmin model);
        List<IndexSliderForAdmin> IndexOfSliderForAdmin();
        EditSliderForAdmin GetSlideForEditById(string id);
        void DeletSlide(string id);
        List<SliderForLandingVM> ListOfSlideForLanding();
    }
}
