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

            Mapper.CreateMap<Subject, SubjectBo>();
            Mapper.CreateMap<SubjectViewModel, SubjectBo>();

            Mapper.CreateMap<StudentSubject, StudentSubjectBo>();
            Mapper.CreateMap<StudentSubjectViewModel, StudentSubjectBo>();
        }
    }
}