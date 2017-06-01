using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;

namespace HairbookWebApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Base, BaseDto>();
            CreateMap<BaseDto, Base>();
            //.ForMember(dest => dest.CreatedUserId, opt => opt.MapFrom(src => src.CreatedUserId));

            CreateMap<Memo, MemoDto>();
            CreateMap<MemoDto, Memo>();

            CreateMap<MemoEvaluation, MemoEvaluationDto>();
            CreateMap<MemoEvaluationDto, MemoEvaluation>();

            CreateMap<MemoTag, MemoTagDto>();
            CreateMap<MemoTagDto, MemoTag>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<PostEvaluation, PostEvaluationDto>();
            CreateMap<PostEvaluationDto, PostEvaluation>();

            CreateMap<PostTag, PostTagDto>();
            CreateMap<PostTagDto, PostTag>();

            CreateMap<PostUpload, PostUploadDto>();
            CreateMap<PostUploadDto, PostUpload>();

            CreateMap<Salon, SalonDto>();
            CreateMap<SalonDto, Salon>();
            
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserFriend, UserFriendDto>();
            CreateMap<UserFriendDto, UserFriend>();
        }
    }
}
