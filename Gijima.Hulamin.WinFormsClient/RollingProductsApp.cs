using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Extensions;
using Gijima.Hulamin.WinFormsClient.Properties;

namespace Gijima.Hulamin.WinFormsClient
{
    public partial class RollingProductsApp : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public RollingProductsApp()
        {
            InitializeComponent();
        }

        private void RollingProductsAppForm_Load(object sender, EventArgs e)
        {
            try
            {
                Display();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        
        private async Task Display()
        {
            var messageResponse = await _httpClient.GetAsync("http://localhost:53233/api/suppliers");

            if (messageResponse.IsSuccessStatusCode == false) return;

            var suppliers = messageResponse.Content.ReadAsStringAsync().Result;

            var supplierList = suppliers.DeserializeObject<List<Supplier>>();

            dataGridViewEntities.DataSource = supplierList;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var supplier = BindSupplier();
           
            var result = CreateSupplier(supplier).Result; 

            ShowStatus(result, "Save");
        }

        private Supplier BindSupplier()
        {
            return new Supplier
            {
                Id = int.Parse(lblEntityId.Text),
                Name = textCompanyName.Text,
                ContactName = textContactName.Text,
                ContactTitle = textContactTitle.Text,
                Address = textAddress.Text,
                City = textCity.Text,
                Region = textRegion.Text,
                PostalCode = textPostalCode.Text,
                Country = textCountry.Text,
                Phone = textPhone.Text,
                Fax = textFax.Text,
                HomePage = "Hard Coded for now, no space on the UI"
            };
        }

        private async Task<bool> CreateSupplier(Supplier supplier) // calling SaveStudentMethod for insert a new record
        {
            string serializedItem = supplier.SerializeToJsonObject();

            var messageResponse = await _httpClient.PostAsync("http://localhost:53233/api/suppliers",  new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if(messageResponse.IsSuccessStatusCode == false) return false;
           
            return int.Parse(messageResponse.Content.ReadAsStringAsync().Result) != 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e) // Update button click event
        {
            var supplier = BindSupplier();

            bool result = UpdateSuppliers(supplier).Result;

            ShowStatus(result, Resources.RollingProductsApp_ShowStatus_Update);
        }

        private async Task<bool> UpdateSuppliers(Supplier supplier) 
        {
            string serializedItem = supplier.SerializeToJsonObject();

            var messageResponse = await _httpClient.PutAsync("http://localhost:53233/api/suppliers", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if (messageResponse.IsSuccessStatusCode == false) return false;

            return int.Parse(messageResponse.Content.ReadAsStringAsync().Result) != 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = DeleteSuppliers(lblEntityId.Text.Trim()).Result;

            ShowStatus(result, Resources.RollingProductsApp_ShowStatus_Delete);
        }

        private async Task<bool> DeleteSuppliers(string id) 
        {
           var messageResponse = await _httpClient.DeleteAsync($"http://localhost:53233/api/suppliers/Delete/{id}");

            if (messageResponse.IsSuccessStatusCode == false) return false;

            return int.Parse(messageResponse.Content.ReadAsStringAsync().Result) != 0;
        }

        private void dataGridViewEntities_CellClick(object sender, DataGridViewCellEventArgs e) //Calling Datagridview cell click to Update and Delete
        {
            if (dataGridViewEntities.Rows.Count <= 0) return;

            foreach (DataGridViewRow row in dataGridViewEntities.SelectedRows) // foreach datagridview selected rows values
            {
                lblEntityId.Text = row.Cells[0].Value.ToString();
                textCompanyName.Text = row.Cells[1].Value.ToString();
                textContactName.Text = row.Cells[2].Value.ToString();
                textContactTitle.Text = row.Cells[3].Value.ToString();
                textAddress.Text = row.Cells[4].Value.ToString();
                textCity.Text = row.Cells[5].Value.ToString();
                textRegion.Text = row.Cells[6].Value.ToString();
                textPostalCode.Text = row.Cells[7].Value.ToString();
                textCountry.Text = row.Cells[8].Value.ToString();
                textPostalCode.Text = row.Cells[9].Value.ToString();
                textPhone.Text = row.Cells[10].Value.ToString();
                textFax.Text = row.Cells[11].Value.ToString();
            }
        }

        private async Task ShowStatus(bool result, string Action) 
        {
            if (result)
            {
                switch (Action.ToUpper())
                {
                    case "SAVE":
                        MessageBox.Show(Resources.RollingProductsApp_ShowStatus_Saved_Successfully___, Resources.RollingProductsApp_ShowStatus_Create, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "UPDATE":
                        MessageBox.Show(Resources.RollingProductsApp_ShowStatus_Updated_Successfully___, Resources.RollingProductsApp_ShowStatus_Update, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        MessageBox.Show(Resources.RollingProductsApp_ShowStatus_Deleted_Successfully___, Resources.RollingProductsApp_ShowStatus_Delete, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else
            {
                MessageBox.Show(Resources.RollingProductsApp_ShowStatus_Something_went_wrong___Please_try_again___, Resources.RollingProductsApp_ShowStatus_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ClearFields();

            await Display();
        }

        private void ClearFields() // Clear the fields after Insert or Update or Delete operation
        {
            textCompanyName.Text = string.Empty;
            textContactName.Text = string.Empty;
            textContactTitle.Text = string.Empty;
            textAddress.Text = string.Empty;
            textCity.Text = string.Empty;
            textCountry.Text = string.Empty;
            textFax.Text = string.Empty;
            textPhone.Text = string.Empty;
            textPostalCode.Text = string.Empty;
            textRegion.Text = string.Empty;
        }
    }
}
