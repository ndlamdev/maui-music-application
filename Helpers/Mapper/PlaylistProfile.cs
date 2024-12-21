using AutoMapper;
using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Helpers.Mapper;

public class PlaylistProfile : Profile
{
    public PlaylistProfile()
    {
        CreateMap<ResponsePlaylistCard, PlaylistDetail>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.Thumbnail, opt => opt.MapFrom(src => src.CoverUrl));
    }
}