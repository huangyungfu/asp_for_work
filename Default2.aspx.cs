using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WcfServiceLibrary1;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Work xyz = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

 

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Staff_ID_Lbl.Text = GridView1.SelectedRow.Cells[1].Text;
        First_Name_Txtbx.Text = GridView1.SelectedRow.Cells[2].Text;
        Last_Name_Txtbx.Text = GridView1.SelectedRow.Cells[3].Text;
        Phone_NUmber_Txtbx.Text = GridView1.SelectedRow.Cells[4].Text;
        //DateTime da_date =DateTime.Parse(GridView1.SelectedRow.Cells[5].Text).Date;
        //DateTime.Now.ToString("yyyyMMddHHmmss");
        Date_Of_Birth_Txtbx.Text = DateTime.Parse(GridView1.SelectedRow.Cells[5].Text).ToString("M/d/yyyy");
        Email_Txtbx.Text = GridView1.SelectedRow.Cells[6].Text;


        Insert_Zookeeper_Btn.Enabled = false;
    }
    protected void Back_To_Animal_Btn_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx");
    }
    protected void Delete_Zookeeper_Btn_Click(object sender, EventArgs e)
    {
        //unused please ignore
    }

    private void clear_all()
    {
        Insert_Zookeeper_Btn.Enabled = true;
        Update_Btn.Enabled = true;
        Delete_Zookeeper_Btn.Enabled = true;
        Staff_ID_Lbl.Text = "none selected";
        Staff_ID_Txtbx.Text = "type here for new staff";
        First_Name_Txtbx.Text = "";
        Last_Name_Txtbx.Text = "";
        Date_Of_Birth_Txtbx.Text = "";
        Phone_NUmber_Txtbx.Text = "";
        Email_Txtbx.Text = "";
        GridView1.DataBind();
    }
    protected void Delete_Zookeeper_Btn_Click1(object sender, EventArgs e)
    {
        try
        {
            int error_found = 0;
          

            if (Staff_ID_Lbl.Text.Length != 6 )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' please select someone ');", true);
            }
            


            if (error_found == 0)
            {
                int Error = xyz.Remove_Zookeeper(Staff_ID_Lbl.Text);

                if (Error > 0)//insert functionalities
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' delete success ');", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' delete fail and make sure the zookeeper is not assigned to any animal ');", true);
                }
            }





        }
        catch (TimeoutException ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' there are problems with the connection ');", true);
        }
        finally
        {
            clear_all();
        }
    }
    protected void Update_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            int error_found = 0;
            if ((Staff_ID_Lbl.Text == "" || First_Name_Txtbx.Text == "" || Last_Name_Txtbx.Text == "" || Phone_NUmber_Txtbx.Text == "" || Date_Of_Birth_Txtbx.Text == "" || Email_Txtbx.Text == "") && Staff_ID_Txtbx.Text.Length>6)
            {
                error_found++;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' we need all the fields filled ');", true);
            }

            if (Staff_ID_Lbl.Text.Length != 6 && Staff_ID_Txtbx.Text.Length>6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' please select someone ');", true);
            }
            if (Staff_ID_Txtbx.Text.Length > 6)
            {
                 try
            {
                var addr = new System.Net.Mail.MailAddress(Email_Txtbx.Text);
                int phone = Convert.ToInt32(Phone_NUmber_Txtbx.Text);

            }
            catch
            {
                error_found++;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' email and/or phone format is wrong ');", true);
            }
            }
           

            if (error_found == 0)
            {
                int Error = xyz.Update_Zookeeper(Staff_ID_Lbl.Text, First_Name_Txtbx.Text, Last_Name_Txtbx.Text, Phone_NUmber_Txtbx.Text, Convert.ToDateTime(Date_Of_Birth_Txtbx.Text), Email_Txtbx.Text);
        
                if (Error > 0)//insert functionalities
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' update success ');", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' update fail ');", true);
                }
            }





        }
        catch (TimeoutException ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' there are problems with the connection ');", true);
        }
        finally
        {
            clear_all();
        }
    }
    protected void Insert_Zookeeper_Btn_Click(object sender, EventArgs e)
    {
        //xyz.Insert_animal(Animal_ID_Txtbx.Text, Animal_Type_DropDown.SelectedValue, Nick_Name_Txtbx.Text, Convert.ToInt32(Age_Txtbx.Text), Gender_DropDown.SelectedValue, Zookeeper_Dropdown.SelectedValue);
        //xyz.Insert_Zookeeper(Staff_ID_Txtbx.Text, First_Name_Txtbx.Text, Last_Name_Txtbx.Text, Phone_NUmber_Txtbx.Text, Convert.ToDateTime(Date_Of_Birth_Txtbx.Text),Email_Txtbx.Text);
        
        //clear_all();

        try
        {       int error_found=0;
                if(Staff_ID_Txtbx.Text==""||First_Name_Txtbx.Text==""||Last_Name_Txtbx.Text==""||Phone_NUmber_Txtbx.Text==""||Date_Of_Birth_Txtbx.Text==""||Email_Txtbx.Text=="")
                {
                    error_found++;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' we need all the fields filled ');", true);
                }

                if(Staff_ID_Txtbx.Text.Length!=6)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' wrong id format ');", true);
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(Email_Txtbx.Text);
                    int phone = Convert.ToInt32(Phone_NUmber_Txtbx.Text);
                    
                }
                catch
                {
                    error_found++;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' email and/or phone format is wrong ');", true);
                }
                
                if (error_found==0)
                {
                    int Error = xyz.Insert_Zookeeper(Staff_ID_Txtbx.Text, First_Name_Txtbx.Text, Last_Name_Txtbx.Text, Phone_NUmber_Txtbx.Text, Convert.ToDateTime(Date_Of_Birth_Txtbx.Text), Email_Txtbx.Text);
        
                if (Error > 0)//insert functionalities
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' insertion success ');", true);
                    
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' insertion fail ');", true);
                }
                }

                
            


        }
        catch (TimeoutException ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' there are problems with the connection ');", true);
        }
        finally
        {
            clear_all();
        }
    }
    protected void Phone_NUmber_Txtbx_TextChanged(object sender, EventArgs e)
    {
        
    }
}