using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLApp;

namespace WebApplication2
{
    public partial class foodista : System.Web.UI.Page
    {
        int Gender = 1;
        int Age = 3;
        int Residence = 1;
        int MealPerDay = 3;
        int EatingOutPerWeek = 4;

        MLApp.MLApp matlab = new MLApp.MLApp();

        protected void Page_Load(object sender, EventArgs e)
        {


            ////is code ko set krana yeh daikho code samjhata hu

            //// input output variable initilailzation, input will contain values that were obtained via controls
            //double[] output = new double[] { 0, 0, 0, 0, 0, 0 };
            //double[] input = new double[] { MealPerDay, EatingOutPerWeek, Residence, Age, Gender};

            //// this will hold results from GetWorkspaceData call
            //Object res;

            ////Matla matlab = new MLApp();

            //// matlab.execute for runing frequently used matlab commands
            ////command use for loading workspace variables. in this case net.mat will contain trained network

            //IMLApp matlab = null;
            //matlab.

            //matlab.Execute("load('net.mat');");

            //// matlab.PutWorkspaceData()  // for impoting data from Visual studio to matlab
            //// for importing variables from visual studio envirorment to matlab (that is being simulated within VS)
            //// first paremter is name of variable from matlab, we always use "base" as second parameter (for unknown reason), third paramter is variable from where we are importing data
            //matlab.PutWorkspaceData("input", "base", input);
            //matlab.PutWorkspaceData("output", "base", output);

            //// we are simulating network over here using execute matlab.method
            //matlab.Execute("output = sim(input')';");

            //// matlab.GetWorkspaceData()  // for exporting data back to Visual studio from matlab
            //// for importing variables from visual studio envirorment to matlab (that is being simulated within VS)
            //// third paramter is variable to where we wnt to export data. third parameter is of type "object"
            //matlab.GetWorkspaceData("output", "base", out res);

            //// we have casted res to double
            //var arr = (double[,])res;


            ////filhal yaha tak run karo. arr ma result ayega.. 2 min do..
            ////okay 

            ////Textbox8.Text = arr[0, 1].ToString();


        }

        protected void LoadSuggestion_Click(object sender, EventArgs e)
        {


            // Check Visibilty
            Panel1.Visible = true;


            Gender = Convert.ToInt32(ddlGender.SelectedValue);
            Age = Convert.ToInt32(ddlAge.SelectedValue);
            Residence = Convert.ToInt32(ddlResidence.SelectedValue);
            MealPerDay = Convert.ToInt32(ddlfrequencyMealsDay.SelectedValue);
            EatingOutPerWeek = Convert.ToInt32(ddlFrequencyOutPerweek.SelectedValue);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////  Matlab Simulation////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // input output variable initilailzation, input will contain values that were obtained via controls
            double[] output = new double[] { 0, 0, 0, 0, 0, 0 };
            double[] input = new double[] { MealPerDay, EatingOutPerWeek, Residence, Age, Gender };

            // this will hold results from GetWorkspaceData call
            Object res;


            // Randomness on trained_network Occurrence 

            Random rand = new Random();
            string[] NetworkList = {  "trained_network_2.mat", 
                                       "trained_network_2.mat",
                                       "trained_network_2.mat",
                                       "trained_network_2.mat",
                                       "trained_network_2.mat",
                                       "trained_network_5.mat",
                                       "trained_network_5.mat",
                                       "trained_network_5.mat",
                                       "trained_network_5.mat",
                                       "trained_network_3.mat",
                                       "trained_network_3.mat",
                                       "trained_network_3.mat",
                                       "trained_network_6.mat",
                                       "trained_network_6.mat",
                                       "trained_network_1.mat",
  };



            int index = rand.Next(NetworkList.Count());


            var currentNetwork = NetworkList[index];
            // Select Networks end 


            //Matla matlab = new MLApp();

            // matlab.execute for runing frequently used matlab commands
            //command use for loading workspace variables. in this case net.mat will contain trained network
            // yaha pa concatenation ho rahi hai theek hai 
            matlab.Execute("load('" + currentNetwork + "');");

            // matlab.PutWorkspaceData()  // for impoting data from Visual studio to matlab
            // for importing variables from visual studio envirorment to matlab (that is being simulated within VS)
            // first paremter is name of variable from matlab, we always use "base" as second parameter (for unknown reason), third paramter is variable from where we are importing data
            matlab.PutWorkspaceData("input", "base", input);
            matlab.PutWorkspaceData("output", "base", output);

            // we are simulating network over here using execute matlab.method
            matlab.Execute("output = round(sim(net,input')'')';");

            // matlab.GetWorkspaceData()  // for exporting data back to Visual studio from matlab
            // for importing variables from visual studio envirorment to matlab (that is being simulated within VS)
            // third paramter is variable to where we wnt to export data. third parameter is of type "object"
            matlab.GetWorkspaceData("output", "base", out res);

            // we have casted res to double
            var arr = (double[,])res;

            //filhal yaha tak run karo. arr ma result ayega.. 2 min do..
            //okay 

            //Textbox8.Text = arr[0, 1].ToString();

            int round1 = Convert.ToInt32(arr[0, 1]);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[0, i] = Math.Abs(arr[0, i]);
            }


