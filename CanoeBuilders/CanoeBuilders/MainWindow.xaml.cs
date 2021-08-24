using BLL;
using Model;
using Model.Lookups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace CanoeBuilders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillTypes();
            LoadBuilders();
           // chkArchived.DataContext = this;
           // this.DataContext = this;

        }

        private void FillTypes()
        {
            Dictionary<string, int> canoeTypes = new Dictionary<string, int>(){
                { "Aluminum", 1},
                { "Fiberglass", 2},
                { "Cedar-Strip", 3},
            };

            cboType.ItemsSource = canoeTypes;
            cboType.DisplayMemberPath = "Key";
            cboType.SelectedValuePath = "Value";
            //cmbContent = new ObservableCollection<string>();
            //cmbContent.Add("Aluminum");
            //cmbContent.Add("Fiberglass");
            //cmbContent.Add("Cedar-Strip");
            //cboType.ItemsSource = cmbContent;
        }

        public ObservableCollection<string> cmbContent { get; set; }
 

        private void LoadBuilders()
        {
            ListsBL listsBL = new ListsBL();
            var l = listsBL.GetTheBuilders();

            l.Insert(0, new BuilderLookup { BuilderID = 0, FirstName = "" });
            cboBuilders.ItemsSource = l;
            cboBuilders.DisplayMemberPath = "FirstName";
            cboBuilders.SelectedValuePath = "BuilderID";
            // cboBuilders.SelectedItem = -1;
        }

        private Canoe PopulateListingObject()
        {
            return new Canoe()
            {
                Name = txtName.Text.Trim(),
                BuilderID = Convert.ToInt32(cboBuilders.SelectedValue),
                QTY = Convert.ToInt32(txtQty.Text.ToString()),
                Date = Convert.ToDateTime(dtpDateAdded.SelectedDate.ToString()),
                Archived = Checked,
                CanoeType = Convert.ToInt32(cboType.SelectedValue.ToString()),
            };
        }
        public bool Checked { get; set; }




        //public bool CheckSelection(CheckBox chk)
        //{
        //    if ((bool)chk.IsChecked)
        //    {
        //        return
        //       // chk.Checked = chkArchived.Checked;
        //        return true;
        //    }
        //    // chk.Checked = false;
        //    return false;
        //}

        public string ValidateForm()
        {
            string errMsg = string.Empty;
            if (txtName.Text == string.Empty || !ValidLength(txtName.Text, 100))
            {
                errMsg = errMsg + Environment.NewLine + "Title cannot be blank or be more than 100 characters";
            }
            if (txtQty.Text == string.Empty || !ValidLength(txtQty.Text, 30))
            {
                errMsg = errMsg + Environment.NewLine + "Yield cannot be blank or be more than 30 characters";
            }
            if (cboType.SelectedItem == null)
            {
                errMsg = errMsg + Environment.NewLine + "Must be selected";
            }
            if (cboBuilders.SelectedItem == null)
            {
                errMsg = errMsg + Environment.NewLine + "Must be selected";
            }
            return errMsg;
        }

        public bool ValidLength(string value, int length)
        {
            if (value.Length > length)
            {
                return false;
            }

            return true;
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(cboType.SelectedValue.ToString());

            string errMsg = ValidateForm();

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "Missing Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                CanoeBL canoeBL = new CanoeBL();

                if (canoeBL.AddCanoe(PopulateListingObject()))
                {
                    MessageBox.Show("Insert successfully");
                    ResetForm();
                }
                else
                {
                    foreach (BLL.ValidationError error in canoeBL.Errors)
                    {
                        errMsg += error.Description + Environment.NewLine;
                    }
                    MessageBox.Show(errMsg);
                }
            }
        }

        private void ResetForm()
        {
            txtName.Clear();
            txtQty.Clear();
            dtpDateAdded.SelectedDate = null;
            dtpDateAdded.DisplayDate = DateTime.Today;
            //chkArchived.IsChecked = false;
            Checked = false;
            cboBuilders.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            FillTypes();

        }
    }
}
