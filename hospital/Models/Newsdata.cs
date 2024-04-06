using System;
namespace hospital.Models
{
    //新聞資料類別
    public class Newsdata
    {
        public string News_Href { get; set; }
        public string News_Titles { get; set; }
        public string News_Times { get; set; }

        public string News_Artical { get; set; }

    }
    //醫院評論資料類別
    public class HospitalCommentdata
    {
        public string HospitalComment_HospitalName { get; set; }
        public string HospitalComment_Name { get; set; }
        public string HospitalComment_Time { get; set; }
        public int HospitalComment_Star { get; set; }
        public string HospitalComment_Positive{ get; set; }
        public string HospitalComment_Comment{ get; set; }

    }

    public class HospitalINF
    {
        public string Hospital_Name { get; set; }
        public int Hospital_Star { get; set; }
        public string Hospital_Address { get; set; }
        public string Hospital_Phone { get; set; }
        public string Hospital_Department { get; set; }
    }

      public class DoctorCommentdata
    {
        public string DoctorComment_DoctorName { get; set; }
        public string DoctorComment_Name { get; set; }
        public string DoctorComment_Time { get; set; }
        public int DoctorComment_Star { get; set; }
        public string DoctorComment_Positive{ get; set; }
        public string DoctorComment_Comment{ get; set; }

    }

    public class DoctorINF
    {
        public string Doctor_Name { get; set; }
        public int Doctor_Star { get; set; }
        public string Doctor_Address { get; set; }
        public string Doctor_Phone { get; set; }
        public string Doctor_Department { get; set; }
    }
}
