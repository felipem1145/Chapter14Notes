using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chapter13Program03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsSerial myFriend = new clsSerial();

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSerial_Click(object sender, EventArgs e)
        {
            int flag;
            MoveTextToClass(myFriend); // Move from textboxes to data
            flag = myFriend.SerializeFriend(myFriend);
            if (flag == 1)
            {
                MessageBox.Show("Data Serialized successfully", "Data Write");
            }
            else
            {
                MessageBox.Show("Serialization failure", "Data Error");
            }
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            clsSerial newFriend = new clsSerial();
            newFriend = newFriend.DeserializeFriend();
            lstOutput.Items.Clear();
            lstOutput.Items.Add(newFriend.Name);
            lstOutput.Items.Add(newFriend.Email);
            lstOutput.Items.Add(newFriend.Status.ToString());
        }
        private void MoveTextToClass(clsSerial obj)
        {
            bool flag;
            int val;
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            flag = int.TryParse(txtStatus.Text, out val);
            if (flag == false)
            {
                MessageBox.Show("Must be 1 or 0", "Input Error");
                txtStatus.Focus();
                return;
            }
            obj.Status = val;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        [Serializable] // DON'T FORGET THIS
        class clsSerial
        {
            //------------------- Instance members ---------------
            private string name;
            private string email;
            private int status;
            //------------------- Property methods ---------------
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;
                }
            }
            public int Status
            {
                get
                {
                    return status;
                }
                set
                {
                    status = value;
                }
            }
            //------------------- Helper methods ----------------
            //------------------- General methods ---------------
            /*****
            * Purpose: To serialize the contents of this class
            *
            * Parameter list:
            * clsSerial myFriend Serialize an instance
            *
            * Return value:
            * int 0 on error, 1 otherwise
            *****/
            public int SerializeFriend(clsSerial myFriend)
            {
                try
                {
                    BinaryFormatter format = new BinaryFormatter();
                    FileStream myStream = new FileStream("Test.bin",
                    FileMode.Create);
                    format.Serialize(myStream, myFriend);
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    string buff = ex.Message;
                    return 0;
                }
                return 1;
            }
            /*****
            * Purpose: To deserialize an instance of this class from a file
            *
            * Parameter list:
            * n/a
            *
            * Return value:
            * clsSerial an instance of the class with the data
            *****/
            public clsSerial DeserializeFriend()
            {
                clsSerial temp = new clsSerial();
                try
                {
                    BinaryFormatter format = new BinaryFormatter();
                    FileStream myStream = new FileStream("Test.bin",
                    FileMode.Open);
                    temp = (clsSerial)format.Deserialize(myStream);
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    string buff = ex.Message;
                    return null;
                }
                return temp;
            }
        }
    }


}
