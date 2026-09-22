using DataAccessLayer.DataAccess.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess.DatabaseConfig.DataConnections;
using DataAccessLayer.DataAccess.DatabaseConfig;

namespace DataAccessLayer.DataAccess
{
    public class ContactRepository : IContactRepository
    {

        public int Add(DtoContact entity)
        {
            int NewContactId = -1;

            try
            {
                using (SqlConnection connection = 
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = Contact_Queries.AddNewContact.ToString();
                        cmd.Connection = connection;

                        SqlParameter
                            FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50),
                            LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar, 50),
                            EmailParameter = new SqlParameter("@Email", SqlDbType.NVarChar, 100),
                            PhoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20),
                            AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar, 200),
                            CountryIDParameter = new SqlParameter("@CountryID", SqlDbType.Int);

                        FirstNameParameter.Value = entity.FirstName;
                        LastNameParameter.Value = entity.LastName;
                        EmailParameter.Value = entity.Email;
                        PhoneParameter.Value = entity.Phone;
                        AddressParameter.Value = entity.Address;
                        CountryIDParameter.Value = entity.CountryID;

                        cmd.Parameters.Add(FirstNameParameter);
                        cmd.Parameters.Add(LastNameParameter);
                        cmd.Parameters.Add(EmailParameter);
                        cmd.Parameters.Add(PhoneParameter);
                        cmd.Parameters.Add(AddressParameter);
                        cmd.Parameters.Add(CountryIDParameter);

                        object result = cmd.ExecuteScalar();

                        if (result != null) NewContactId = (int)result;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NewContactId;

        }

        public bool Delete(int id)
        {
            bool DeletedRecord = false;

            try
            {
                using (SqlConnection connection = 
                    new SqlConnection())
                {
                    connection.ConnectionString = ContactsDB_Connection.ContactsDBConnectionString;
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = Contact_Queries.DeleteContact;
                        cmd.Connection = connection;

                        SqlParameter
                            IDParameter = new SqlParameter("@ID", SqlDbType.Int);
                        IDParameter.Value = id;

                        cmd.Parameters.Add(IDParameter);

                        DeletedRecord = cmd.ExecuteNonQuery() > 0;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DeletedRecord;
        }

        public IEnumerable<DtoContact> GetAll()
        {
            List<DtoContact> allContacts = new List<DtoContact>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Contact_Queries.GetAll, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DtoContact contact = new DtoContact
                            {
                                ContactID = (int)reader["ContactID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"],
                                Address = (string)reader["Address"],
                                CountryID = (int)reader["CountryID"]
                            };

                            allContacts.Add(contact);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return allContacts;
        }

        public DtoContact GetById(int id)
        {

            DtoContact dtoContact = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                using (SqlCommand cmd =
                    new SqlCommand(Contact_Queries.GetContactByID, connection))
                {
                    connection.Open();

                    SqlParameter IDParameter = new SqlParameter("@ContactID", SqlDbType.Int);
                    IDParameter.Value = id;

                    cmd.Parameters.Add(IDParameter);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            dtoContact = new DtoContact
                            {
                                ContactID = (int)reader["ContactID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"],
                                Address = (string)reader["Address"],
                                CountryID = (int)reader["CountryID"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dtoContact;
        }

        public bool Update(DtoContact entity)
        {

            int RowsEffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(ContactsDB_Connection.ContactsDBConnectionString))
                {

                    connection.Open();

                    using (SqlCommand cmd =
                       new SqlCommand(Contact_Queries.Update, connection))
                    {

                        SqlParameter
                            ContactIDParameter = new SqlParameter("@ContactID", SqlDbType.Int),
                            FirstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50),
                            LastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar, 50),
                            EmailParameter = new SqlParameter("@Email", SqlDbType.NVarChar, 100),
                            PhoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20),
                            AddressParameter = new SqlParameter("@Address", SqlDbType.NVarChar, 200),
                            CountryIDParameter = new SqlParameter("@CountryID", SqlDbType.Int);

                        ContactIDParameter.Value = entity.ContactID;
                        FirstNameParameter.Value = entity.FirstName;
                        LastNameParameter.Value = entity.LastName;
                        EmailParameter.Value = entity.Email;
                        PhoneParameter.Value = entity.Phone;
                        AddressParameter.Value = entity.Address;
                        CountryIDParameter.Value = entity.CountryID;

                        cmd.Parameters.Add(ContactIDParameter);
                        cmd.Parameters.Add(FirstNameParameter);
                        cmd.Parameters.Add(LastNameParameter);
                        cmd.Parameters.Add(EmailParameter);
                        cmd.Parameters.Add(PhoneParameter);
                        cmd.Parameters.Add(AddressParameter);
                        cmd.Parameters.Add(CountryIDParameter);

                        RowsEffected = cmd.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RowsEffected > 0;

        }

    }

}
