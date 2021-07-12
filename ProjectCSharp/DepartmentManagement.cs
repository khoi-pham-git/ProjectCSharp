using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharp
{
    public partial class Form1 : Form
    {
        GUI gui;
        DBUtil cn;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
            gui = new GUI();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'departmentManagementDataSet1.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.departmentManagementDataSet1.Department);
            labelName.Text = dataGridView1.Rows.Count.ToString();
        }

        public string checkYear(string foundedYear)
        {
            int founded;
            founded = Int32.Parse(foundedYear);
            
                if (founded < 1900 || founded > 2021)
                {
                    DialogResult dialog = MessageBox.Show("Input Error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    switch (dialog)
                    {
                        case DialogResult.OK:
                            this.Text = string.Empty;
                            break;
                    }
                }
            
            return foundedYear;
        }

        public bool checkData_V2() 
            {
            int check ;
            check = Int32.Parse(txtFoundedYear.Text);
            if (check < 1990 || check > 2021)
            {
                cbxId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtFoundedYear.Text = string.Empty;
                return false;
            }
                return true;
            }
        public bool checkData_V1()
        {
            if (string.IsNullOrEmpty(cbxId.Text))
            {
                MessageBox.Show("Input Error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxId.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Input Error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFoundedYear.Text))
            {
                MessageBox.Show("Input Error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFoundedYear.Focus();
                return false;
            }
            return true;
        }
        public bool checkData_V3()
        {
            
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Input Error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFoundedYear.Text))
            {
                MessageBox.Show("Input Error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFoundedYear.Focus();
                return false;
            }
            return true;
        }
        public bool checkData_V4()
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Error", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFoundedYear.Text))
            {
                MessageBox.Show("Error", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFoundedYear.Focus();
                return false;
            }
            return true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkData_V1() && checkData_V2())
            {

                DepartmentDTO dp = new DepartmentDTO();
                dp.Id1 = cbxId.Text;
                dp.Name1 = txtName.Text;
                dp.Founded1 = Int32.Parse(checkYear(txtFoundedYear.Text));


                if ((gui.AddDepartment(dp)))
                {
                    MessageBox.Show("Input Sucessfully!", "Sucessful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxId.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtFoundedYear.Text = string.Empty;
                    Form1_Load(sender, e);

                }
                else
                {
                    MessageBox.Show("Something error!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("Something error or Input error!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            checkBox.Enabled = true;
            txtSearch.Enabled = true;
        }

        private void txtFoundedYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbxId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFoundedYear.Text = string.Empty;
            cbxId.Enabled = true;
            checkBox.Enabled = true;
            txtSearch.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxId.Enabled = false;
            int index = e.RowIndex;
            if(index >= 0)
            {
                cbxId.Text = dataGridView1.Rows[index].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                txtName.Text = dataGridView1.Rows[index].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                txtFoundedYear.Text = dataGridView1.Rows[index].Cells["foundedyearDataGridViewTextBoxColumn"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (checkData_V3() && checkData_V2())
            {

                DepartmentDTO dp = new DepartmentDTO();
                dp.Id1 = cbxId.Text;
                dp.Name1 = txtName.Text;
                dp.Founded1 = Int32.Parse(checkYear(txtFoundedYear.Text));


                if ((gui.UpdateDepartment(dp)))
                {
                    MessageBox.Show("Update Sucessfully!", "Sucessful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxId.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtFoundedYear.Text = string.Empty;
                    Form1_Load(sender, e);

                }
                else
                {
                    MessageBox.Show("Something error!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("Something error or Input error!!!", "Error Update!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            checkBox.Enabled = true;
            txtSearch.Enabled = true;
            cbxId.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want delete?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DepartmentDTO dp = new DepartmentDTO();
                dp.Id1 = cbxId.Text;
                if (gui.DeleteDepartment(dp))
                {
                    Form1_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Can't delete!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            checkBox.Enabled = true;
            txtSearch.Enabled = true;
            cbxId.Enabled = false;
            cbxId.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("Do you want close application?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Continue...", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (checkData_V4() && checkData_V2())
            {

                DepartmentDTO dp = new DepartmentDTO();
                dp.Id1 = cbxId.Text;
                dp.Name1 = txtName.Text;
                dp.Founded1 = Int32.Parse(checkYear(txtFoundedYear.Text));


                if ((gui.UpdateDepartment(dp)))
                {
                    MessageBox.Show("Save Sucessfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxId.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtFoundedYear.Text = string.Empty;
                    Form1_Load(sender, e);

                }
                else
                {
                    MessageBox.Show("Something error!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("Can't save!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            checkBox.Enabled = true;
            txtSearch.Enabled = true;
            cbxId.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtSearch.Text;
            if (!(string.IsNullOrEmpty(value)))
            {
                DataTable data = gui.findDepartment(value);
                dataGridView1.DataSource = data;
            }
            if (string.IsNullOrEmpty(value))
            {
                this.departmentTableAdapter.Fill(this.departmentManagementDataSet1.Department);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            cbxId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFoundedYear.Text = string.Empty;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          if(checkBox.Checked == true)
            {
                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
            }
            else
            {
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            
        }

        private void cbxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            checkBox.Enabled = true;
            txtSearch.Enabled = false;

            string main = ConfigurationManager.ConnectionStrings["ProjectCSharp.Properties.Settings.DepartmentManagementConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(main);
            string sql = "SELECT Name, Foundedyear FROM Department WHERE Id='" + cbxId.Text + "'";
            SqlCommand cm = new SqlCommand(sql,con);
            con.Open();
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[0].ToString();
                txtFoundedYear.Text = dr[1].ToString();
            }
            con.Close();
        }

        private void txtFoundedYear_TextChanged(object sender, EventArgs e)
        {
            
            checkBox.Enabled = false;
            txtSearch.Enabled = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            checkBox.Enabled = false;
            txtSearch.Enabled = false;
        }
    }

}
