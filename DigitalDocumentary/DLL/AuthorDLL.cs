using DigitalDocumentary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalDocumentary.DLL
{
    internal class AuthorDLL
    {
        private List<AuthorDTO> authors = new List<AuthorDTO>();
        private DatabaseContextDLL db = new DatabaseContextDLL();
        public AuthorDLL()
        {

        }
        public List<AuthorDTO> Load()
        {
            authors.Clear();
            SqlDataReader rd = db.Select(AuthorDTO.Table);
            while(rd.Read())
            {
                AuthorDTO author = new AuthorDTO();
                author.Name = rd["name"].ToString();
                author.Description = rd["description"].ToString();
                author.Email = rd["email"].ToString();
                author.Id = int.Parse(rd["id"].ToString());
                authors.Add(author);
            }
            return authors;
        }
        public int Add(AuthorDTO au)
        {

            string sql = $"INSERT INTO {AuthorDTO.Table} (name, email, phone, description) VALUES ('{au.Name}', '{au.Email}', '{au.Phone}', '{au.Description}')";
            return db.NonQuery(sql);
        }
        public int Update(AuthorDTO au)
        {
            string sql = $"UPDATE {AuthorDTO.Table} SET name = '{au.Name}', email = '{au.Email}', phone = '{au.Phone}', description = '{au.Description}' WHERE id = {au.Id}";
            return db.NonQuery(sql);
        }
        public int Delete(AuthorDTO au)
        {
            string sql = $"DELETE FROM {AuthorDTO.Table} WHERE id = {au.Id}";
            return db.NonQuery(sql);
        }
    }
}
