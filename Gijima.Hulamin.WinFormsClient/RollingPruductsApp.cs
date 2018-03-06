using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Extensions;

namespace Gijima.Hulamin.WinFormsClient
{
    public partial class RollingPruductsApp : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public RollingPruductsApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            Display();
        }

        public void Display()
        {
            using (StudentInformationEntities _entity = new StudentInformationEntities())
            {
                List<StudentInformation> _studentList = new List<StudentInformation>();
                _studentList = _entity.StudentDetails.Select(x => new StudentInformation
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    City = x.City,
                    Gender = x.Gender
                }).ToList();
                dataGridViewEntities.DataSource = _studentList;
            }
        }


        public async Task btnCreate_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier
            {
                Id = int.Parse(lblEntityId.Text),
                Name = textCompanyName.Text,
                ContactName = textContactName.Text,
                ContactTitle = textContactTitle.Text,
                Address = textAddress.Text,
                City = textCity.Text,
                Region = textRegion.Text,
                PostalCode = textPostalCode.Text,
                Country = textCounty.Text,
                Phone = textPhone.Text,
                Fax = textFax.Text,
                HomePage = "Hard Coded for now, no space on the UI"
            };

           
            var result = await CreateSupplier(supplier); 
            ShowStatus(result, "Save");
        }

        private async Task<bool> CreateSupplier(Supplier supplier) // calling SaveStudentMethod for insert a new record
        {
            string serializedItem = supplier.SerializeToJsonObject();

            var messageResponse = await _httpClient.PostAsync("http://localhost:00/api/supplier",  new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if(messageResponse.IsSuccessStatusCode == false) return false;
               
           
            return int.Parse(messageResponse.Content.ReadAsStringAsync().Result) != 0;
        }


        private void btnUpdate_Click(object sender, EventArgs e) // Update button click event
        {
            StudentDetail stu = SetValues(Convert.ToInt32(lblEntityId.Text), textCompanyName.Text, Convert.ToInt32(textContactName.Text), textContactTitle.Text, cmbGender.SelectedItem.ToString()); // Binding values to StudentInformationModel
            bool result = UpdateStudentDetails(stu); // calling UpdateStudentDetails Method
            ShowStatus(result, "Update");
        }
        public bool UpdateStudentDetails(StudentDetail Stu) // UpdateStudentDetails method for update a existing Record
        {
            bool result = false;
            using (StudentInformationEntities _entity = new StudentInformationEntities())
            {
                StudentDetail _student = _entity.StudentDetails.Where(x => x.Id == Stu.Id).Select(x => x).FirstOrDefault();
                _student.Name = Stu.Name;
                _student.Age = Stu.Age;
                _student.City = Stu.City;
                _student.Gender = Stu.Gender;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }

        private void btnDelete_Click(object sender, EventArgs e) //Delete Button Event
        {
            StudentDetail stu = SetValues(Convert.ToInt32(lblEntityId.Text), textCompanyName.Text, Convert.ToInt32(textContactName.Text), textContactTitle.Text, cmbGender.SelectedItem.ToString()); // Binding values to StudentInformationModel
            bool result = DeleteStudentDetails(stu); //Calling DeleteStudentDetails Method
            ShowStatus(result, "Delete");
        }
        public bool DeleteStudentDetails(StudentDetail Stu) // DeleteStudentDetails method to delete record from table
        {
            bool result = false;
            using (StudentInformationEntities _entity = new StudentInformationEntities())
            {
                StudentDetail _student = _entity.StudentDetails.Where(x => x.Id == Stu.Id).Select(x => x).FirstOrDefault();
                _entity.StudentDetails.DeleteObject(_student);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //Calling Datagridview cell click to Update and Delete
        {
            if (dataGridViewEntities.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewEntities.SelectedRows) // foreach datagridview selected rows values
                {
                    lblEntityId.Text = row.Cells[0].Value.ToString();
                    textCompanyName.Text = row.Cells[1].Value.ToString();
                    textContactName.Text = row.Cells[2].Value.ToString();
                    textContactTitle.Text = row.Cells[3].Value.ToString();
                    cmbGender.SelectedItem = row.Cells[4].Value.ToString();
                }
            }
        }

        public StudentDetail SetValues(int Id, string Name, int age, string City, string Gender) //Setvalues method for binding field values to StudentInformation Model class
        {
            StudentDetail stu = new StudentDetail();
            stu.Id = Id;
            stu.Name = Name;
            stu.Age = age;
            stu.City = City;
            stu.Gender = Gender;
            return stu;
        }

        private void ShowStatus(bool result, string Action) // validate the Operation Status and Show the Messages To User
        {
            if (result)
            {
                if (Action.ToUpper() == "SAVE")
                {
                    MessageBox.Show("Saved Successfully!..", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Action.ToUpper() == "UPDATE")
                {
                    MessageBox.Show("Updated Successfully!..", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Deleted Successfully!..", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong!. Please try again!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ClearFields();
            Display();
        }

        private void ClearFields() // Clear the fields after Insert or Update or Delete operation
        {
            textCompanyName.Text = string.Empty;
            textContactName.Text = string.Empty;
            textContactTitle.Text = string.Empty;
            textAddress.Text = string.Empty;
            textCity.Text = string.Empty;
            textCounty.Text = string.Empty;
            textFax.Text = string.Empty;
            textPhone.Text = string.Empty;
            textPostalCode.Text = string.Empty;
            textRegion.Text = string.Empty;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