            //Locations
            Literal1.Text = arr[0, 0].ToString();
            Literal2.Text = arr[0, 1].ToString();
            Literal3.Text = arr[0, 2].ToString();



            //// Foods
            // food1.Text = arr[0, 3].ToString();
            // food2.Text = arr[0, 4].ToString();
            // food3.Text = arr[0, 5].ToString();


            // corresponding the values to 
            if (arr[0, 3].ToString().Contains("1"))
            {
                food1.Text = "Have A Pizza";
            }
            else if (arr[0, 3].ToString().Contains("2"))
            {
                food1.Text = "Have a Burger ";
            }
            else if (arr[0, 3].ToString().Contains("3"))
            {
                food1.Text = "have a Chinese";
            }
            else if (arr[0, 3].ToString().Contains("4"))
            {
                food1.Text = "have a desi Wets";
            }
            else if (arr[0, 3].ToString().Contains("5"))
            {
                food1.Text = "have a burger";
            }
            else if ((int)arr[0, 3] > 5)
            {
                food1.Text = "have a pizza";
            }



            // ab chala ke dikhata hu ???
            // Second
            if (arr[0, 4].ToString().Contains("1"))
            {
                food2.Text = "Have A Pizza";
            }
            else if (arr[0, 4].ToString().Contains("2"))
            {
                food2.Text = "Have a Burger ";
            }
            else if (arr[0, 4].ToString().Contains("3"))
            {
                food2.Text = "have a Chinese";
            }
            else if (arr[0, 4].ToString().Contains("4"))
            {
                food2.Text = "have a Desi Wets";
            }
            else if (arr[0, 4].ToString().Contains("5"))
            {
                food2.Text = "try something new";
            }

            else if ((int) arr[0, 4] >6)
            {
                food2.Text = "try something new";
            }


            //Third Location
            if (arr[0, 5].ToString().Contains("1"))
            {
                food3.Text = "Have A Pizza";
            }
            else if (arr[0, 5].ToString().Contains("2"))
            {
                food3.Text = "Have A Burger";
            }
            else if (arr[0, 5].ToString().Contains("3"))
            {
                food3.Text = "have a Chinese";
            }
            else if (arr[0, 5].ToString().Contains("4"))
            {
                food3.Text = "have a Desi Wets";
            }
            else if (arr[0, 5].ToString().Contains("5"))
            {
                food3.Text = "try something new";
            }
            else if ((int)arr[0, 4] > 6)
            {
                food2.Text = "try something new";
            }



        }





        //// Check Visibilty
        //   Panel1.Visible = true;

        //   Gender = Convert.ToInt32(ddlGender.SelectedValue);
        //   Age = Convert.ToInt32(ddlAge.SelectedValue);
        //   Residence = Convert.ToInt32(ddlResidence.SelectedValue);
        //   MealPerDay = Convert.ToInt32(ddlfrequencyMealsDay.SelectedValue);
        //   EatingOutPerWeek = Convert.ToInt32(ddlFrequencyOutPerweek.SelectedValue);

        //   String EatingOutPerWeekString = EatingOutPerWeek.ToString();
        //   IEnumerable<DataRow> query = from table in table1.AsEnumerable()
        //                                where table.Field<String>("user_gender") == Gender.ToString()
        //                                && table.Field<String>("user_age") == Age.ToString()
        //                                && table.Field<String>("user_residence") == Residence.ToString()
        //                                && table.Field<String>("frequency_meal_per_day") == MealPerDay.ToString()
        //                                && table.Field<String>("frequency_eating_out_per_week") == EatingOutPerWeek.ToString()
        //                                select table;


        //   //     var result = table1.Select("frequency_meal_per_day=" + MealPerDay.ToString() + "AND frequency_eating_out_per_week=" + (EatingOutPerWeek) + "");

        //   DataRow o = query.FirstOrDefault();

        //   if (o != null)
        //   {
        //       string PreferedFood1 = o["preference_food_1"].ToString();
        //       string PreferedFood2 = o["preference_food_2"].ToString();
        //       string PreferedFood3 = o["preference_food_3"].ToString();




        //       // First
        //       if (PreferedFood1.Contains("1"))
        //       {
        //           food1.Text = "Have A Pizza";
        //       }
        //       else if (PreferedFood1.Contains("2"))
        //       {
        //           food1.Text = "Have a Burger ";
        //       }
        //       else if (PreferedFood1.Contains("3"))
        //       {
        //           food1.Text = "have a Chinese";
        //       }
        //       else if (PreferedFood1.Contains("4"))
        //       {
        //           food1.Text = "have a Desi dry desi Wet";
        //       }
        //       else if (PreferedFood1.Contains("5"))
        //       {
        //           food1.Text = "try something new";
        //       }

