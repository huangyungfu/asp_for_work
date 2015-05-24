using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfServiceLibrary1;


public partial class _Default : System.Web.UI.Page
{
    Work xyz = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
        Animal_Id_Lbl.Text = GridView1.SelectedRow.Cells[1].Text;
        Animal_Type_DropDown.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
        Nick_Name_Txtbx.Text = GridView1.SelectedRow.Cells[3].Text;
        Age_Txtbx.Text = GridView1.SelectedRow.Cells[4].Text;
        Gender_DropDown.SelectedValue = GridView1.SelectedRow.Cells[5].Text;

        List<ZooKeeper> da_keeper_drop = xyz.ZooKeeper_individual(GridView1.SelectedRow.Cells[6].Text);
        //dropDownList.Items.Add("test","test");

        ListItem l = new ListItem("" + da_keeper_drop[0].First_name + " " + da_keeper_drop[0].Last_name, da_keeper_drop[0].Staff_ID, true); 
            Zookeeper_Dropdown.Items.Add(l);
            Zookeeper_Dropdown.SelectedValue = GridView1.SelectedRow.Cells[6].Text;
            //Dropdownlist.Items.Add(l);
      

        Insert_Animal_Btn.Enabled = false;

    }
    protected void Update_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            int error_found = 0;
            if ((Animal_Id_Lbl.Text == "" || Nick_Name_Txtbx.Text == "" || Age_Txtbx.Text == "") && Animal_ID_Txtbx.Text.Length > 6)
            {
                error_found++;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' we need all the fields filled ');", true);
            }

            if (Animal_Id_Lbl.Text.Length != 6 && Animal_ID_Txtbx.Text.Length > 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' please select animal ');", true);
            }
            if (Animal_ID_Txtbx.Text.Length > 6)
            {
                try
                {
                    //var addr = new System.Net.Mail.MailAddress(Email_Txtbx.Text);
                    int phone = Convert.ToInt32(Age_Txtbx.Text);

                }
                catch
                {
                    error_found++;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' email and/or phone format is wrong ');", true);
                }
            }


            if (error_found == 0)
            {
                int Error = xyz.Update_animal(Animal_Id_Lbl.Text, Nick_Name_Txtbx.Text, Animal_Type_DropDown.SelectedValue, Convert.ToInt32(Age_Txtbx.Text), Gender_DropDown.SelectedValue, Zookeeper_Dropdown.SelectedValue);
 
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

    private void clear_all()
    {
        //Zookeeper_Dropdown.Items.Clear();
        Animal_Id_Lbl.Text = "none selected";
        Animal_ID_Txtbx.Text = "type here for new animal";
        Nick_Name_Txtbx.Text = "";
        Age_Txtbx.Text = "";
        GridView1.DataBind();
    }
    protected void Zookeeper_Dropdown_Load(object sender, EventArgs e)
    {
        Insert_Animal_Btn.Enabled = true;
        Update_Btn.Enabled = true;
        Delete_Animal_Btn.Enabled = true;
        Zookeeper_Dropdown.Items.Clear();
        List<ZooKeeper> da_keeper_drop = xyz.ZooKeeper_List();
        //dropDownList.Items.Add("test","test");
        for (int i = 0; i < da_keeper_drop.Count; i++)
        {
            ListItem l = new ListItem("" + da_keeper_drop[i].First_name + " " + da_keeper_drop[i].Last_name, da_keeper_drop[i].Staff_ID, true);
            Zookeeper_Dropdown.Items.Add(l);
            //Dropdownlist.Items.Add(l);
        }


        
    }
    protected void Insert_Animal_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            int error_found = 0;
            if (Animal_ID_Txtbx.Text == "" || Nick_Name_Txtbx.Text == "" || Age_Txtbx.Text == "")
            {
                error_found++;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' we need all the fields filled ');", true);
            }

            if (Animal_ID_Txtbx.Text.Length != 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' wrong id format ');", true);
            }
            try
            {
                //var addr = new System.Net.Mail.MailAddress(Email_Txtbx.Text);
                int phone = Convert.ToInt32(Age_Txtbx.Text);

            }
            catch
            {
                error_found++;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' age format is wrong ');", true);
            }

            if (error_found == 0)
            {
                int Error = xyz.Insert_animal(Animal_ID_Txtbx.Text, Animal_Type_DropDown.SelectedValue, Nick_Name_Txtbx.Text, Convert.ToInt32(Age_Txtbx.Text), Gender_DropDown.SelectedValue, Zookeeper_Dropdown.SelectedValue);

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
    protected void Delete_Animal_Btn_Click(object sender, EventArgs e)
    {
        try
        {
            int error_found = 0;


            if (Animal_Id_Lbl.Text.Length != 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' please select an animal ');", true);
            }
            


            if (error_found == 0)
            {
                int Error = xyz.Remove_animal(Animal_Id_Lbl.Text);

                if (Error > 0)//insert functionalities
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' delete success ');", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' delete fail ');", true);
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
    protected void Go_To_ZooKeeper_Btn_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default2.aspx");
    }
}