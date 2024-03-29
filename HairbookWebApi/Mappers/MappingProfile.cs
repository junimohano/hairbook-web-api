﻿using System.Collections.Generic;
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

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<HairMenu, HairMenuDto>();
            CreateMap<HairMenuDto, HairMenu>();

            CreateMap<HairSubMenu, HairSubMenuDto>()
                .ForMember(x => x.HairMenu, opt => opt.Ignore());
            CreateMap<HairSubMenuDto, HairSubMenu>();

            CreateMap<HairType, HairTypeDto>();
            CreateMap<HairTypeDto, HairType>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<PostComment, PostCommentDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostCommentDto, PostComment>();

            CreateMap<PostEvaluation, PostEvaluationDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostEvaluationDto, PostEvaluation>();

            CreateMap<PostHairMenu, PostHairMenuDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostHairMenuDto, PostHairMenu>();

            CreateMap<PostHairType, PostHairTypeDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostHairTypeDto, PostHairType>();

            CreateMap<PostUpload, PostUploadDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostUploadDto, PostUpload>();

            CreateMap<PostFavorite, PostFavoriteDto>()
                .ForMember(x => x.Post, opt => opt.Ignore());
            CreateMap<PostFavoriteDto, PostFavorite>();

            CreateMap<Salon, SalonDto>();
            CreateMap<SalonDto, Salon>();
            
            CreateMap<User, UserDto>()
                .ForMember(x => x.PostFavorites, opt => opt.Ignore());
            CreateMap<UserDto, User>();

            CreateMap<UserFriend, UserFriendDto>()
                .ForMember(x => x.CreatedUser, opt => opt.Ignore())
                .ForMember(x => x.Friend, opt => opt.Ignore());
            CreateMap<UserFriendDto, UserFriend>();

        }
    }
}
