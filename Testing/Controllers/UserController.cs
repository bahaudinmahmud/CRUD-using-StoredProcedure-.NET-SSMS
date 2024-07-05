using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Testing.Models;

namespace Testing.Controllers;
public class UserController : Controller {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public UserController(IConfiguration configuration) {

        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("TestDbConnection");
    }


    // GET: UserController
    //public ActionResult Index() {
    //    DataTable users = new DataTable();

    //    using (SqlConnection conn = new SqlConnection(_connectionString)) {
    //        conn.Open();
    //        using (SqlCommand cmd = new SqlCommand("GetAllUsers", conn)) {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
    //                da.Fill(users);
    //            }
    //        }
    //    }

    //    UserViewModel userModel = new UserViewModel {
    //        Users = users
    //    };

    //    return View(userModel);
    //}
    public ActionResult Index() {
        List<User> usersList = new List<User>();
        using (SqlConnection conn = new SqlConnection(_connectionString)) {
            conn.Open();    
            using (SqlCommand cmd = new SqlCommand("GetAllUsers1", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    // Jika banyak data

                    while (reader.Read()) {
                        User user = new User {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            NamaDepan = reader.GetString(reader.GetOrdinal("NamaDepan")),
                            JenisKelamin = reader.GetString(reader.GetOrdinal("JenisKelamin")),
                            //Hobby = reader.IsDBNull(reader.GetOrdinal("Hobby")) ? "Tidak Punya Hobby" : reader.GetString(reader.GetOrdinal("Hobby"))
                            Hobby = reader.IsDBNull(reader.GetOrdinal("Hobby")) ? null : reader.GetString(reader.GetOrdinal("Hobby"))
                        };
                        usersList.Add(user);
                    }
                }
            }
        }
        UserViewModel1 userViewModel1 = new UserViewModel1 {
            Users = usersList
        };
        return View(userViewModel1);
    }
    [HttpGet("Details")]
    public ActionResult Details(int id) {
        User user = new User();
        using (SqlConnection conn = new SqlConnection(_connectionString)) {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("GetUserById", conn)) {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    // Jika cuma satu data
                    if (reader.Read()) {
                        user.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                        user.NamaDepan = reader.GetString(reader.GetOrdinal("NamaDepan"));
                        user.JenisKelamin = reader.GetString(reader.GetOrdinal("JenisKelamin"));
                        user.Hobby = reader.IsDBNull(reader.GetOrdinal("Hobby")) ? "Tidak Punya Hobby" : reader.GetString(reader.GetOrdinal("Hobby"));

                    }
                }
            }
        }
        return View(user);
    }
    [HttpGet("Delete")]
    public ActionResult Delete(int id) {
        using (SqlConnection conn = new SqlConnection(_connectionString)) {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DeleteUserById", conn)) {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
        return RedirectToAction("Index");
    }
    [HttpGet("Insert")]
    public ActionResult Insert(int id) { 
        return View();
    }
    [HttpGet("Update")]
    public ActionResult Update(int id) {
        User user = new User();
        using (SqlConnection conn = new SqlConnection(_connectionString)) {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("GetUserById", conn)) {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        user.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                        user.NamaDepan = reader.GetString(reader.GetOrdinal("NamaDepan"));
                        user.JenisKelamin = reader.GetString(reader.GetOrdinal("JenisKelamin"));

                        // ini ada karena Hobby di db boleh nullll
                        user.Hobby = reader.IsDBNull(reader.GetOrdinal("Hobby")) ? null : reader.GetString(reader.GetOrdinal("Hobby"));
                    }
                }
            }
        }
        return View("Insert", user);
    }
    [HttpPost("Insert")]
    public ActionResult Insert(User user) {
        try {
            using (SqlConnection conn = new SqlConnection(_connectionString)) {
                conn.Open();
                string aksi = "UpdateUser";
                if (user.UserID == 0) {
                    aksi = "InsertNewUser";
                }
                using (SqlCommand cmd = new SqlCommand(aksi, conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!(user.UserID == 0)) {
                        cmd.Parameters.AddWithValue("@id", user.UserID);
                    }
                    cmd.Parameters.AddWithValue("@NamaDepan", user.NamaDepan);
                    cmd.Parameters.AddWithValue("@JenisKelamin", user.JenisKelamin);
                    cmd.Parameters.AddWithValue("@Hoby", (object)user.Hobby ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
        catch (Exception ex) {
            return View("Error");
        }
    }

}
