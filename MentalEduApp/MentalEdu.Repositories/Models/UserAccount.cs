﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MentalEdu.Repositories.Models;

public partial class UserAccount
{
    public int UserAccountId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string EmployeeCode { get; set; }

    public int RoleId { get; set; }

    public string RequestCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string ApplicationCode { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Appointment> AppointmentPsychologists { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentStudents { get; set; } = new List<Appointment>();

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<CounselingSession> CounselingSessions { get; set; } = new List<CounselingSession>();

    public virtual ICollection<Psychologist> Psychologists { get; set; } = new List<Psychologist>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SessionFeedback> SessionFeedbacks { get; set; } = new List<SessionFeedback>();

    public virtual ICollection<SupportProgram> SupportPrograms { get; set; } = new List<SupportProgram>();

    public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();

    public virtual ICollection<UserProgram> UserPrograms { get; set; } = new List<UserProgram>();
}