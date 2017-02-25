using AutoMapper;
using One.Bo;
using One.Domain;
using ONE.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ONE.App_Start
{
    public class AutomapperConfig
    {
        public void Register()
        {
            Mapper.CreateMap<Student, StudentBo>();
            Mapper.CreateMap<StudentBo, StudentViewModel>();
            Mapper.CreateMap<StudentViewModel, StudentBo>();
            Mapper.CreateMap<StudentBo, Student>();

            Mapper.CreateMap<School, SchoolBo>();
            Mapper.CreateMap<SchoolBo, School>();
            Mapper.CreateMap<SchoolBo, SchoolViewModel>();
            Mapper.CreateMap<SchoolViewModel, SchoolBo>();

            Mapper.CreateMap<Streem, StreemBo>();
            Mapper.CreateMap<StreemBo, Streem>();
            Mapper.CreateMap<StreemBo, StreemViewModel>();
            Mapper.CreateMap<StreemViewModel, StreemBo>();

            Mapper.CreateMap<UserAuthonticationBo, UserAuthontication>();
            Mapper.CreateMap<UserAuthontication, UserAuthonticationBo>();
        }
    }
}