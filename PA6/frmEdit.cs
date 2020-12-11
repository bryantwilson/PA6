using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;

        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                txtLengthData.Text = myBook.length.ToString();

                pbCover.Load(myBook.cover);
            }
        }

        //closes edit
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //saves the edit
        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            //displays a message box showing the user that their book was saved
            MessageBox.Show("The Book Was Saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
