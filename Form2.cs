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
    public partial class Form2 : Form
    {
        Prodact product ;
        bool addnew = true;

        Label label1 = new System.Windows.Forms.Label();
        Button btnEditAddF2 = new System.Windows.Forms.Button();
        TextBox nameTextBox = new System.Windows.Forms.TextBox();
        TextBox priceTextBox = new System.Windows.Forms.TextBox();
        TextBox descriptionTextBox = new System.Windows.Forms.TextBox();
        TextBox specificationTextBox = new System.Windows.Forms.TextBox();
        Label label2 = new System.Windows.Forms.Label();
        Label label3 = new System.Windows.Forms.Label();
        Label label4 = new System.Windows.Forms.Label();
        Button btnCancelF2 = new System.Windows.Forms.Button();

        public Form2(bool addnew, Prodact product)
        {
            InitializeComponent();
            this.product = product;
            this.addnew = addnew;

            

            btnEditAddF2.Click += BtnEditAddF2_Click;
            btnCancelF2.Click += BtnCancelF2_Click; ;
            this.Size = new Size(350, 350);
            this.BackColor = Color.Beige;
            this.Text = "Учет товара ";
            this.Load += Form2_Load;

            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 13);
            label1.TabIndex = 0;
            label1.Text = "Наименование";
            Controls.Add(label1);
            // 
            // btnEditAddF2
            // 
            btnEditAddF2.Location = new System.Drawing.Point(15, 258);
            btnEditAddF2.Name = "btnEditAddF2";
            btnEditAddF2.Size = new System.Drawing.Size(132, 23);
            btnEditAddF2.TabIndex = 1;
            btnEditAddF2.Text = "Ок";
            btnEditAddF2.UseVisualStyleBackColor = true;
            Controls.Add(btnEditAddF2);
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(108, 33);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(164, 20);
            nameTextBox.TabIndex = 2;
            Controls.Add(nameTextBox);
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new System.Drawing.Point(108, 200);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new System.Drawing.Size(164, 20);
            priceTextBox.TabIndex = 3;
            Controls.Add(priceTextBox);
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new System.Drawing.Point(108, 128);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            descriptionTextBox.Size = new System.Drawing.Size(164, 66);
            descriptionTextBox.TabIndex = 4;
            Controls.Add(descriptionTextBox);
            // 
            // specificationTextBox
            // 
            specificationTextBox.Location = new System.Drawing.Point(108, 59);
            specificationTextBox.Multiline = true;
            specificationTextBox.Name = "specificationTextBox";
            specificationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            specificationTextBox.Size = new System.Drawing.Size(164, 63);
            specificationTextBox.TabIndex = 5;
            Controls.Add(specificationTextBox);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 87);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 13);
            label2.TabIndex = 6;
            label2.Text = "Характеристика";
            Controls.Add(label2);
            // 
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 131);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 13);
            label3.TabIndex = 7;
            label3.Text = "Описание";
            Controls.Add(label3);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 207);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 13);
            label4.TabIndex = 8;
            label4.Text = "Цена";
            Controls.Add(label4);
            // 
            // btnCancelF2
            // 
            btnCancelF2.Location = new System.Drawing.Point(153, 258);
            btnCancelF2.Name = "btnCancelF2";
            btnCancelF2.Size = new System.Drawing.Size(119, 23);
            btnCancelF2.TabIndex = 9;
            btnCancelF2.Text = "Отмена";
            btnCancelF2.UseVisualStyleBackColor = true;
            Controls.Add(btnCancelF2);
            // 


        }

        private void BtnCancelF2_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!addnew)
            {
                Text = "Редактировать товар";
                nameTextBox.Text = product.Name;
                specificationTextBox.Text = product.Spetification;
                descriptionTextBox.Text = product.Description;
                priceTextBox.Text = product.Price.ToString();
                addnew = true;


            }
        }

        private void BtnEditAddF2_Click(object sender, EventArgs e)
        {
            if (addnew)
            {
                if (nameTextBox.Text == "" || specificationTextBox.Text == "" || descriptionTextBox.Text == "" || priceTextBox.Text == "")
                {
                    MessageBox.Show("Заполните все поля", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                product.Name = nameTextBox.Text;
                product.Spetification = specificationTextBox.Text;
                product.Description = descriptionTextBox.Text;
                try
                {
                    if (double.Parse(priceTextBox.Text) < 0)
                    {
                        MessageBox.Show("Цена не может быть меньше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    product.Price = double.Parse(priceTextBox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Цена указана неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
