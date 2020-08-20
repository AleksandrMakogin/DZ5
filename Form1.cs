using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ДЗ_5_2_
{
    public partial class Form1 : Form
    {

        public double Allprice { set; get; }  = 0;
        List<Prodact> prodact = null;

        ListBox ProductList = new ListBox();
        TextBox allPriceProduct = new TextBox();
        TextBox priceProduct = new TextBox();
        ComboBox productStock = new ComboBox();
        GroupBox groupBox1 = new GroupBox();
        GroupBox groupBoxProduct = new GroupBox();
        Label label1 = new Label();
        Button btnAdd = new Button();
        Button btnAddList = new Button();
        Button btnEdit = new Button();
        Label allPriceProductLabel = new Label();
        Label allPriceProductLabel2 = new Label();
        Label labelAllPriceProduct = new Label();
             
        public Form1()
        {
            InitializeComponent();
            prodact = new List<Prodact>();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(550,400);
            this.BackColor = Color.Beige;
            this.Text = "Учет товара ";

            // ===============================================

            this.groupBox1.SuspendLayout();
            this.groupBoxProduct.SuspendLayout();
            this.SuspendLayout();

            // ===============================================
            //label1.AutoSize = true;
            label1.Location = new Point(141, 60);
           
            this.label1.Size = new Size(27, 13);
            //this.label1.TabIndex = 13;
            this.label1.Text = "грн.";
            //=====================================
            btnAdd.Location = new Point(21, 28);
            btnAdd.Size = new Size(144, 21);
            btnAdd.Text = "Добавить товар";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            //=======================================
            btnAddList.Location = new Point(21, 82);
            btnAddList.Size = new Size(144, 21);
            btnAddList.Text = "Добавить в список";
            btnAddList.UseVisualStyleBackColor = true;
            btnAddList.Click += BtnAddList_Click;
            // =======================================
            btnEdit.Location = new Point(21, 55);
            btnEdit.Size = new Size(144, 21);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Редактировать товар";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;
            //========================================
            ProductList.BackColor = SystemColors.MenuBar;
            ProductList.ColumnWidth = 290;
            ProductList.FormattingEnabled = true;
            ProductList.IntegralHeight = false;
            ProductList.Location = new Point(20, 20);
            ProductList.Size = new Size(300, 290);
            ProductList.TabIndex = 0;
            Controls.Add(ProductList);
            // ====================================
            allPriceProduct.Location = new Point(344, 28);
            allPriceProduct.Size = new Size(114, 13);
            Controls.Add(allPriceProduct);
            // ===================================
            priceProduct.Location = new Point(21,56);
            priceProduct.Size = new Size(114, 20);
            Controls.Add(priceProduct);
            // ====================================
            productStock.BackColor = SystemColors.ScrollBar;
            productStock.DropDownStyle  = ComboBoxStyle.DropDownList;
            productStock.FormattingEnabled = true;
            productStock.Location = new Point(21, 29);
            productStock.Size = new Size(144, 21);
            Controls.Add(productStock);
            productStock.SelectedIndexChanged += ProductStock_SelectedIndexChanged;
            // =====================================
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Location = new Point(323, 192);
            groupBox1.Size = new Size(184, 98);
            //groupBox1.TabIndex = 9;
            //groupBox1.TabStop = false;
            groupBox1.Text = "Действия";
            Controls.Add(groupBox1);
            //======================================
            groupBoxProduct.Controls.Add(label1);
            groupBoxProduct.Controls.Add(productStock);
            groupBoxProduct.Controls.Add(priceProduct);
            groupBoxProduct.Controls.Add(btnAddList);
            groupBoxProduct.Location = new Point(323, 54);
            groupBoxProduct.Size = new Size(184, 118);
            //groupBoxProduct.TabIndex = 10;
            //groupBoxProduct.TabStop = false;
            groupBoxProduct.Text = "Товары";
            Controls.Add(groupBoxProduct);
            // ======================================
            allPriceProductLabel.AutoSize = true;
            allPriceProductLabel.Location = new Point(354, 9);
            allPriceProductLabel.Size = new Size(125, 13);
            allPriceProductLabel.TabIndex = 11;
            allPriceProductLabel.Text = "Цена товаров в списке";
            allPriceProductLabel.Visible = false;
            Controls.Add(allPriceProductLabel);
            //========================================
            allPriceProductLabel2.AutoSize = true;
            allPriceProductLabel2.Location = new Point(354, 9);
            allPriceProductLabel2.Size = new Size(118, 13);
            allPriceProductLabel2.TabIndex = 12;
            allPriceProductLabel2.Text = "Товаров в списке нет";
            Controls.Add(allPriceProductLabel2);
            // =======================================
            // labelAllPriceProduct
            // 
            labelAllPriceProduct.AutoSize = true;
            labelAllPriceProduct.Location = new Point(464, 31);
            labelAllPriceProduct.Name = "labelAllPriceProduct";
            labelAllPriceProduct.Size = new Size(27, 13);
            labelAllPriceProduct.TabIndex = 14;
            labelAllPriceProduct.Text = "грн.";
            //labelAllPriceProduct.Visible = false;
            Controls.Add(labelAllPriceProduct);
        }

        private void BtnAddList_Click(object sender, EventArgs e)
        {
            try
            {
                ProductList.Items.Add(((Prodact)productStock.Items[productStock.SelectedIndex]).ToString());
                Allprice += ((Prodact)productStock.Items[productStock.SelectedIndex]).Price;
                if (ProductList.Items.Count > 0)
                {
                    allPriceProductLabel2.Visible = false;
                    allPriceProductLabel.Visible = true;
                    allPriceProduct.Visible = true;
                    labelAllPriceProduct.Visible = true;
                }
                allPriceProduct.Text = Allprice.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не выбрали товар!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int tempNum = productStock.SelectedIndex;
                Prodact tempProduct = (Prodact)productStock.Items[tempNum];
                Form2 form2 = new Form2(false, tempProduct);
                form2.ShowDialog();
                productStock.Items.RemoveAt(tempNum);
                productStock.Items.Insert(tempNum, tempProduct);
                productStock.SelectedIndex = tempNum;
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не выбрали товар!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProductStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            priceProduct.Text = ((Prodact)productStock.Items[productStock.SelectedIndex]).Price.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            prodact.Add(new Prodact());
            Form2 form2 = new Form2(true, prodact[prodact.Count - 1]);
            if (form2.ShowDialog() == DialogResult.OK)
            {
                productStock.Items.Add(prodact[prodact.Count - 1]);
                groupBoxProduct.Text = $"Товары в наличии {productStock.Items.Count}";
            }
        }
    }
}