        //       // Second
        //       if (PreferedFood2.Contains("1"))
        //       {
        //           food2.Text = "Have A Pizza";
        //       }
        //       else if (PreferedFood2.Contains("2"))
        //       {
        //           food2.Text = "Have a Burger ";
        //       }
        //       else if (PreferedFood2.Contains("3"))
        //       {
        //           food2.Text = "have a Chinese";
        //       }
        //       else if (PreferedFood2.Contains("4"))
        //       {
        //           food2.Text = "have a Desi Wets";
        //       }
        //       else if (PreferedFood2.Contains("5"))
        //       {
        //           food2.Text = "try something new";
        //       }



        //       //Third Location
        //       if (PreferedFood3.Contains("1"))
        //       {
        //           food3.Text = "Have A Pizza";
        //       }
        //       else if (PreferedFood3.Contains("2"))
        //       {
        //           food3.Text = "Have A Burger";
        //       }
        //       else if (PreferedFood3.Contains("3"))
        //       {
        //           food3.Text = "have a Chinese";
        //       }
        //       else if (PreferedFood3.Contains("4"))
        //       {
        //           food3.Text = "have a Desi Wets";
        //       }
        //       else if (PreferedFood3.Contains("5"))
        //       {
        //           food3.Text = "try something new";
        //       }




        //       //Location

        //      Literal1.Text = o["preference_location_1"].ToString();
        //      Literal2.Text = o["preference_location_2"].ToString();
        //      Literal3.Text = o["preference_location _3"].ToString();
        //       // Correspondence Value





        //       //// First
        //       //if (PreferedLocation1.Contains("1"))
        //       //{
        //       //    Literal1.Text = "Defence / Clifton";
        //       //}
        //       //else if (PreferedLocation1.Contains("2"))
        //       //{
        //       //    Literal1.Text = "Society / Gulshan";
        //       //}
        //       //else if (PreferedLocation1.Contains("3"))
        //       //{
        //       //    Literal1.Text = "Nazimabad / North Karach";
        //       //}
        //       //else if (PreferedLocation1.Contains("4"))
        //       //{
        //       //    Literal1.Text = "Gulistan e Jauhar / Mali";
        //       //}
        //       //else if (PreferedLocation1.Contains("5"))
        //       //{
        //       //    Literal1.Text = "saddar / Old City";
        //       //}
        //       //else if (PreferedLocation1.Contains("6"))
        //       //{
        //       //    Literal1.Text = "other";
        //       //}

        //       //// Second
        //       //if (PreferedLocation2.Contains("1"))
        //       //{
        //       //    Literal2.Text = "Defence / Clifton";
        //       //}
        //       //else if (PreferedLocation2.Contains("2"))
        //       //{
        //       //    Literal2.Text = "Society / Gulshan";
        //       //}
        //       //else if (PreferedLocation2.Contains("3"))
        //       //{
        //       //    Literal2.Text = "Nazimabad / North Karach";
        //       //}
        //       //else if (PreferedLocation2.Contains("4"))
        //       //{
        //       //    Literal2.Text = "Gulistan e Jauhar / Mali";
        //       //}
        //       //else if (PreferedLocation2.Contains("5"))
        //       //{
        //       //    Literal2.Text = "saddar / Old City";
        //       //}
        //       //else if (PreferedLocation2.Contains("6"))
        //       //{
        //       //    Literal2.Text = "other";
        //       //}
        //       //else if (PreferedLocation2.Contains("0"))
        //       //{
        //       //    Literal2.Text = "No location Described ";
        //       //}
        //       //else if (PreferedLocation2.Contains("0"))
        //       //{
        //       //    Literal3.Text = "No location Described ";
        //       //}


        //       ////Third Location
        //       //if (PreferedLocation3.Contains("1"))
        //       //{
        //       //    Literal3.Text = "Defence / Clifton";
        //       //}
        //       //else if (PreferedLocation3.Contains("2"))
        //       //{
        //       //    Literal3.Text = "Society / Gulshan";
        //       //}
        //       //else if (PreferedLocation3.Contains("3"))
        //       //{
        //       //    Literal3.Text = "Nazimabad / North Karach";
        //       //}
        //       //else if (PreferedLocation3.Contains("4"))
        //       //{
        //       //    Literal3.Text = "Gulistan e Jauhar / Mali";
        //       //}
        //       //else if (PreferedLocation3.Contains("5"))
        //       //{
        //       //    Literal3.Text = "saddar / Old City";
        //       //}
        //       //else if (PreferedLocation3.Contains("6"))
        //       //{
        //       //    Literal3.Text = "other";
        //       //}
        //       //else if (PreferedLocation3.Contains("0"))
        //       //{
        //       //    Literal3.Text = "No location Described ";
        //       //}

        //       //Literal1.Text = o["preference_location_1"].ToString();
        //       //Literal2.Text = o["preference_location_2"].ToString();
        //       //Literal3.Text = o["preference_location _3"].ToString();


        //   }
        //   else 
        //   {
        //       food1.Text = "No Match Found";
        //       food2.Text = "No Match Found";
        //       food3.Text = "No Match Found";
        //       Literal1.Text = "No Match Found";
        //       Literal2.Text = "No Match Found";
        //       Literal3.Text = "No Match Found";

        //   }
    }
}