using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//tambahkan using berikut
using PhoneNumber.Models;
using PhoneNumber.Controller;
using MySql.Data.MySqlClient;

namespace PhoneNumber.UI
{
    public partial class Form1 : Form
    {
        PhonebookController PC = new PhonebookController();
        DataTable dt = new DataTable();
        ShowException SE = new ShowException();

        public Form1()
        {
            InitializeComponent();
            RefreshGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setDatagridview(dgView);
            }
            catch (Exception ex)
            {
                //throw;
                Console.WriteLine(ex.Message);
            }
        }

        public void setDatagridview(DataGridView DG)
        {
            dt.Clear();
            MySqlDataAdapter adapter = PC.showPhone();
            adapter.Fill(dt);
            DG.DataSource = dt;

            DG.Columns[0].HeaderText = "ID";
            DG.Columns[1].HeaderText = "NAME";
            DG.Columns[2].HeaderText = "PHONE NUMBER";
            DG.Columns[0].Width = 70;
            DG.Columns[1].Width = 200;
            DG.Columns[2].Width = 150;
            settingHeaderGrid(DG);
        }

        private void settingHeaderGrid(DataGridView DG)
        {
            //=== Make Center Header in Data Grid View
            foreach (DataGridViewColumn col in DG.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        public void RefreshGridView()
        {
            setDatagridview(dgView);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;
                string id = tempID.Text;
                string nama = txtName.Text;
                string number = txtNo.Text;
                Phonebook P = new Phonebook(nama, number);
                if (txtName.Text.Length > 0 && txtNo.Text.Length > 0)
                {
                    if (id.Length > 0 && btnSave.Text.ToLower() == "update")
                    {
                        if (PC.Update(P, int.Parse(id)))
                            message = "Update " + nama + " Success";
                    }
                    else
                    {
                        if (PC.Insert(P))
                            message = "Insert " + nama + " Success";
                    }
                    MessageBox.Show(message, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    RefreshGridView();
                }
                else
                {
                    MessageBox.Show("Field Cannot Empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //throw;
                Console.WriteLine(ex.Message);
            }
        }

        private void clearData()
        {
            tempID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNo.Text = string.Empty;
            btnSave.Text = "Save";
            enableButton(false);
        }

        private string getColumn(DataGridView dg, int i)
        {
            string kolom = null;
            try
            {
                kolom = dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
            return kolom;
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tempID.Text = getColumn(dgView, 0);
            enableButton(true);
        }

        private void enableButton(bool value)
        {
            btnEdit.Enabled = value;
            btnDelete.Enabled = value;
            btnCancel.Visible = false;
        }

        private void setValueEdit()
        {
            tempID.Text = getColumn(dgView, 0);
            txtName.Text = getColumn(dgView, 1);
            txtNo.Text = getColumn(dgView, 2);
            btnSave.Text = "Update";
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setValueEdit();
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                setValueEdit();
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (PC.Delete(int.Parse(tempID.Text)))
                {
                    MessageBox.Show("Deleted Success", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enableButton(false);
                }
                RefreshGridView();
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
        }

        private void tempID_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                btnCancel.Visible = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                btnCancel.Visible = true;
            }
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            if (txtNo.Text.Length > 0)
            {
                btnCancel.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                clearData();
                enableButton(false);
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
        }
    }
}
