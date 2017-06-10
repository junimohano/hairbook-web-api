using System.Collections.Generic;
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
            
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<PostEvaluation, PostEvaluationDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostEvaluationDto, PostEvaluation>();

            CreateMap<PostComment, PostCommentDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostCommentDto, PostComment>();

            CreateMap<PostUpload, PostUploadDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
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
