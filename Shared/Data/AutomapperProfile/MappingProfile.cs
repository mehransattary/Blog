using AutoMapper;
using Data.Dto;
using Entities;

namespace Data.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
    
            #region Setting
            CreateMap<Settings, SettingsDto>()
             .ForMember(dest => dest.Settings_ImageFooter, o => o.Ignore())
             .ForMember(dest => dest.Settings_ImageTopMain, o => o.Ignore());
            CreateMap<AbouteMe, AbouteMeDto>()
                .ForMember(dest => dest.AbouteMe_Image, o => o.Ignore())
                .ForMember(dest => dest.Image_Meta, o => o.Ignore());
            CreateMap<ContactUs, ContactUsDto>()
                 .ForMember(dest => dest.ContactUs_Image, o => o.Ignore())
                 .ForMember(dest => dest.Image_Meta, o => o.Ignore());

            CreateMap<WebLog_SliderDto, WebLog_Slider>().ForMember(dest => dest.WebLog_Slider_Image, o => o.Ignore());
            CreateMap<WebLog_Slider, WebLog_SliderDto>().ForMember(dest => dest.WebLog_Slider_Image, o => o.Ignore());


            #endregion

        }

    }
}
