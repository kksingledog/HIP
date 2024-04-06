using System.Data.SqlClient;
namespace hospital.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
public class DBconnect
{
    //連結字串
    private readonly string ConnString = "Data Source=LAPTOP-6MBN5HHV;Initial Catalog=hospital;Integrated Security=True";
    //傳出新聞界面所需資料
    public List<Newsdata> GetNewsdata()
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnString))
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM NewsData");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Newsdata> newslist = new List<Newsdata>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Newsdata Newsobj = new Newsdata();
                    Newsobj.News_Href = reader.GetString(reader.GetOrdinal("News_Href"));
                    Newsobj.News_Titles = reader.GetString(reader.GetOrdinal("News_Titles"));
                    Newsobj.News_Times = reader.GetString(reader.GetOrdinal("News_Times"));
                    Newsobj.News_Artical = reader.GetString(reader.GetOrdinal("News_Artical"));
                    newslist.Add(Newsobj);
                }
                Console.WriteLine("test");
                return newslist;
            }
            else
            {
                Console.WriteLine("資料庫為空或內容索引出錯！");
                sqlConnection.Close();
                return null;
            }
        }
    }
    //傳出假新聞界面所需資料
    public List<Newsdata> GetFakeNewsdata()
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnString))
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM FakeNewsData");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Newsdata> fakenewslist = new List<Newsdata>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Newsdata Newsobj = new Newsdata();
                    Newsobj.News_Href = reader.GetString(reader.GetOrdinal("News_Href"));
                    Newsobj.News_Titles = reader.GetString(reader.GetOrdinal("News_Titles"));
                    Newsobj.News_Times = reader.GetString(reader.GetOrdinal("News_Times"));
                    Newsobj.News_Artical = reader.GetString(reader.GetOrdinal("News_Artical"));
                    fakenewslist.Add(Newsobj);
                }
                Console.WriteLine("test");
                return fakenewslist;
            }
            else
            {
                Console.WriteLine("資料庫為空或內容索引出錯！");
                sqlConnection.Close();
                return null;
            }
        }
    }
    //傳出醫院評價系統介面所需資料
    public (List<HospitalCommentdata>, List<HospitalINF>) GetHospitalCommentdata()
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnString))
        {
            List<HospitalCommentdata> HospitalCommentslist = new List<HospitalCommentdata>();
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM HospitalComment"))
            {
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine("t");
                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {
                            HospitalCommentdata HospitalCommentsobj = new HospitalCommentdata();
                            HospitalCommentsobj.HospitalComment_HospitalName = reader.GetString(reader.GetOrdinal("HospitalComment_HospitalName"));
                            HospitalCommentsobj.HospitalComment_Name = reader.GetString(reader.GetOrdinal("HospitalComment_Name"));
                            HospitalCommentsobj.HospitalComment_Time = reader.GetString(reader.GetOrdinal("HospitalComment_Time"));
                            HospitalCommentsobj.HospitalComment_Star = reader.GetInt32(reader.GetOrdinal("HospitalComment_Star"));
                            HospitalCommentsobj.HospitalComment_Positive= reader.GetString(reader.GetOrdinal("HospitalComment_Positive"));
                            HospitalCommentsobj.HospitalComment_Comment = reader.GetString(reader.GetOrdinal("HospitalComment_Comment"));
                            HospitalCommentslist.Add(HospitalCommentsobj);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("獲取醫院評論過程中出錯");
                    }
                }
                else
                {
                    Console.WriteLine("資料庫為空");
                    sqlConnection.Close();
                    return (null,null);
                }
            }
            sqlConnection.Close();
            Console.WriteLine("t");

            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM HospitalINF"))
            {
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<HospitalINF> HospitalINFlist = new List<HospitalINF>();
                Console.WriteLine("t");
                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {
                            HospitalINF HospitalINFsobj = new HospitalINF();
                            HospitalINFsobj.Hospital_Name = reader.GetString(reader.GetOrdinal("Hospital_Name"));
                            HospitalINFsobj.Hospital_Address = reader.GetString(reader.GetOrdinal("Hospital_Address"));
                            HospitalINFsobj.Hospital_Star = reader.GetInt32(reader.GetOrdinal("Hospital_Star"));
                            HospitalINFsobj.Hospital_Phone = reader.GetString(reader.GetOrdinal("Hospital_Phone"));
                            HospitalINFsobj.Hospital_Department = reader.GetString(reader.GetOrdinal("Hospital_Department"));
                            HospitalINFlist.Add(HospitalINFsobj);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("獲取醫院基本資料過程中出錯");
                    }
                }
                else
                {
                    Console.WriteLine("資料庫為空");
                    sqlConnection.Close();
                    return (null, null);
                }
                return (HospitalCommentslist, HospitalINFlist);
            }
        }

    }
    //傳入醫院介面評論之資料
    public string PutHospitalCommentdata(HospitalCommentdata data)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnString))
        {
            using (SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO HospitalComment
                                                   (HospitalComment_HospitalName
                                                   ,HospitalComment_Name
                                                   ,HospitalComment_Time
                                                   ,HospitalComment_Star
                                                   ,HospitalComment_Positive
                                                   ,HospitalComment_Comment)
                                                    VALUES (@HospitalComment_HospitalName,@HospitalComment_Name,@HospitalComment_Time,@HospitalComment_Star,@HospitalComment_Positive,@HospitalComment_Comment)"))
            {
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@HospitalComment_HospitalName", data.HospitalComment_HospitalName));
                    sqlCommand.Parameters.Add(new SqlParameter("@HospitalComment_Name", data.HospitalComment_Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@HospitalComment_Time", data.HospitalComment_Time));
                    sqlCommand.Parameters.Add(new SqlParameter("@HospitalComment_Star", data.HospitalComment_Star));
                    sqlCommand.Parameters.Add(new SqlParameter("@HospitalComment_Positive", data.HospitalComment_Positive));
                    sqlCommand.Parameters.Add(new SqlParameter("@HospitalComment_Comment", data.HospitalComment_Comment));
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return "插入資料醫院介面評論過程中出現問題";
                }
                return "";
            }
        }
    }
    //傳出醫生評價系統介面所需資料
    public (List<DoctorCommentdata>, List<DoctorINF>) GetDoctorCommentdata()
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnString))
        {
            List<DoctorCommentdata> DoctorCommentslist = new List<DoctorCommentdata>();
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DoctorComment"))
            {
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine("t");
                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {
                            DoctorCommentdata DoctorCommentsobj = new DoctorCommentdata();
                            DoctorCommentsobj.DoctorComment_DoctorName = reader.GetString(reader.GetOrdinal("DoctorComment_DoctorName"));
                            DoctorCommentsobj.DoctorComment_Name = reader.GetString(reader.GetOrdinal("DoctorComment_Name"));
                            DoctorCommentsobj.DoctorComment_Time = reader.GetString(reader.GetOrdinal("DoctorComment_Time"));
                            DoctorCommentsobj.DoctorComment_Star = reader.GetInt32(reader.GetOrdinal("DoctorComment_Star"));
                            DoctorCommentsobj.DoctorComment_Positive = reader.GetString(reader.GetOrdinal("DoctorComment_Positive"));
                            DoctorCommentsobj.DoctorComment_Comment = reader.GetString(reader.GetOrdinal("DoctorComment_Comment"));
                            DoctorCommentslist.Add(DoctorCommentsobj);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("獲取醫生評論過程中出錯");
                    }
                }
                else
                {
                    Console.WriteLine("資料庫為空");
                    sqlConnection.Close();
                    return (null, null);
                }
            }
            sqlConnection.Close();
            Console.WriteLine("t");

            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DoctorINF"))
            {
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<DoctorINF> DoctorINFlist = new List<DoctorINF>();
                Console.WriteLine("t");
                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {
                            DoctorINF DoctorINFsobj = new DoctorINF();
                            DoctorINFsobj.Doctor_Name = reader.GetString(reader.GetOrdinal("Doctor_Name"));
                            DoctorINFsobj.Doctor_Address = reader.GetString(reader.GetOrdinal("Doctor_Address"));
                            DoctorINFsobj.Doctor_Star = reader.GetInt32(reader.GetOrdinal("Doctor_Star"));
                            DoctorINFsobj.Doctor_Phone = reader.GetString(reader.GetOrdinal("Doctor_Phone"));
                            DoctorINFsobj.Doctor_Department = reader.GetString(reader.GetOrdinal("Doctor_Department"));
                            DoctorINFlist.Add(DoctorINFsobj);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("獲取醫生基本資料過程中出錯");
                    }
                }
                else
                {
                    Console.WriteLine("資料庫為空");
                    sqlConnection.Close();
                    return (null, null);
                }
                return (DoctorCommentslist, DoctorINFlist);
            }
        }

    }
    //傳入醫生介面評論之資料
    public string PutDoctorCommentdata(DoctorCommentdata data)
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnString))
        {
            using (SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO DoctorComment
                                                   (DoctorComment_DoctorName
                                                   ,DoctorComment_Name
                                                   ,DoctorComment_Time
                                                   ,DoctorComment_Star
                                                   ,DoctorComment_Positive
                                                   ,DoctorComment_Comment)
                                                    VALUES (@DoctorComment_DoctorName,@DoctorComment_Name,@DoctorComment_Time,@DoctorComment_Star,@DoctorComment_Positive,@DoctorComment_Comment)"))
            {
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@DoctorComment_DoctorName", data.DoctorComment_DoctorName));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoctorComment_Name", data.DoctorComment_Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoctorComment_Time", data.DoctorComment_Time));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoctorComment_Star", data.DoctorComment_Star));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoctorComment_Positive", data.DoctorComment_Positive));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoctorComment_Comment", data.DoctorComment_Comment));
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "插入資料醫生介面評論過程中出現問題";
                }
                return "";
            }
        }
    }


    /*
    //建立顧客資料，用於註冊
    public void CreateCustomer(Newsdata data)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Insert into Customer (name,gender,balance,account,password) values (@name,@gender,@balance,@account,@password)");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@name", data.name));
        sqlCommand.Parameters.Add(new SqlParameter("@gender", data.gender));
        sqlCommand.Parameters.Add(new SqlParameter("@balance", data.balance));
        sqlCommand.Parameters.Add(new SqlParameter("@account", data.account));
        sqlCommand.Parameters.Add(new SqlParameter("@password", data.password));
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
    }
    //確認帳號是否重複，密碼可重複，用於註冊
    public bool AccountRepeat(string account)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Select * from Customer where account=@account");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@account", account));
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        int count = 0;
        while (reader.Read())
        {
            count++;
        }
        sqlConnection.Close();
        return count > 0;
    }
    //確認帳號是否重複，密碼可重複，用於修改顧客資訊
    public bool AccountRepeat(string account, int Accid)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Select * from Customer where account=@account and Accid<>@Accid");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@account", account));
        sqlCommand.Parameters.Add(new SqlParameter("@Accid", Accid));
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        int count = 0;
        while (reader.Read())//從資料庫讀取使用者資訊
        {
            count++;
        }
        sqlConnection.Close();
        return count > 0;
    }
    //判定能否登入
    public Newsdata Loginscure(Newsdata data)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand("select * from Customer where account = @account and password = @password");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.AddWithValue("@account", data.account);
        sqlCommand.Parameters.AddWithValue("@password", data.password);
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        string name;
        int Accid;
        Newsdata flag = data;
        while (reader.Read())
        {
            Accid = (int)reader["Accid"];
            name = reader["name"].ToString();
            flag.AccID = Accid;
            flag.name = name;
        }
        reader.Close();
        sqlConnection.Close();
        return flag;
    }
    //修改客戶資料
    public void UpdateCustomer(Newsdata data, string x)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Update Customer SET name=@name,gender=@gender,account=@account,password=@password where account=@x");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@name", data.name));
        sqlCommand.Parameters.Add(new SqlParameter("@gender", data.gender));
        sqlCommand.Parameters.Add(new SqlParameter("@balance", data.balance));
        sqlCommand.Parameters.Add(new SqlParameter("@account", data.account));
        sqlCommand.Parameters.Add(new SqlParameter("@password", data.password));
        sqlCommand.Parameters.Add(new SqlParameter("@x", x));
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
    }
    //產生交易紀錄
    public void Moneyoperation(int Accid, int amount, int balance)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Insert into tranctivelog (Accid,amount,balance) values (@Accid,@amount,@balance)");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@Accid", Accid));
        sqlCommand.Parameters.Add(new SqlParameter("@amount", amount));
        sqlCommand.Parameters.Add(new SqlParameter("@balance", balance));
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
    }
    //獲得該帳戶的餘額
    public int GetBalance(int Accid)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Select Top 1 balance  from tranctivelog where Accid=@Accid order by trandate Desc");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@Accid", Accid));
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        int balance = 0;
        while (reader.Read())
        {
            balance = (int)reader["balance"];
        }
        reader.Close();
        sqlConnection.Close();
        return balance;
    }
    //轉帳
    public void TransfetMoney(int Accid1, int amount1, int balance1, int Accid2, int amount2, int balance2)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        SqlTransaction transaction = sqlConnection.BeginTransaction("TransferMoney");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Transaction = transaction;
        try
        {
            sqlCommand.CommandText =
                "Insert into tranctivelog (Accid, amount,balance) VALUES (@Accid1, @amount1,@balance1)";
            sqlCommand.Parameters.Add(new SqlParameter("@Accid1", Accid1));
            sqlCommand.Parameters.Add(new SqlParameter("@amount1", amount1));
            sqlCommand.Parameters.Add(new SqlParameter("@balance1", balance1));
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText =
                "Insert into tranctivelog (Accid, amount,balance) VALUES (@Accid2, @amount2,@balance2)";
            sqlCommand.Parameters.Add(new SqlParameter("@Accid2", Accid2));
            sqlCommand.Parameters.Add(new SqlParameter("@amount2", amount2));
            sqlCommand.Parameters.Add(new SqlParameter("@balance2", balance2));
            sqlCommand.ExecuteNonQuery();
            transaction.Commit();
            Console.WriteLine("Both records are written to database.");
        }
        catch
        {
            transaction.Rollback();
        }
        finally
        {
            sqlConnection.Close();
        }
    }
    //確認Accid是否存在，用於轉帳
    public bool AccidCheck(int Accid)
    {
        SqlConnection sqlConnection = new SqlConnection(ConnString);
        SqlCommand sqlCommand = new SqlCommand(@"Select *  from Customer where Accid=@Accid ");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@Accid", Accid));
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        int count = 0;
        while (reader.Read())//從資料庫讀取使用者資訊
        {
            count++;
        }
        reader.Close();//查詢關閉
        sqlConnection.Close();
        return count > 0;
    }
    */
}

